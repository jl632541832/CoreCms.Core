using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 定时任务日志
    /// </summary>
    public partial class SysTaskLog
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysTaskLog()
        {
        }
		
        /// <summary>
        /// 序列
        /// </summary>
        [Display(Name = "序列")]
		[SugarColumn(IsPrimaryKey = true, IsIdentity = true)][Required(ErrorMessage = "请输入{0}")]
        public System.Int32 id  { get; set; }
		
        /// <summary>
        /// 任务名称
        /// </summary>
        [Display(Name = "任务名称")]
		[Required(ErrorMessage = "请输入{0}")][StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String name  { get; set; }
		
        /// <summary>
        /// 完成时间
        /// </summary>
        [Display(Name = "完成时间")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.DateTime createTime  { get; set; }
		
        /// <summary>
        /// 是否完成
        /// </summary>
        [Display(Name = "是否完成")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.Boolean isSuccess  { get; set; }
		
        /// <summary>
        /// 其他数据
        /// </summary>
        [Display(Name = "其他数据")]
		
        public System.String parameters  { get; set; }
		
    }
}
