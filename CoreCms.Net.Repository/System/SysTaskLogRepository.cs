using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreCms.Net.Configuration;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.Basics;
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 定时任务日志 接口实现
    /// </summary>
    public class SysTaskLogRepository : BaseRepository<SysTaskLog>, ISysTaskLogRepository
    {
        public SysTaskLogRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


    }
}
