using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCms.Net.Services
{
    /// <summary>
    /// 用户表 接口实现
    /// </summary>
    public class SysUserServices : BaseServices<SysUser>, ISysUserServices
    {
        private readonly ISysUserRepository _dal;
        private readonly ISysRoleRepository _sysRoleRepository;
        private readonly ISysUserRoleRepository _sysUserRoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SysUserServices(IUnitOfWork unitOfWork, ISysUserRepository dal, ISysRoleRepository sysRoleRepository, ISysUserRoleRepository sysUserRoleRepository)
        {
            this._dal = dal;
            base.BaseDal = dal;
            _unitOfWork = unitOfWork;
            _sysRoleRepository = sysRoleRepository;
            _sysUserRoleRepository = sysUserRoleRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="loginPwd"></param>
        /// <returns></returns>
        public async Task<string> GetUserRoleNameStr(string loginName, string loginPwd)
        {
            string roleName = "";
            var user = await base.QueryByClauseAsync(a => a.userName == loginName && a.passWord == loginPwd);
            var roleList = await _sysRoleRepository.QueryListByClauseAsync(a => a.deleted == false);
            if (user != null)
            {
                var userRoles = await _sysUserRoleRepository.QueryListByClauseAsync(ur => ur.userId == user.id);
                if (userRoles.Count > 0)
                {
                    var arr = userRoles.Select(ur => ur.roleId).ToList();
                    var roles = roleList.Where(d => arr.Contains(d.id));

                    roleName = string.Join(',', roles.Select(r => r.roleCode).ToArray());
                }
            }
            return roleName;
        }
    }
}