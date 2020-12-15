
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 用户表 接口实现
    /// </summary>
    public class CoreCmsUserWeChatInfoRepository : BaseRepository<CoreCmsUserWeChatInfo>, ICoreCmsUserWeChatInfoRepository
    {
        public CoreCmsUserWeChatInfoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

       
    }
}
