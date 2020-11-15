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
using CoreCms.Net.Utility.Extensions;
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

            //注入附件存储配置
            services.Configure<FilesStorageOptions>(Configuration.GetSection("FilesStorage"));

            //Swagger接口文档注入
            services.AddAdminSwaggerSetup();

            //jwt授权支持注入
            services.AddAuthorizationSetupForAdmin();
            //上下文注入
            services.AddHttpContextSetup();

            //服务配置中加入AutoFac控制器替换规则。
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            //注册mvc，注册razor引擎视图
            services.AddMvc(options =>
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
                });

            //凯信通短信配置
            services.Configure<KxtSmsOptions>(Configuration.GetSection("KXTSMS"));

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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            // 跳转https
            //app.UseHttpsRedirection();
            // 使用静态文件
            app.UseStaticFiles();
            // 使用cookie
            app.UseCookiePolicy();
            // 返回错误码
            app.UseStatusCodePages();
            // Routing
            app.UseRouting();
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
            var defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(defaultFilesOptions);
            app.UseStaticFiles();
        }
    }
}