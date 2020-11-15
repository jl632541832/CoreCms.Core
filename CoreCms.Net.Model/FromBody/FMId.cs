/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *           Versions: 1.0                                             *
 *         CreateTime: 2020-02-05 21:15:23
 *          NameSpace: CoreCms.Net.Framework.Data.Models.FromBody
 *           FileName: FMId
 *   ClassDescription:
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreCms.Net.Model.FromBody
{
    public class FMIntId
    {
        /// <summary>
        /// 序列
        /// </summary>
        [Display(Name = "序列")]
        [Required(ErrorMessage = "请输入要提交的序列参数")]
        public int id { get; set; }
        public object data { get; set; } = null;
    }

    public class FMIntIdByListIntData
    {
        public int id { get; set; }
        public List<int> data { get; set; } = null;
    }



    public class FMArrayIntIds
    {
        public int[] id { get; set; }
        public object data { get; set; } = null;
    }

    public class FMStringId
    {
        public string id { get; set; }
        public object data { get; set; } = null;
    }

    public class FMArrayStringIds
    {
        public string[] id { get; set; }
        public object data { get; set; } = null;
    }


    public class FMGuidId
    {
        public Guid id { get; set; }
        public object data { get; set; } = null;
    }


    public class FMArrayGuidIds
    {
        public Guid[] id { get; set; }
        public object data { get; set; } = null;
    }

}
