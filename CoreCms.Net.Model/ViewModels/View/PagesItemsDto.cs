using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace CoreCms.Net.Model.ViewModels.View
{
    /// <summary>
    /// 单页内容
    /// </summary>
    public partial class PagesItemsDto
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PagesItemsDto()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        [Required(ErrorMessage = "请输入{0}")]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 组件编码
        /// </summary>
        [Display(Name = "组件编码")]
        [Required(ErrorMessage = "请输入{0}")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0}不能超过{1}字")]
        public System.String widgetCode { get; set; }

        /// <summary>
        /// 页面编码
        /// </summary>
        [Display(Name = "页面编码")]
        [Required(ErrorMessage = "请输入{0}")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0}不能超过{1}字")]
        public System.String pageCode { get; set; }

        /// <summary>
        /// 布局位置
        /// </summary>
        [Display(Name = "布局位置")]
        [Required(ErrorMessage = "请输入{0}")]
        public System.Int32 positionId { get; set; }

        /// <summary>
        /// 排序，越小越靠前
        /// </summary>
        [Display(Name = "排序，越小越靠前")]
        [Required(ErrorMessage = "请输入{0}")]
        public System.Int32 sort { get; set; }

        /// <summary>
        /// 组件配置内容
        /// </summary>
        [Display(Name = "组件配置内容")]

        public System.Object parameters { get; set; }

    }
}
