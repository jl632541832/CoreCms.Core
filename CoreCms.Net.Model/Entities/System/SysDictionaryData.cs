using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 数据字典项表
    /// </summary>
    public partial class SysDictionaryData
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysDictionaryData()
        {
        }
		
        /// <summary>
        /// 字典项id
        /// </summary>
        [Display(Name = "字典项id")]
		[SugarColumn(IsPrimaryKey = true, IsIdentity = true)][Required(ErrorMessage = "请输入{0}")]
        public System.Int32 id  { get; set; }
		
        /// <summary>
        /// 字典id
        /// </summary>
        [Display(Name = "字典id")]
		
        public System.Int32? dictId  { get; set; }
		
        /// <summary>
        /// 字典项标识
        /// </summary>
        [Display(Name = "字典项标识")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String dictDataCode  { get; set; }
		
        /// <summary>
        /// 字典项名称
        /// </summary>
        [Display(Name = "字典项名称")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
        public System.String dictDataName  { get; set; }
		
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
		[StringLength(maximumLength:50,ErrorMessage = "{0}不能超过{1}字")]
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
