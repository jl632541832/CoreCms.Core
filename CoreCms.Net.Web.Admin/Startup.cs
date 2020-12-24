using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using CoreCms.Net.Auth;
using CoreCms.Net.CodeGenerator.Repository;
using CoreCms.Net.CodeGenerator.Services;
using CoreCms.Net.Configuration;
using CoreCms.Net.Core.AOP;
using CoreCms.Net.Core.Extensions;
using CoreCms.Net.Filter;
using CoreCms.Net.Loging;
using CoreCms.Net.Mapping;
using CoreCms.Net.Middlewares;
using CoreCms.Net.Model.ViewModels.Options;
using CoreCms.Net.Model.ViewModels.Sms;
using CoreCms.Net.Swagger;
using CoreCms.Net.Task;
using CoreCms.Net.Utility.Extensions;
using CoreCms.Net.WeChatService.CustomMessageHandler;
using CoreCms.Net.WeChatService.MessageHandlers.WebSocket;
using CoreCms.Net.WeChatService.WxOpenMessageHandler;
using Essensoft.AspNetCore.Payment.Alipay;
using Essensoft.AspNetCore.Payment.WeChatPay;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.Dashboard.BasicAuthorization;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Senparc.CO2NET;
using Senparc.CO2NET.AspNet;
using Senparc.NeuChar.MessageHandlers;
using Senparc.WebSocket;
using Senparc.Weixin;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.MessageHandlers.Middleware;
using Senparc.Weixin.RegisterServices;
using Senparc.Weixin.WxOpen;
using Senparc.Weixin.WxOpen.MessageHandlers.Middleware;

namespace CoreCms.Net.Web.Admin
{
    /// <summary>
    ///     启动配置
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        /// <summary>
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// </summary>
        public IWebHostEnvironment Env { get; }

        /// <summary>
        ///     This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //添加本地路径获取支持
            services.AddSingleton(new AppSettingsHelper(Env.ContentRootPath));
            services.AddSingleton(new LogLockHelper(Env.ContentRootPath));

            //添加内存缓存注入
            services.AddMemoryCache();
            //添加数据库连接SqlSugar注入支持
            services.AddSqlSugarSetup();
            //配置跨域（CORS）
            services.AddCorsSetup();

            //添加session支持(session依赖于cache进行存储)
            services.AddSession();
            // AutoMapper支持
            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            //使用 SignalR
            services.AddSignalR();

            // 引入Payment 依赖注入(支付宝支付/微信支付)
            services.AddAlipay();
            services.AddWeChatPay();

            // 在 appsettings.json 中 配置选项
            services.Configure<WeChatPayOptions>(Configuration.GetSection("WeChatPay"));
            services.Configure<AlipayOptions>(Configuration.GetSection("Alipay"));

            //注入附件存储配置
            services.Configure<FilesStorageOptions>(Configuration.GetSection("FilesStorage"));

            //Swagger接口文档注入
            services.AddAdminSwaggerSetup();

            //jwt授权支持注入
            services.AddAuthorizationSetupForAdmin();
            //上下文注入
            services.AddHttpContextSetup();


            //微信注册
            services.AddSenparcWeixinServices(Configuration) //Senparc.Weixin 注册（必须）
                .AddSenparcWebSocket<CustomNetCoreWebSocketMessageHandler>(); //Senparc.WebSocket 注册（按需）

            //服务配置中加入AutoFac控制器替换规则。
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            //注册mvc，注册razor引擎视图
            services.AddControllersWithViews(options =>
                {
                    //实体验证
                    options.Filters.Add<RequiredErrorForAdmin>();
                    //异常处理
                    options.Filters.Add<GlobalExceptionsFilterForAdmin>();
                    //Swagger剔除不需要加入api展示的列表
                    options.Conventions.Add(new ApiExplorerIgnores());
                })
                .AddNewtonsoftJson(p =>
                {
                    //忽略循环引用
                    p.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //不使用驼峰样式的key
                    p.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    //设置时间格式
                    p.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                }).AddRazorRuntimeCompilation();

            //凯信通短信配置
            services.Configure<KxtSmsOptions>(Configuration.GetSection("KXTSMS"));

            //注册Hangfire定时任务
            var isEnabledRedis = AppSettingsHelper.GetContent("RedisCachingConfig", "Enabled").ObjectToBool();
            if (isEnabledRedis)
            {
                services.AddHangfire(x =>
                    x.UseRedisStorage(AppSettingsHelper.GetContent("RedisCachingConfig", "ConnectionString")));
            }
            else
            {
                services.AddHangfire(x =>
                    x.UseSqlServerStorage(AppSettingsHelper.GetContent("ConnectionStrings", "SqlServerConnection")));
            }

        }

        /// <summary>
        ///     Autofac服务工厂
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //获取所有控制器类型并使用属性注入
            var controllerBaseType = typeof(ControllerBase);
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
                .PropertiesAutowired();

            var basePath = ApplicationEnvironment.ApplicationBasePath;

            #region 带有接口层的服务注入

            var servicesDllFile = Path.Combine(basePath, "CoreCms.Net.Services.dll");
            var repositoryDllFile = Path.Combine(basePath, "CoreCms.Net.Repository.dll");

            if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
            {
                var msg = "Repository.dll和Services.dll 丢失，因为项目解耦了，所以需要先F6编译，再F5运行，请检查 bin 文件夹，并拷贝。";
                throw new Exception(msg);
            }

            // AOP 开关，如果想要打开指定的功能，只需要在 appsettigns.json 对应对应 true 就行。
            var cacheType = new List<Type>();
            if (AppSettingsHelper.GetContent("RedisCachingConfig", "Enabled").ObjectToBool())
            {
                builder.RegisterType<RedisCacheAop>();
                cacheType.Add(typeof(RedisCacheAop));
            }
            else
            {
                builder.RegisterType<MemoryCacheAop>();
                cacheType.Add(typeof(MemoryCacheAop));
            }

            if (AppSettingsHelper.GetContent("TranAOP", "Enabled").ObjectToBool())
            {
                builder.RegisterType<TranAop>();
                cacheType.Add(typeof(TranAop));
            }

            // 获取 Service.dll 程序集服务，并注册
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            //支持属性注入依赖重复
            builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces().InstancePerDependency()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            // 获取 Repository.dll 程序集服务，并注册
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            //支持属性注入依赖重复
            builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces().InstancePerDependency()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            #endregion

            #region 单独注册一个含有接口的类，启用interface代理拦截

            //代码生成器独立接口
            builder.RegisterType<CodeGeneratorRepository>().As<ICodeGeneratorRepository>().AsImplementedInterfaces()
                .EnableInterfaceInterceptors();
            builder.RegisterType<CodeGeneratorServices>().As<ICodeGeneratorServices>().AsImplementedInterfaces()
                .EnableInterfaceInterceptors();

            #endregion
        }

        /// <summary>
        ///     This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<SenparcSetting> senparcSetting,
            IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {
            // 记录请求与返回数据  (注意开启权限，不然本地无法写入)
            app.UseReuestResponseLog();
            // 记录ip请求 (注意开启权限，不然本地无法写入)
            app.UseIpLogMildd();
            // signalr
            app.UseSignalRSendMildd();

            //强制显示中文
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            var supportedCultures = new[]
            {
              new System.Globalization.CultureInfo("zh-CN"),
              //new CultureInfo("en-US")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("zh-CN"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                    new AcceptLanguageHeaderRequestCultureProvider()
                }
            });

            #region Hangfire定时任务

            var queues = new string[] { GlobalEnumVars.HangFireQueuesConfig.@default.ToString(), GlobalEnumVars.HangFireQueuesConfig.apis.ToString(), GlobalEnumVars.HangFireQueuesConfig.web.ToString(), GlobalEnumVars.HangFireQueuesConfig.recurring.ToString() };
            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                ServerTimeout = TimeSpan.FromMinutes(4),
                SchedulePollingInterval = TimeSpan.FromSeconds(15),//秒级任务需要配置短点，一般任务可以配置默认时间，默认15秒
                ShutdownTimeout = TimeSpan.FromMinutes(30),//超时时间
                Queues = queues,//队列
                WorkerCount = Math.Max(Environment.ProcessorCount, 20)//工作线程数，当前允许的最大线程，默认20
            });

            //授权
            var filter = new BasicAuthAuthorizationFilter(
                new BasicAuthAuthorizationFilterOptions
                {
                    SslRedirect = false,
                    // Require secure connection for dashboard
                    RequireSsl = false,
                    // Case sensitive login checking
                    LoginCaseSensitive = false,
                    // Users
                    Users = new[]
                    {
                        new BasicAuthAuthorizationUser
                        {
                            Login = AppSettingsHelper.GetContent("HangFire", "Login"),
                            PasswordClear = AppSettingsHelper.GetContent("HangFire", "PassWord")
                        }
                    }
                });
            var options = new DashboardOptions
            {
                AppPath = "/",//返回时跳转的地址
                DisplayStorageConnectionString = false,//是否显示数据库连接信息
                Authorization = new[] { filter },
                IsReadOnlyFunc = Context =>
                {
                    return false;//是否只读面板
                }
            };

            app.UseHangfireDashboard("/job", options); //可以改变Dashboard的url
            HangfireDispose.HangfireService();

            #endregion

            app.UseSwagger().UseSwaggerUI(c =>
            {
                //根据版本名称倒序 遍历展示
                typeof(CustomApiVersion.ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(
                    version =>
                    {
                        c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"Doc {version}");
                    });
                c.RoutePrefix = "doc";
            });

            //使用 Session
            app.UseSession();

            if (env.IsDevelopment())
            {
                // 在开发环境中，使用异常页面，这样可以暴露错误堆栈信息，所以不要放在生产环境。
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            //配置跨域（CORS）
            app.UseCors("cors");
            // 使用cookie
            app.UseCookiePolicy();
            // 返回错误码
            app.UseStatusCodePages();
            // Routing
            app.UseRouting();

            // 启动 CO2NET 全局注册，必须！
            app.UseSenparcGlobal(env, senparcSetting.Value, globalRegister => { }, true)
                .UseSenparcWeixin(senparcWeixinSetting.Value,
                    weixinRegister =>
                    {
                        weixinRegister.RegisterMpAccount(senparcWeixinSetting.Value, "公众号")
                            .RegisterWxOpenAccount(senparcWeixinSetting.Value, "程序");
                    });
            //使用 公众号 MessageHandler 中间件
            app.UseMessageHandlerForMp("/WeixinAsync", CustomMessageHandler.GenerateMessageHandler, options =>
            {
                options.AccountSettingFunc = context => senparcWeixinSetting.Value;
                //对 MessageHandler 内异步方法未提供重写时，调用同步方法（按需）
                options.DefaultMessageHandlerAsyncEvent = DefaultMessageHandlerAsyncEvent.SelfSynicMethod;
            });
            //使用 小程序 MessageHandler 中间件
            app.UseMessageHandlerForWxOpen("/WxOpenAsync", CustomWxOpenMessageHandler.GenerateMessageHandler, options =>
            {
                options.DefaultMessageHandlerAsyncEvent = DefaultMessageHandlerAsyncEvent.SelfSynicMethod;
                options.AccountSettingFunc = context => senparcWeixinSetting.Value;
            });


            // 跳转https
            //app.UseHttpsRedirection();
            // 使用静态文件
            app.UseStaticFiles();

            // 先开启认证
            app.UseAuthentication();
            // 然后是授权中间件
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "areas",
                    "{area:exists}/{controller=Default}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });

            //设置默认起始页（如default.html）
            //此处的路径是相对于wwwroot文件夹的相对路径
            //var defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("index.html");
            //app.UseDefaultFiles(defaultFilesOptions);
            //app.UseStaticFiles();
        }
    }
}