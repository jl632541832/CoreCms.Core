/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *           Versions: 1.0                                             *
 *         CreateTime: 2020-02-02 22:19:59
 *          NameSpace: CoreCms.Net.Framework.Auth.Policys
 *           FileName: ApiResponse
 *   ClassDescription: 
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCms.Net.Auth.Policys
{
    public class ApiResponse
    {
        public int Status { get; set; } = 404;
        public object Value { get; set; } = "No Found";

        public ApiResponse(StatusCode apiCode, object msg = null)
        {
            switch (apiCode)
            {
                case StatusCode.CODE401:
                {
                    Status = 401;
                    Value = "很抱歉，您无权访问该接口，请确保已经登录!";
                }
                    break;
                case StatusCode.CODE403:
                {
                    Status = 403;
                    Value = "很抱歉，您的访问权限等级不够，联系管理员!";
                }
                    break;
                case StatusCode.CODE500:
                {
                    Status = 500;
                    Value = msg;
                }
                    break;
            }
        }
    }

    public enum StatusCode
    {
        CODE401,
        CODE403,
        CODE404,
        CODE500
    }
}
