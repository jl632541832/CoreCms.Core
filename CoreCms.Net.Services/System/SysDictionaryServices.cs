using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    /// 数据字典表 接口实现
    /// </summary>
    public class SysDictionaryServices : BaseServices<SysDictionary>, ISysDictionaryServices
    {
        private readonly ISysDictionaryRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public SysDictionaryServices(IUnitOfWork unitOfWork, ISysDictionaryRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}