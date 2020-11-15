/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *           Versions: 1.0                                             *
 *         CreateTime: 2020-02-03 22:38:54
 *          NameSpace: CoreCms.Net.Framework.Auth
 *           FileName: HttpContextSetup
 *   ClassDescription: 
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;
using CoreCms.Net.Auth.HttpContextUser;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CoreCms.Net.Auth
{
    /// <summary>
    /// 上下文启动
    /// </summary>
    public static class HttpContextSetup
    {
        public static void AddHttpContextSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IHttpContextUser, AspNetUser>();
        }
    }
}
