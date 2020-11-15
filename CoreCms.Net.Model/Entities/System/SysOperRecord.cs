using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 操作日志表
    /// </summary>
    public partial class SysOperRecord
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysOperRecord()
        {
        }
		
        /// <summary>
        /// 主键
        /// </summary>
        [Display(Name = "主键")]
		[SugarColumn(IsPrimaryKey = true, IsIdentity = true)][Required(ErrorMessage = "请输入{0}")]
        public System.Int32 id  { get; set; }
		
        /// <summary>
        /// 用户id
        /// </summary>
        [Display(Name = "用户id")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.Int32 userId  { get; set; }
		
        /// <summary>
        /// 操作模块
        /// </summary>
        [Display(Name = "操作模块")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String model  { get; set; }
		
        /// <summary>
        /// 操作方法
        /// </summary>
        [Display(Name = "操作方法")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String description  { get; set; }
		
        /// <summary>
        /// 请求地址
        /// </summary>
        [Display(Name = "请求地址")]
		[StringLength(maximumLength:255,ErrorMessage = "{0}不能超过{1}字")]
        public System.String url  { get; set; }
		
        /// <summary>
        /// 请求方式
        /// </summary>
        [Display(Name = "请求方式")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String requestMethod  { get; set; }
		
        /// <summary>
        /// 调用方法
        /// </summary>
        [Display(Name = "调用方法")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String operMethod  { get; set; }
		
        /// <summary>
        /// 请求参数
        /// </summary>
        [Display(Name = "请求参数")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String param  { get; set; }
		
        /// <summary>
        /// 返回结果
        /// </summary>
        [Display(Name = "返回结果")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String result  { get; set; }
		
        /// <summary>
        /// ip地址
        /// </summary>
        [Display(Name = "ip地址")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String ip  { get; set; }
		
        /// <summary>
        /// 请求耗时,单位毫秒
        /// </summary>
        [Display(Name = "请求耗时,单位毫秒")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.Int32 spendTime  { get; set; }
		
        /// <summary>
        /// 状态,0成功,1异常
        /// </summary>
        [Display(Name = "状态,0成功,1异常")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.Int32 state  { get; set; }
		
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
		[StringLength(maximumLength:500,ErrorMessage = "{0}不能超过{1}字")]
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
