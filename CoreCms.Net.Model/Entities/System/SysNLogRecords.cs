using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// Nlog记录表
    /// </summary>
    public partial class SysNLogRecords
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysNLogRecords()
        {
        }
		
        /// <summary>
        /// 序列
        /// </summary>
        [Display(Name = "序列")]
		[SugarColumn(IsPrimaryKey = true, IsIdentity = true)][Required(ErrorMessage = "请输入{0}")]
        public System.Int32 id  { get; set; }
		
        /// <summary>
        /// 时间
        /// </summary>
        [Display(Name = "时间")]
		
        public System.DateTime? LogDate  { get; set; }
		
        /// <summary>
        /// 级别
        /// </summary>
        [Display(Name = "级别")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String LogLevel  { get; set; }
		
        /// <summary>
        /// 事件日志上下文
        /// </summary>
        [Display(Name = "事件日志上下文")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String LogType  { get; set; }
		
        /// <summary>
        /// 记录器名字
        /// </summary>
        [Display(Name = "记录器名字")]
		[StringLength(maximumLength:255,ErrorMessage = "{0}不能超过{1}字")]
        public System.String Logger  { get; set; }
		
        /// <summary>
        /// 消息
        /// </summary>
        [Display(Name = "消息")]
		
        public System.String Message  { get; set; }
		
        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String MachineName  { get; set; }
		
        /// <summary>
        /// ip
        /// </summary>
        [Display(Name = "ip")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String MachineIp  { get; set; }
		
        /// <summary>
        /// 请求方式
        /// </summary>
        [Display(Name = "请求方式")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String NetRequestMethod  { get; set; }
		
        /// <summary>
        /// 请求地址
        /// </summary>
        [Display(Name = "请求地址")]
		[StringLength(maximumLength:500,ErrorMessage = "{0}不能超过{1}字")]
        public System.String NetRequestUrl  { get; set; }
		
        /// <summary>
        /// 是否授权
        /// </summary>
        [Display(Name = "是否授权")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String NetUserIsauthenticated  { get; set; }
		
        /// <summary>
        /// 授权类型
        /// </summary>
        [Display(Name = "授权类型")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String NetUserAuthtype  { get; set; }
		
        /// <summary>
        /// 身份认证
        /// </summary>
        [Display(Name = "身份认证")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String NetUserIdentity  { get; set; }
		
        /// <summary>
        /// 异常信息
        /// </summary>
        [Display(Name = "异常信息")]
		
        public System.String Exception  { get; set; }
		
    }
}
