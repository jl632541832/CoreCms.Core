using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 角色菜单关联表
    /// </summary>
    public partial class SysRoleMenu
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysRoleMenu()
        {
        }
		
        /// <summary>
        /// 主键
        /// </summary>
        [Display(Name = "主键")]
		[SugarColumn(IsPrimaryKey = true, IsIdentity = true)][Required(ErrorMessage = "请输入{0}")]
        public System.Int32 id  { get; set; }
		
        /// <summary>
        /// 角色id
        /// </summary>
        [Display(Name = "角色id")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.Int32 roleId  { get; set; }
		
        /// <summary>
        /// 菜单id
        /// </summary>
        [Display(Name = "菜单id")]
		[Required(ErrorMessage = "请输入{0}")]
        public System.Int32 menuId  { get; set; }
		
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
