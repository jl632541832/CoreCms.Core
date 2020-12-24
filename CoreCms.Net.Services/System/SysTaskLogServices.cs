using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    /// 定时任务日志 接口实现
    /// </summary>
    public class SysTaskLogServices : BaseServices<SysTaskLog>, ISysTaskLogServices
    {
        private readonly ISysTaskLogRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public SysTaskLogServices(IUnitOfWork unitOfWork, ISysTaskLogRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}