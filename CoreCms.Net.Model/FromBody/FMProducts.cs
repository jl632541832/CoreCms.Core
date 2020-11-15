/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *         CreateTime: 2020-03-26 23:58:58
 *        Description: 暂无
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCms.Net.Model.FromBody
{
    class FMProducts
    {
    }


    /// <summary>
    /// 获取子规格
    /// </summary>

    public class ItemSpesDesc
    {
        public string name { get; set; } = string.Empty;
        public bool isDefault { get; set; } = false;
        public int productId { get; set; } = 0;
    }



    /// <summary>
    /// 获取相应规格
    /// </summary>

    public class DefaultSpesDesc
    {
        public string name { get; set; } = string.Empty;
        public bool isDefault { get; set; } = false;
        public int productId { get; set; } = 0;
    }

}
