/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *           Versions: 1.0                                             *
 *         CreateTime: 2020-06-07 4:24:02
 *          NameSpace: CoreCms.Net.Model.FromBody
 *           FileName: FMUser
 *   ClassDescription: 
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCms.Net.Model.FromBody
{
    /// <summary>
    /// APi
    /// </summary>
    public class EditInfoPost
    {
        public DateTime? birthday { get; set; }

        public string nickname { get; set; }

        public int sex { get; set; }
    }

    /// <summary>
    /// 编辑后端登录个人账户密码
    /// </summary>
    public class EditPwdPost
    {
        public string newpwd { get; set; }

        public string repwd { get; set; }


        public string pwd { get; set; }
    }


    /// <summary>
    /// 编辑登录用户个人信息
    /// </summary>

    public class EditLoginUserInfo
    {

        /// <summary>
        /// 昵称
        /// </summary>
        public System.String nickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public System.String avatar { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public System.Int32 sex { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public System.String phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public System.String email { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public System.String trueName { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public System.String idCard { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public System.DateTime? birthday { get; set; }

        /// <summary>
        /// 个人简介
        /// </summary>
        public System.String introduction { get; set; }

    }

    /// <summary>
    /// API取回密码提交参数
    /// </summary>
    public class FMForgetPwdPost
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        public string newpwd { get; set; }
        /// <summary>
        /// 确认新密码
        /// </summary>
        public string repwd { get; set; }

    }

}
