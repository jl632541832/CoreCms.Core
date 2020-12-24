using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    /// 用户角色关联表 接口实现
    /// </summary>
    public class SysUserRoleServices : BaseServices<SysUserRole>, ISysUserRoleServices
    {
        private readonly ISysUserRoleRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public SysUserRoleServices(IUnitOfWork unitOfWork, ISysUserRoleRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}