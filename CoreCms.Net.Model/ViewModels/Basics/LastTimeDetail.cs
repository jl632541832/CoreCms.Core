/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *         CreateTime: 2020-06-14 20:54:24
 *        Description: 暂无
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCms.Net.Model.ViewModels.Basics
{
    /// <summary>
    /// 剩余时间
    /// </summary>
    public class LastTimeDetail
    {
        /// <summary>
        /// 日
        /// </summary>
        public int day { get; set; } = 0;
        /// <summary>
        /// 时
        /// </summary>
        public int hour { get; set; } = 0;
        /// <summary>
        /// 分
        /// </summary>
        public int minute { get; set; } = 0;
        /// <summary>
        /// 秒
        /// </summary>
        public int second { get; set; } = 0;

    }
}
