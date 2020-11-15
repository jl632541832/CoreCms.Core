/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *           Versions: 1.0                                             *
 *         CreateTime: 2020-02-12 21:28:40
 *          NameSpace: CoreCms.Net.Framework.Data.Models.Basics
 *           FileName: DbTableInfo
 *   ClassDescription: 
 ***********************************************************************/


using System.Collections.Generic;
using SqlSugar;

namespace CoreCms.Net.Model.ViewModels.Basics
{
    /// <summary>
    /// 代码生成器下拉数据列表实体
    /// </summary>
    public class DbTableInfoTree
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public DbObjectType DbObjectType { get; set; }
    }

    /// <summary>
    /// 表名带字段
    /// </summary>
    public class DbTableInfoAndColumns
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<DbColumnInfo> columns { get; set; } = null;
        public DbObjectType DbObjectType { get; set; }
    }

}
