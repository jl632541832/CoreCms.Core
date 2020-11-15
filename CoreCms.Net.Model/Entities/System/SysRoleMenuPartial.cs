using System.Collections.Generic;
using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 用户权限和菜单关系表扩展
    /// </summary>
    public partial class SysRoleMenu
    {

        /// <summary>
        /// 菜单
        /// </summary>
        [Display(Name = "菜单")]
        [SugarColumn(IsIgnore = true)]
        public SysMenu menu { get; set; }


        /// <summary>
        /// 权限
        /// </summary>
        [Display(Name = "权限")]
        [SugarColumn(IsIgnore = true)]
        public SysRole role { get; set; }

    }
}
