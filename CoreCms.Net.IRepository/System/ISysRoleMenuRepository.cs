using System.Collections.Generic;
using System.Threading.Tasks;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.Basics;


namespace CoreCms.Net.IRepository
{
	/// <summary>
    /// 角色菜单关联表 工厂接口
    /// </summary>
    public interface ISysRoleMenuRepository : IBaseRepository<SysRoleMenu>
    {
        
        Task<List<SysRoleMenu>> RoleModuleMaps();

    }
}
