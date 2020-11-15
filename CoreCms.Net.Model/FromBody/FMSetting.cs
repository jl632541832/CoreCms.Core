/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *         CreateTime: 2020-03-03 2:59:56
 *        Description: 暂无
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;
using CoreCms.Net.Model.ViewModels.Basics;

namespace CoreCms.Net.Model.FromBody
{

    /// <summary>
    /// 配置文件更新类
    /// </summary>
    public class FMCoreCmsSetting_DoSaveModel
    {
        /// <summary>
        /// 列表
        /// </summary>
        public List<DictionaryKeyValues> entity { get; set; }

    }

}
