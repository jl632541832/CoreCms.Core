using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 数据字典表
    /// </summary>
    public partial class SysDictionary
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysDictionary()
        {
        }
		
        /// <summary>
        /// 字典id
        /// </summary>
        [Display(Name = "字典id")]
		[SugarColumn(IsPrimaryKey = true, IsIdentity = true)][Required(ErrorMessage = "请输入{0}")]
        public System.Int32 id  { get; set; }
		
        /// <summary>
        /// 字典标识
        /// </summary>
        [Display(Name = "字典标识")]
		[Required(ErrorMessage = "请输入{0}")][StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String dictCode  { get; set; }
		
        /// <summary>
        /// 字典名称
        /// </summary>
        [Display(Name = "字典名称")]
		[Required(ErrorMessage = "请输入{0}")][StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String dictName  { get; set; }
		
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
		[StringLength(maximumLength:500,ErrorMessage = "{0}不能超过{1}字")]
        public System.String comments  { get; set; }
		
        /// <summary>
        /// 排序号
        /// </summary>
        [Display(Name = "排序号")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.Int32 sortNumber  { get; set; }
		
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
