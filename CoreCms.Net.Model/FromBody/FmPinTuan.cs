/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *         CreateTime: 2020-03-14 1:54:34
 *        Description: 暂无
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCms.Net.Model.FromBody
{
    /// <summary>
    /// 根据订单id取拼团信息提交参数
    /// </summary>
    public class FMGetPinTuanTeamPost
    {
        public string orderId { get; set; } = "";
        public int teamId { get; set; } = 0;
    }

}
