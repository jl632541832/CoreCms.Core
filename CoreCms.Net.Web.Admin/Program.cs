using System;
using Autofac.Extensions.DependencyInjection;
using CoreCms.Net.Loging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using LogLevel = NLog.LogLevel;

namespace CoreCms.Net.Web.Admin
{
    /// <summary>
    ///     初始化
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     启动配置
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            //CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();
            try
            {
                using (var scope = host.Services.CreateScope())
                {
                    var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                    //获取到appsettings.json中的连接字符串
                    var sqlString = configuration.GetSection("ConnectionStrings:SqlServerConnection").Value;
                    //确保NLog.config中连接字符串与appsettings.json中同步
                    NLogUtil.EnsureNlogConfig("NLog.config", sqlString);
                }

                //throw new Exception("测试异常");//for test
                //其他项目启动时需要做的事情
                NLogUtil.WriteDbLog(LogLevel.Trace, LogType.Web, "网站启动成功");
                NLogUtil.WriteFileLog(LogLevel.Trace, LogType.Web, "网站启动成功");

                host.Run();
            }
            catch (Exception ex)
            {
                //使用nlog写到本地日志文件（万一数据库没创建/连接成功）
                var errorMessage = "网站启动成功初始化数据异常";
                NLogUtil.WriteFileLog(LogLevel.Error, LogType.Web, errorMessage, new Exception(errorMessage, ex));
                NLogUtil.WriteDbLog(LogLevel.Error, LogType.Web, errorMessage, new Exception(errorMessage, ex));
                throw;
            }
        }

        /// <summary>
        ///     创建启动支撑
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //<--NOTE THIS
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders(); //移除已经注册的其他日志处理程序
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace); //设置最小的日志级别
                })
                .UseNLog() //NLog: Setup NLog for Dependency injection
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .ConfigureKestrel(serverOptions =>
                        {
                            serverOptions.AllowSynchronousIO = true; //启用同步 IO
                        })
                        .UseStartup<Startup>();
                });
        }
    }
}