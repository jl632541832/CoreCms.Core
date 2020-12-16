using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class CoreCmsUserWeChatInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CoreCmsUserWeChatInfo()
        {
        }
		
        /// <summary>
        /// 用户ID
        /// </summary>
        [Display(Name = "用户ID")]
		[SugarColumn(IsPrimaryKey = true, IsIdentity = true)][Required(ErrorMessage = "请输入{0}")]
        public System.Int32 id  { get; set; }
		
        /// <summary>
        /// 第三方登录类型
        /// </summary>
        [Display(Name = "第三方登录类型")]
		
        public System.Int32? type  { get; set; }
		
        /// <summary>
        /// 关联用户表
        /// </summary>
        [Display(Name = "关联用户表")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.Int32 userId  { get; set; }
		
        /// <summary>
        /// openId
        /// </summary>
        [Display(Name = "openId")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String openid  { get; set; }
		
        /// <summary>
        /// 缓存key
        /// </summary>
        [Display(Name = "缓存key")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String sessionKey  { get; set; }
		
        /// <summary>
        /// unionid
        /// </summary>
        [Display(Name = "unionid")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String unionId  { get; set; }
		
        /// <summary>
        /// 头像
        /// </summary>
        [Display(Name = "头像")]
		[StringLength(maximumLength:255,ErrorMessage = "{0}不能超过{1}字")]
        public System.String avatar  { get; set; }
		
        /// <summary>
        /// 昵称
        /// </summary>
        [Display(Name = "昵称")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String nickName  { get; set; }
		
        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.Int32 gender  { get; set; }
		
        /// <summary>
        /// 语言
        /// </summary>
        [Display(Name = "语言")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String language  { get; set; }
		
        /// <summary>
        /// 城市
        /// </summary>
        [Display(Name = "城市")]
		[StringLength(maximumLength:80,ErrorMessage = "{0}不能超过{1}字")]
        public System.String city  { get; set; }
		
        /// <summary>
        /// 省
        /// </summary>
        [Display(Name = "省")]
		[StringLength(maximumLength:80,ErrorMessage = "{0}不能超过{1}字")]
        public System.String province  { get; set; }
		
        /// <summary>
        /// 国家
        /// </summary>
        [Display(Name = "国家")]
		[StringLength(maximumLength:80,ErrorMessage = "{0}不能超过{1}字")]
        public System.String country  { get; set; }
		
        /// <summary>
        /// 手机号码国家编码
        /// </summary>
        [Display(Name = "手机号码国家编码")]
		[StringLength(maximumLength:20,ErrorMessage = "{0}不能超过{1}字")]
        public System.String countryCode  { get; set; }
		
        /// <summary>
        /// 手机号码
        /// </summary>
        [Display(Name = "手机号码")]
		[StringLength(maximumLength:20,ErrorMessage = "{0}不能超过{1}字")]
        public System.String mobile  { get; set; }
		
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
		
        public System.DateTime? createTime  { get; set; }
		
        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
		
        public System.DateTime? updateTime  { get; set; }
		
    }
}
