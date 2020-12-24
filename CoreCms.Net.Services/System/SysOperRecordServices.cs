using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    /// 操作日志表 接口实现
    /// </summary>
    public class SysOperRecordServices : BaseServices<SysOperRecord>, ISysOperRecordServices
    {
        private readonly ISysOperRecordRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public SysOperRecordServices(IUnitOfWork unitOfWork, ISysOperRecordRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}