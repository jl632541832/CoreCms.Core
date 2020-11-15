using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.Net.Web.Admin.Controllers
{
    /// <summary>
    ///     演示类
    /// </summary>
    //[DisableCors]
    public class DemoController : Controller
    {

        /// <summary>
        ///     构造函数
        /// </summary>
        public DemoController()
        {
        }

        /// <summary>
        ///     默认首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {

            return Content("111");
        }
    }
}