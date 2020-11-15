/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *         CreateTime: 2020-03-19 3:47:24
 *        Description: 暂无
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreCms.Net.Model.FromBody
{
    #region 后端=================================================================================

    /// <summary>
    /// 页面布局类
    /// </summary>
    [Display(Name = "页面布局类")]
    public class FmPagesUpdate
    {
        [Display(Name = "区域编码")]
        [Required(ErrorMessage = "请输入{0}")]
        public string pageCode { get; set; }

        [Display(Name = "数据子集")]
        [Required(ErrorMessage = "请输入{0}")]
        public List<items> datalist { get; set; }

    }

    /// <summary>
    /// 数据子集类型
    /// </summary>
    [Display(Name = "数据子集类型")]
    public class items
    {
        [Display(Name = "数据子集类型")]
        [Required(ErrorMessage = "请输入{0}")]
        public string sType { get; set; }

        [Display(Name = "数据子集值")]
        [Required(ErrorMessage = "请输入{0}")]
        public string sValue { get; set; }
    }



    #endregion



    #region 小程序交互=================================================================================

    /// <summary>
    /// 获取随机用户购买记录提交参数
    /// </summary>
    public class FMGetRecodPost
    {
        public string type { get; set; }
        public int value { get; set; }
    }

    #endregion

}
