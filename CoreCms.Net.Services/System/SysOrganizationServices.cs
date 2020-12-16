using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    /// 组织机构表 接口实现
    /// </summary>
    public class SysOrganizationServices : BaseServices<SysOrganization>, ISysOrganizationServices
    {
        private readonly ISysOrganizationRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public SysOrganizationServices(IUnitOfWork unitOfWork, ISysOrganizationRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}