using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    ///     角色表 接口实现
    /// </summary>
    public class SysRoleServices : BaseServices<SysRole>, ISysRoleServices
    {
        private readonly ISysRoleRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public SysRoleServices(IUnitOfWork unitOfWork, ISysRoleRepository dal)
        {
            _dal = dal;
            BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}