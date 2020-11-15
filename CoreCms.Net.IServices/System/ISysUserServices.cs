using System.Threading.Tasks;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.IServices
{
    /// <summary>
    /// 用户表 服务工厂接口
    /// </summary>
    public interface ISysUserServices : IBaseServices<SysUser>
    {
        Task<string> GetUserRoleNameStr(string loginName, string loginPwd);
    }
}
