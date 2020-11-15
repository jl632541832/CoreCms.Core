using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 登录日志表
    /// </summary>
    public partial class SysLoginRecord
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysLoginRecord()
        {
        }
		
        /// <summary>
        /// 主键
        /// </summary>
        [Display(Name = "主键")]
		[SugarColumn(IsPrimaryKey = true, IsIdentity = true)][Required(ErrorMessage = "请输入{0}")]
        public System.Int32 id  { get; set; }
		
        /// <summary>
        /// 用户账号
        /// </summary>
        [Display(Name = "用户账号")]
		[Required(ErrorMessage = "请输入{0}")][StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String username  { get; set; }
		
        /// <summary>
        /// 操作系统
        /// </summary>
        [Display(Name = "操作系统")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String os  { get; set; }
		
        /// <summary>
        /// 设备名
        /// </summary>
        [Display(Name = "设备名")]
		[StringLength(maximumLength:100,ErrorMessage = "{0}不能超过{1}字")]
        public System.String device  { get; set; }
		
        /// <summary>
        /// 浏览器类型
        /// </summary>
        [Display(Name = "浏览器类型")]
		[StringLength(maximumLength:250,ErrorMessage = "{0}不能超过{1}字")]
        public System.String browser  { get; set; }
		
        /// <summary>
        /// ip地址
        /// </summary>
        [Display(Name = "ip地址")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String ip  { get; set; }
		
        /// <summary>
        /// 操作类型
        /// </summary>
        [Display(Name = "操作类型")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.Int32 operType  { get; set; }
		
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String comments  { get; set; }
		
        /// <summary>
        /// 登录时间
        /// </summary>
        [Display(Name = "登录时间")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.DateTime createTime  { get; set; }
		
        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Name = "修改时间")]
		
        public System.DateTime? updateTime  { get; set; }
		
    }
}
