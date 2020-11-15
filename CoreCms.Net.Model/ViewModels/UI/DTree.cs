/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *           Versions: 1.0                                             *
 *         CreateTime: 2020-02-04 22:21:29
 *          NameSpace: CoreCms.Net.Framework.Data.Models.UI
 *           FileName: DTree
 *   ClassDescription: 
 ***********************************************************************/


using System.Collections.Generic;

namespace CoreCms.Net.Model.ViewModels.UI
{
    /// <summary>
    /// Dtree标准下拉数据
    /// </summary>
    public class DTree
    {
        public dtreeStatus status { get; set; } = new dtreeStatus();
        public List<dtreeChild> data { get; set; }
    }

    public class dtreeStatus
    {
        public int code { set; get; } = 200;

        public string message { set; get; } = "操作成功";
    }

    public class dtreeChild
    {
        /// <summary>
        /// 序列
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        public string parentId { get; set; }
        /// <summary>
        /// 是否最后节点,无下级节点
        /// </summary>
        public bool last { get; set; }
        /// <summary>
        /// 是否选中 0否1是
        /// </summary>
        public string checkArr { get; set; } = "0";
        /// <summary>
        /// 子
        /// </summary>
        public object children { get; set; }
    }

    /// <summary>
    /// Dtree List集合数据格式
    /// </summary>

    public class DTreeList
    {
        /// <summary>
        /// 序列
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 开启复选框 0否1是
        /// </summary>
        public string checkArr { get; set; } = "0";
        /// <summary>
        /// 父类id
        /// </summary>
        public string parentId { get; set; }
    }

}
