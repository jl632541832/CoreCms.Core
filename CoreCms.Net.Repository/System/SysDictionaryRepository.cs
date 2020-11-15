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
    /// 数据字典表 接口实现
    /// </summary>
    public class SysDictionaryRepository : BaseRepository<SysDictionary>, ISysDictionaryRepository
    {
        public SysDictionaryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

      
    }
}
