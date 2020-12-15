using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using CoreCms.Net.IServices;
using CoreCms.Net.Utility.Helper;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOI.HSSF.UserModel;
using SqlSugar;

namespace CoreCms.Net.Web.Admin.Controllers
{
    /// <summary>
    /// 演示类
    /// </summary>
    //[DisableCors]
    public class DemoController : Controller
    {


        /// <summary>
        /// 构造函数
        /// </summary>
        public DemoController()
        {
        }
        /// <summary>
        /// 默认首页
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            //var data = await _pintuanRecordServices.GetRecord(2, 4080);
            //return new JsonResult(data);

            return Content("111");
        }
    }
}
