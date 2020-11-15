using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 角色表
    /// </summary>
    public partial class SysRole
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysRole()
        {
        }
		
        /// <summary>
        /// 角色id
        /// </summary>
        [Display(Name = "角色id")]
		[SugarColumn(IsPrimaryKey = true, IsIdentity = true)][Required(ErrorMessage = "请输入{0}")]
        public System.Int32 id  { get; set; }
		
        /// <summary>
        /// 角色名称
        /// </summary>
        [Display(Name = "角色名称")]
		[Required(ErrorMessage = "请输入{0}")][StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String roleName  { get; set; }
		
        /// <summary>
        /// 角色标识
        /// </summary>
        [Display(Name = "角色标识")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String roleCode  { get; set; }
		
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
		[StringLength(maximumLength:255,ErrorMessage = "{0}不能超过{1}字")]
        public System.String comments  { get; set; }
		
        /// <summary>
        /// 是否删除,0否,1是
        /// </summary>
        [Display(Name = "是否删除,0否,1是")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.Boolean deleted  { get; set; }
		
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.DateTime createTime  { get; set; }
		
        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Name = "修改时间")]
		
        public System.DateTime? updateTime  { get; set; }
		
    }
}
