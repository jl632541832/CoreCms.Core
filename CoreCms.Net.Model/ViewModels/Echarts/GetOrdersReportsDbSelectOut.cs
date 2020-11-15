/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *         CreateTime: 2020-08-31 3:06:02
 *        Description: 暂无
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCms.Net.Model.ViewModels.Echarts
{
    /// <summary>
    /// 获取订单销量统计查询数据库返回sql组合后的结果集
    /// </summary>
    public class GetOrdersReportsDbSelectOut
    {
        /// <summary>
        /// 排序
        /// </summary>
        public int number { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal val { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int  num { get; set; }

    }
}
