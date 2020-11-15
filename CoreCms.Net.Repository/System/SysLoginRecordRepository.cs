using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreCms.Net.Configuration;
using CoreCms.Net.IRepository;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.Basics;
using CoreCms.Net.IRepository.UnitOfWork;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 登录日志表 接口实现
    /// </summary>
    public class SysLoginRecordRepository : BaseRepository<SysLoginRecord>, ISysLoginRecordRepository
    {
        public SysLoginRecordRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

      
    }
}
