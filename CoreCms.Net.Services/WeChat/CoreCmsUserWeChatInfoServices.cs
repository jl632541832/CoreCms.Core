using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    /// 用户表 接口实现
    /// </summary>
    public class CoreCmsUserWeChatInfoServices : BaseServices<CoreCmsUserWeChatInfo>, ICoreCmsUserWeChatInfoServices
    {
        private readonly ICoreCmsUserWeChatInfoRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public CoreCmsUserWeChatInfoServices(IUnitOfWork unitOfWork, ICoreCmsUserWeChatInfoRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}