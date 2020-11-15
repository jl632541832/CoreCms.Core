/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *           Versions: 1.0                                             *
 *         CreateTime: 2020-02-02 21:01:01
 *          NameSpace: CoreCms.Net.Framework.Auth.Policys
 *           FileName: PermissionItem
 *   ClassDescription: 
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCms.Net.Auth.Policys
{
    /// <summary>
    /// 用户或角色或其他凭据实体
    /// </summary>
    public class PermissionItem
    {
        /// <summary>
        /// 用户或角色或其他凭据名称
        /// </summary>
        public virtual string Role { get; set; }
        /// <summary>
        /// 请求Url
        /// </summary>
        public virtual string Url { get; set; }
        /// <summary>
        /// 权限标识
        /// </summary>
        public virtual string Authority { get; set; }
        /// <summary>
        /// 路由标识Url
        /// </summary>
        public virtual string RouteUrl { get; set; }
    }
}
