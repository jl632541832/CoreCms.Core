using System.Collections.Generic;
using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 用户表扩展
    /// </summary>
    public partial class SysUser
    {

        /// <summary>
        /// 权限序列
        /// </summary>
        [Display(Name = "权限序列")]
        [SugarColumn(IsIgnore = true)]
        public string roleIds { get; set; }


        /// <summary>
        /// 权限列表
        /// </summary>
        [Display(Name = "权限序列")]
        [SugarColumn(IsIgnore = true)]
        public List<SysRole> roles { get; set; }


        /// <summary>
        /// 组织机构名称
        /// </summary>
        [Display(Name = "组织机构名称")]
        [SugarColumn(IsIgnore = true)]
        public string organizationName { get; set; }
    }
}
