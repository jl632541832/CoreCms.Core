/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *           Versions: 1.0                                             *
 *         CreateTime: 2020-02-03 16:13:05
 *          NameSpace: CoreCms.Net.Framework.Auth.HttpContextUser
 *           FileName: IUser
 *   ClassDescription: 
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CoreCms.Net.Auth.HttpContextUser
{
    public interface IHttpContextUser
    {
        string Name { get; }
        int ID { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
        List<string> GetClaimValueByType(string ClaimType);

        string GetToken();
        List<string> GetUserInfoFromToken(string ClaimType);
    }
}
