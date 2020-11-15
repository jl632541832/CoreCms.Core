using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 组织机构表
    /// </summary>
    public partial class SysOrganization
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysOrganization()
        {
        }
		
        /// <summary>
        /// 机构id
        /// </summary>
        [Display(Name = "机构id")]
		[SugarColumn(IsPrimaryKey = true, IsIdentity = true)][Required(ErrorMessage = "请输入{0}")]
        public System.Int32 id  { get; set; }
		
        /// <summary>
        /// 上级id,0是顶级
        /// </summary>
        [Display(Name = "上级id,0是顶级")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.Int32 parentId  { get; set; }
		
        /// <summary>
        /// 机构名称
        /// </summary>
        [Display(Name = "机构名称")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String organizationName  { get; set; }
		
        /// <summary>
        /// 机构名称
        /// </summary>
        [Display(Name = "机构名称")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String organizationFullName  { get; set; }
		
        /// <summary>
        /// 机构类型
        /// </summary>
        [Display(Name = "机构类型")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.Int32 organizationType  { get; set; }
		
        /// <summary>
        /// 负责人id
        /// </summary>
        [Display(Name = "负责人id")]
		
        public System.Int32? leaderId  { get; set; }
		
        /// <summary>
        /// 排序号
        /// </summary>
        [Display(Name = "排序号")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.Int32 sortNumber  { get; set; }
		
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
		[StringLength(maximumLength:500,ErrorMessage = "{0}不能超过{1}字")]
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
