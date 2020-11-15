using System.IO;
using AutoMapper;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.UI;
using CoreCms.Net.Model.ViewModels.View;
using Newtonsoft.Json;

namespace CoreCms.Net.Mapping
{
    /// <summary>
    /// AutoMapper的全局实体映射配置静态类
    /// </summary>
    public class AutoMapperConfiguration : Profile, AutoMapperIProfile
    {
        public AutoMapperConfiguration()
        {
            //CreateMap<Manager, ManagerDTO>().ReverseMap();

            CreateMap<SqlSugar.DbTableInfo, CoreCms.Net.Model.ViewModels.Basics.DbTableInfoTree>()
                .AfterMap((from, to, context) =>
                {
                    to.Label = from.Name + "[" + from.Description + "]";
                });



        }
    }
}
