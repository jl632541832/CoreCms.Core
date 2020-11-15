using System.Collections.Generic;
using System.Threading.Tasks;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.IServices
{
	/// <summary>
    /// 角色菜单关联表 服务工厂接口
    /// </summary>
    public interface ISysRoleMenuServices : IBaseServices<SysRoleMenu>
    {
        Task<List<SysRoleMenu>> RoleModuleMaps();
    }
}
