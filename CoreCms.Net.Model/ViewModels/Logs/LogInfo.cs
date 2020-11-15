/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *           Versions: 1.0                                             *
 *         CreateTime: 2020-02-03 23:06:16
 *          NameSpace: CoreCms.Net.Framework.Logging
 *           FileName: LogInfo
 *   ClassDescription: 
 ***********************************************************************/


using System;

namespace CoreCms.Net.Model.ViewModels.Logs
{
    /// <summary>
    /// 日志实体
    /// </summary>
    public class LogInfo
    {
        public DateTime Datetime { get; set; }
        public string Content { get; set; }
        public string IP { get; set; }
        public string LogColor { get; set; }
        public int Import { get; set; } = 0;
    }
}
