/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *         CreateTime: 2020-03-04 21:46:37
 *        Description: 暂无
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCms.Net.Model.FromBody
{
    /// <summary>
    /// 前端提交标准json键值对内容
    /// </summary>
    public class FmSerializeArray
    {
        public List<FormSerializeArray> entity { get; set; }

    }

    public class FormSerializeArray
    {
        public string name { get; set; }
        public string value { get; set; }
    }

}
