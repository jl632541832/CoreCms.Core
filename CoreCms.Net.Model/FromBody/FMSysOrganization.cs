/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *         CreateTime: 2020-07-16 1:14:29
 *        Description: 暂无
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCms.Net.Model.FromBody
{
    public class FMDoSetSysOrganizationLeaderPost
    {
        public int leaderId { get; set; }
        public int organizationId { get; set; }
    }
}
