/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *           Versions: 1.0                                             *
 *         CreateTime: 2020-02-05 19:32:52
 *          NameSpace: CoreCms.Net.Framework.Data.Models.Form
 *           FileName: FMLogin
 *   ClassDescription: 
 ***********************************************************************/


namespace CoreCms.Net.Model.FromBody
{
    /// <summary>
    /// 用户登录验证实体
    /// </summary>
    public class FMLogin
    {
        public string userName { get; set; }
        public string password { get; set; }
    }


    /// <summary>
    /// 用户登录验证实体
    /// </summary>
    public class FMEditLoginUserPassWord
    {
        public string oldPassword { get; set; }
        public string password { get; set; }
        public string repassword { get; set; }
    }


}
