using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using CoreCms.Net.Configuration;
using CoreCms.Net.IRepository;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.Basics;
using CoreCms.Net.IRepository.UnitOfWork;
using SqlSugar;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 角色菜单关联表 接口实现
    /// </summary>
    public class SysRoleMenuRepository : BaseRepository<SysRoleMenu>, ISysRoleMenuRepository
    {
        public SysRoleMenuRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        /// <summary>
        /// 角色权限Map
        /// RoleModulePermission, Module, Role 三表联合
        /// 第四个类型 RoleModulePermission 是返回值
        /// </summary>
        /// <returns></returns>
        public async Task<List<SysRoleMenu>> RoleModuleMaps()
        {
            return await base.QueryMuch<SysRoleMenu, SysMenu, SysRole, SysRoleMenu>(
                (rmp, m, r) => new object[] {
                    JoinType.Left, rmp.menuId == m.id,
                    JoinType.Left,  rmp.roleId == r.id
                },

                (rmp, m, r) => new SysRoleMenu()
                {
                    role = r,
                    menu = m,
                },
                (rmp, m, r) => m.deleted == false && r.deleted == false
            );
        }

    }
}
