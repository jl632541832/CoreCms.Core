/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *           Versions: 1.0                                             *
 *         CreateTime: 2020-02-03 22:49:41
 *          NameSpace: CoreCms.Net.Framework
 *           FileName: Cors
 *   ClassDescription: 
 ***********************************************************************/


using System;
using CoreCms.Net.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreCms.Net.Core.Extensions
{
    /// <summary>
    /// 配置跨域（CORS）
    /// </summary>
    public static class CorsSetup
    {
        public static void AddCorsSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddCors(c =>
            {
                c.AddPolicy("cors", policy =>
                {
                    // 支持多个域名端口，注意端口号后不要带/斜杆：比如localhost:8000/，是错的
                    // 注意，http://127.0.0.1:1818 和 http://localhost:1818 是不一样的，尽量写两个
                    policy
                        .WithOrigins(AppSettingsHelper.GetContent("CorsConfig", "IPs").Split(','))
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }
    }
}
