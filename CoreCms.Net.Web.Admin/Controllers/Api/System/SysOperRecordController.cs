using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoreCms.Net.Configuration;
using CoreCms.Net.Filter;
using CoreCms.Net.IServices;
using CoreCms.Net.Loging;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.Entities.Expression;
using CoreCms.Net.Model.FromBody;
using CoreCms.Net.Model.ViewModels.UI;
using CoreCms.Net.Utility.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using SqlSugar;

namespace CoreCms.Net.Web.Admin.Controllers
{
    /// <summary>
    ///     操作日志表
    /// </summary>
    [Description("操作日志表")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [RequiredErrorForAdmin]
    [Authorize]
    public class SysOperRecordController : ControllerBase
    {
        private readonly ISysOperRecordServices _SysOperRecordServices;
        private readonly IWebHostEnvironment _webHostEnvironment;

        /// <summary>
        ///     构造函数
        /// </summary>
        public SysOperRecordController(IWebHostEnvironment webHostEnvironment
            , ISysOperRecordServices SysOperRecordServices
        )
        {
            _webHostEnvironment = webHostEnvironment;
            _SysOperRecordServices = SysOperRecordServices;
        }

        #region 获取列表============================================================

        // POST: Api/SysOperRecord/GetPageList
        /// <summary>
        ///     获取列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("获取列表")]
        public async Task<JsonResult> GetPageList()
        {
            var jm = new AdminUiCallBack();
            var pageCurrent = Request.Form["page"].FirstOrDefault().ObjectToInt(1);
            var pageSize = Request.Form["limit"].FirstOrDefault().ObjectToInt(30);
            var where = PredicateBuilder.True<SysOperRecord>();
            //获取排序字段
            var orderField = Request.Form["orderField"].FirstOrDefault();
            Expression<Func<SysOperRecord, object>> orderEx;
            switch (orderField)
            {
                case "id":
                    orderEx = p => p.id;
                    break;
                case "userId":
                    orderEx = p => p.userId;
                    break;
                case "model":
                    orderEx = p => p.model;
                    break;
                case "description":
                    orderEx = p => p.description;
                    break;
                case "url":
                    orderEx = p => p.url;
                    break;
                case "requestMethod":
                    orderEx = p => p.requestMethod;
                    break;
                case "operMethod":
                    orderEx = p => p.operMethod;
                    break;
                case "param":
                    orderEx = p => p.param;
                    break;
                case "result":
                    orderEx = p => p.result;
                    break;
                case "ip":
                    orderEx = p => p.ip;
                    break;
                case "spendTime":
                    orderEx = p => p.spendTime;
                    break;
                case "state":
                    orderEx = p => p.state;
                    break;
                case "comments":
                    orderEx = p => p.comments;
                    break;
                case "createTime":
                    orderEx = p => p.createTime;
                    break;
                case "updateTime":
                    orderEx = p => p.updateTime;
                    break;
                default:
                    orderEx = p => p.id;
                    break;
            }

            //设置排序方式
            var orderDirection = Request.Form["orderDirection"].FirstOrDefault();
            var orderBy = orderDirection switch
            {
                "asc" => OrderByType.Asc,
                "desc" => OrderByType.Desc,
                _ => OrderByType.Desc
            };
            //查询筛选

            //主键 int
            var id = Request.Form["id"].FirstOrDefault().ObjectToInt(0);
            if (id > 0) @where = @where.And(p => p.id == id);
            //用户id int
            var userId = Request.Form["userId"].FirstOrDefault().ObjectToInt(0);
            if (userId > 0) @where = @where.And(p => p.userId == userId);
            //操作模块 nvarchar
            var model = Request.Form["model"].FirstOrDefault();
            if (!string.IsNullOrEmpty(model)) @where = @where.And(p => p.model.Contains(model));
            //操作方法 nvarchar
            var description = Request.Form["description"].FirstOrDefault();
            if (!string.IsNullOrEmpty(description)) @where = @where.And(p => p.description.Contains(description));
            //请求地址 nvarchar
            var url = Request.Form["url"].FirstOrDefault();
            if (!string.IsNullOrEmpty(url)) @where = @where.And(p => p.url.Contains(url));
            //请求方式 nvarchar
            var requestMethod = Request.Form["requestMethod"].FirstOrDefault();
            if (!string.IsNullOrEmpty(requestMethod)) @where = @where.And(p => p.requestMethod.Contains(requestMethod));
            //调用方法 nvarchar
            var operMethod = Request.Form["operMethod"].FirstOrDefault();
            if (!string.IsNullOrEmpty(operMethod)) @where = @where.And(p => p.operMethod.Contains(operMethod));
            //请求参数 nvarchar
            var param = Request.Form["param"].FirstOrDefault();
            if (!string.IsNullOrEmpty(param)) @where = @where.And(p => p.param.Contains(param));
            //返回结果 nvarchar
            var result = Request.Form["result"].FirstOrDefault();
            if (!string.IsNullOrEmpty(result)) @where = @where.And(p => p.result.Contains(result));
            //ip地址 nvarchar
            var ip = Request.Form["ip"].FirstOrDefault();
            if (!string.IsNullOrEmpty(ip)) @where = @where.And(p => p.ip.Contains(ip));
            //请求耗时,单位毫秒 int
            var spendTime = Request.Form["spendTime"].FirstOrDefault().ObjectToInt(0);
            if (spendTime > 0) @where = @where.And(p => p.spendTime == spendTime);
            //状态,0成功,1异常 int
            var state = Request.Form["state"].FirstOrDefault().ObjectToInt(0);
            if (state > 0) @where = @where.And(p => p.state == state);
            //备注 nvarchar
            var comments = Request.Form["comments"].FirstOrDefault();
            if (!string.IsNullOrEmpty(comments)) @where = @where.And(p => p.comments.Contains(comments));
            //登录时间 datetime
            var createTime = Request.Form["createTime"].FirstOrDefault();
            if (!string.IsNullOrEmpty(createTime))
            {
                if (createTime.Contains("到"))
                {
                    var dts = createTime.Split("到");
                    var dtStart = dts[0].Trim().ObjectToDate();
                    where = where.And(p => p.createTime > dtStart);
                    var dtEnd = dts[1].Trim().ObjectToDate();
                    where = where.And(p => p.createTime < dtEnd);
                }
                else
                {
                    var dt = createTime.ObjectToDate();
                    where = where.And(p => p.createTime > dt);
                }
            }

            //修改时间 datetime
            var updateTime = Request.Form["updateTime"].FirstOrDefault();
            if (!string.IsNullOrEmpty(updateTime))
            {
                if (updateTime.Contains("到"))
                {
                    var dts = updateTime.Split("到");
                    var dtStart = dts[0].Trim().ObjectToDate();
                    where = where.And(p => p.updateTime > dtStart);
                    var dtEnd = dts[1].Trim().ObjectToDate();
                    where = where.And(p => p.updateTime < dtEnd);
                }
                else
                {
                    var dt = updateTime.ObjectToDate();
                    where = where.And(p => p.updateTime > dt);
                }
            }

            //获取数据
            var list = await _SysOperRecordServices.QueryPageAsync(where, orderEx, orderBy, pageCurrent, pageSize);
            //返回数据
            jm.data = list;
            jm.code = 0;
            jm.count = list.TotalCount;
            jm.msg = "数据调用成功!";
            return new JsonResult(jm);
        }

        #endregion

        #region 首页数据============================================================

        // POST: Api/SysOperRecord/GetIndex
        /// <summary>
        ///     首页数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("首页数据")]
        public JsonResult GetIndex()
        {
            //返回数据
            var jm = new AdminUiCallBack { code = 0 };
            return new JsonResult(jm);
        }

        #endregion

        #region 创建数据============================================================

        // POST: Api/SysOperRecord/GetCreate
        /// <summary>
        ///     创建数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("创建数据")]
        public JsonResult GetCreate()
        {
            //返回数据
            var jm = new AdminUiCallBack { code = 0 };
            return new JsonResult(jm);
        }

        #endregion

        #region 创建提交============================================================

        // POST: Api/SysOperRecord/DoCreate
        /// <summary>
        ///     创建提交
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("创建提交")]
        public async Task<JsonResult> DoCreate([FromBody] SysOperRecord entity)
        {
            var jm = new AdminUiCallBack();

            var bl = await _SysOperRecordServices.InsertAsync(entity) > 0;
            jm.code = bl ? 0 : 1;
            jm.msg = bl ? GlobalConstVars.CreateSuccess : GlobalConstVars.CreateFailure;

            return new JsonResult(jm);
        }

        #endregion

        #region 编辑数据============================================================

        // POST: Api/SysOperRecord/GetEdit
        /// <summary>
        ///     编辑数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("编辑数据")]
        public async Task<JsonResult> GetEdit([FromBody] FMIntId entity)
        {
            var jm = new AdminUiCallBack();

            var model = await _SysOperRecordServices.QueryByIdAsync(entity.id);
            if (model == null)
            {
                jm.msg = "不存在此信息";
                return new JsonResult(jm);
            }

            jm.code = 0;
            jm.data = model;

            return new JsonResult(jm);
        }

        #endregion

        #region 编辑提交============================================================

        // POST: Api/SysOperRecord/Edit
        /// <summary>
        ///     编辑提交
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("编辑提交")]
        public async Task<JsonResult> DoEdit([FromBody] SysOperRecord entity)
        {
            var jm = new AdminUiCallBack();

            var oldModel = await _SysOperRecordServices.QueryByIdAsync(entity.id);
            if (oldModel == null)
            {
                jm.msg = "不存在此信息";
                return new JsonResult(jm);
            }

            //事物处理过程开始
            oldModel.userId = entity.userId;
            oldModel.model = entity.model;
            oldModel.description = entity.description;
            oldModel.url = entity.url;
            oldModel.requestMethod = entity.requestMethod;
            oldModel.operMethod = entity.operMethod;
            oldModel.param = entity.param;
            oldModel.result = entity.result;
            oldModel.ip = entity.ip;
            oldModel.spendTime = entity.spendTime;
            oldModel.state = entity.state;
            oldModel.comments = entity.comments;
            oldModel.createTime = entity.createTime;
            oldModel.updateTime = entity.updateTime;

            //事物处理过程结束
            var bl = await _SysOperRecordServices.UpdateAsync(oldModel);
            jm.code = bl ? 0 : 1;
            jm.msg = bl ? GlobalConstVars.EditSuccess : GlobalConstVars.EditFailure;


            return new JsonResult(jm);
        }

        #endregion

        #region 删除数据============================================================

        // POST: Api/SysOperRecord/DoDelete/10
        /// <summary>
        ///     单选删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("单选删除")]
        public async Task<JsonResult> DoDelete([FromBody] FMIntId entity)
        {
            var jm = new AdminUiCallBack();

            var model = await _SysOperRecordServices.QueryByIdAsync(entity.id);
            if (model == null)
            {
                jm.msg = GlobalConstVars.DataisNo;
                return new JsonResult(jm);
            }

            var bl = await _SysOperRecordServices.DeleteByIdAsync(entity.id);
            jm.code = bl ? 0 : 1;
            jm.msg = bl ? GlobalConstVars.DeleteSuccess : GlobalConstVars.DeleteFailure;
            return new JsonResult(jm);

        }

        #endregion

        #region 批量删除============================================================

        // POST: Api/SysOperRecord/DoBatchDelete/10,11,20
        /// <summary>
        ///     批量删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("批量删除")]
        public async Task<JsonResult> DoBatchDelete([FromBody] FMArrayIntIds entity)
        {
            var jm = new AdminUiCallBack();

            var bl = await _SysOperRecordServices.DeleteByIdsAsync(entity.id);
            jm.code = bl ? 0 : 1;
            jm.msg = bl ? GlobalConstVars.DeleteSuccess : GlobalConstVars.DeleteFailure;

            return new JsonResult(jm);
        }

        #endregion

        #region 预览数据============================================================

        // POST: Api/SysOperRecord/GetDetails/10
        /// <summary>
        ///     预览数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("预览数据")]
        public async Task<JsonResult> GetDetails([FromBody] FMIntId entity)
        {
            var jm = new AdminUiCallBack();

            var model = await _SysOperRecordServices.QueryByIdAsync(entity.id);
            if (model == null)
            {
                jm.msg = "不存在此信息";
                return new JsonResult(jm);
            }

            jm.code = 0;
            jm.data = model;


            return new JsonResult(jm);
        }

        #endregion

        #region 选择导出============================================================

        // POST: Api/SysOperRecord/SelectExportExcel/10
        /// <summary>
        ///     选择导出
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("选择导出")]
        public async Task<JsonResult> SelectExportExcel([FromBody] FMArrayIntIds entity)
        {
            var jm = new AdminUiCallBack();

            //创建Excel文件的对象
            var book = new HSSFWorkbook();
            //添加一个sheet
            var sheet1 = book.CreateSheet("Sheet1");
            //获取list数据
            var listmodel = await _SysOperRecordServices.QueryListByClauseAsync(p => entity.id.Contains(p.id),
                p => p.id, OrderByType.Asc);
            //给sheet1添加第一行的头部标题
            var row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("主键");
            row1.CreateCell(1).SetCellValue("用户id");
            row1.CreateCell(2).SetCellValue("操作模块");
            row1.CreateCell(3).SetCellValue("操作方法");
            row1.CreateCell(4).SetCellValue("请求地址");
            row1.CreateCell(5).SetCellValue("请求方式");
            row1.CreateCell(6).SetCellValue("调用方法");
            row1.CreateCell(7).SetCellValue("请求参数");
            row1.CreateCell(8).SetCellValue("返回结果");
            row1.CreateCell(9).SetCellValue("ip地址");
            row1.CreateCell(10).SetCellValue("请求耗时,单位毫秒");
            row1.CreateCell(11).SetCellValue("状态,0成功,1异常");
            row1.CreateCell(12).SetCellValue("备注");
            row1.CreateCell(13).SetCellValue("登录时间");
            row1.CreateCell(14).SetCellValue("修改时间");

            //将数据逐步写入sheet1各个行
            for (var i = 0; i < listmodel.Count; i++)
            {
                var rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(listmodel[i].id.ToString());
                rowtemp.CreateCell(1).SetCellValue(listmodel[i].userId.ToString());
                rowtemp.CreateCell(2).SetCellValue(listmodel[i].model);
                rowtemp.CreateCell(3).SetCellValue(listmodel[i].description);
                rowtemp.CreateCell(4).SetCellValue(listmodel[i].url);
                rowtemp.CreateCell(5).SetCellValue(listmodel[i].requestMethod);
                rowtemp.CreateCell(6).SetCellValue(listmodel[i].operMethod);
                rowtemp.CreateCell(7).SetCellValue(listmodel[i].param);
                rowtemp.CreateCell(8).SetCellValue(listmodel[i].result);
                rowtemp.CreateCell(9).SetCellValue(listmodel[i].ip);
                rowtemp.CreateCell(10).SetCellValue(listmodel[i].spendTime.ToString());
                rowtemp.CreateCell(11).SetCellValue(listmodel[i].state.ToString());
                rowtemp.CreateCell(12).SetCellValue(listmodel[i].comments);
                rowtemp.CreateCell(13).SetCellValue(listmodel[i].createTime.ToString());
                rowtemp.CreateCell(14).SetCellValue(listmodel[i].updateTime.ToString());
            }

            // 导出excel
            var webRootPath = _webHostEnvironment.WebRootPath;
            var tpath = "/files/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";
            var fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "-SysOperRecord导出(选择结果).xls";
            var filePath = webRootPath + tpath;
            var di = new DirectoryInfo(filePath);
            if (!di.Exists) di.Create();
            var fileHssf = new FileStream(filePath + fileName, FileMode.Create);
            book.Write(fileHssf);
            fileHssf.Close();

            jm.code = 0;
            jm.msg = GlobalConstVars.ExcelExportSuccess;
            jm.data = tpath + fileName;


            return new JsonResult(jm);
        }

        #endregion

        #region 查询导出============================================================

        // POST: Api/SysOperRecord/QueryExportExcel/10
        /// <summary>
        ///     查询导出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("查询导出")]
        public async Task<JsonResult> QueryExportExcel()
        {
            var jm = new AdminUiCallBack();

            var where = PredicateBuilder.True<SysOperRecord>();
            //查询筛选

            //主键 int
            var id = Request.Form["id"].FirstOrDefault().ObjectToInt(0);
            if (id > 0) @where = @where.And(p => p.id == id);
            //用户id int
            var userId = Request.Form["userId"].FirstOrDefault().ObjectToInt(0);
            if (userId > 0) @where = @where.And(p => p.userId == userId);
            //操作模块 nvarchar
            var model = Request.Form["model"].FirstOrDefault();
            if (!string.IsNullOrEmpty(model)) @where = @where.And(p => p.model.Contains(model));
            //操作方法 nvarchar
            var description = Request.Form["description"].FirstOrDefault();
            if (!string.IsNullOrEmpty(description)) @where = @where.And(p => p.description.Contains(description));
            //请求地址 nvarchar
            var url = Request.Form["url"].FirstOrDefault();
            if (!string.IsNullOrEmpty(url)) @where = @where.And(p => p.url.Contains(url));
            //请求方式 nvarchar
            var requestMethod = Request.Form["requestMethod"].FirstOrDefault();
            if (!string.IsNullOrEmpty(requestMethod))
                @where = @where.And(p => p.requestMethod.Contains(requestMethod));
            //调用方法 nvarchar
            var operMethod = Request.Form["operMethod"].FirstOrDefault();
            if (!string.IsNullOrEmpty(operMethod)) @where = @where.And(p => p.operMethod.Contains(operMethod));
            //请求参数 nvarchar
            var param = Request.Form["param"].FirstOrDefault();
            if (!string.IsNullOrEmpty(param)) @where = @where.And(p => p.param.Contains(param));
            //返回结果 nvarchar
            var result = Request.Form["result"].FirstOrDefault();
            if (!string.IsNullOrEmpty(result)) @where = @where.And(p => p.result.Contains(result));
            //ip地址 nvarchar
            var ip = Request.Form["ip"].FirstOrDefault();
            if (!string.IsNullOrEmpty(ip)) @where = @where.And(p => p.ip.Contains(ip));
            //请求耗时,单位毫秒 int
            var spendTime = Request.Form["spendTime"].FirstOrDefault().ObjectToInt(0);
            if (spendTime > 0) @where = @where.And(p => p.spendTime == spendTime);
            //状态,0成功,1异常 int
            var state = Request.Form["state"].FirstOrDefault().ObjectToInt(0);
            if (state > 0) @where = @where.And(p => p.state == state);
            //备注 nvarchar
            var comments = Request.Form["comments"].FirstOrDefault();
            if (!string.IsNullOrEmpty(comments)) @where = @where.And(p => p.comments.Contains(comments));
            //登录时间 datetime
            var createTime = Request.Form["createTime"].FirstOrDefault();
            if (!string.IsNullOrEmpty(createTime))
            {
                var dt = createTime.ObjectToDate();
                where = where.And(p => p.createTime > dt);
            }

            //修改时间 datetime
            var updateTime = Request.Form["updateTime"].FirstOrDefault();
            if (!string.IsNullOrEmpty(updateTime))
            {
                var dt = updateTime.ObjectToDate();
                where = where.And(p => p.updateTime > dt);
            }

            //获取数据
            //创建Excel文件的对象
            var book = new HSSFWorkbook();
            //添加一个sheet
            var sheet1 = book.CreateSheet("Sheet1");
            //获取list数据
            var listmodel = await _SysOperRecordServices.QueryListByClauseAsync(where, p => p.id, OrderByType.Asc);
            //给sheet1添加第一行的头部标题
            var row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("主键");
            row1.CreateCell(1).SetCellValue("用户id");
            row1.CreateCell(2).SetCellValue("操作模块");
            row1.CreateCell(3).SetCellValue("操作方法");
            row1.CreateCell(4).SetCellValue("请求地址");
            row1.CreateCell(5).SetCellValue("请求方式");
            row1.CreateCell(6).SetCellValue("调用方法");
            row1.CreateCell(7).SetCellValue("请求参数");
            row1.CreateCell(8).SetCellValue("返回结果");
            row1.CreateCell(9).SetCellValue("ip地址");
            row1.CreateCell(10).SetCellValue("请求耗时,单位毫秒");
            row1.CreateCell(11).SetCellValue("状态,0成功,1异常");
            row1.CreateCell(12).SetCellValue("备注");
            row1.CreateCell(13).SetCellValue("登录时间");
            row1.CreateCell(14).SetCellValue("修改时间");

            //将数据逐步写入sheet1各个行
            for (var i = 0; i < listmodel.Count; i++)
            {
                var rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(listmodel[i].id.ToString());
                rowtemp.CreateCell(1).SetCellValue(listmodel[i].userId.ToString());
                rowtemp.CreateCell(2).SetCellValue(listmodel[i].model);
                rowtemp.CreateCell(3).SetCellValue(listmodel[i].description);
                rowtemp.CreateCell(4).SetCellValue(listmodel[i].url);
                rowtemp.CreateCell(5).SetCellValue(listmodel[i].requestMethod);
                rowtemp.CreateCell(6).SetCellValue(listmodel[i].operMethod);
                rowtemp.CreateCell(7).SetCellValue(listmodel[i].param);
                rowtemp.CreateCell(8).SetCellValue(listmodel[i].result);
                rowtemp.CreateCell(9).SetCellValue(listmodel[i].ip);
                rowtemp.CreateCell(10).SetCellValue(listmodel[i].spendTime.ToString());
                rowtemp.CreateCell(11).SetCellValue(listmodel[i].state.ToString());
                rowtemp.CreateCell(12).SetCellValue(listmodel[i].comments);
                rowtemp.CreateCell(13).SetCellValue(listmodel[i].createTime.ToString());
                rowtemp.CreateCell(14).SetCellValue(listmodel[i].updateTime.ToString());
            }

            // 写入到excel
            var webRootPath = _webHostEnvironment.WebRootPath;
            var tpath = "/files/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";
            var fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "-SysOperRecord导出(查询结果).xls";
            var filePath = webRootPath + tpath;
            var di = new DirectoryInfo(filePath);
            if (!di.Exists) di.Create();
            var fileHssf = new FileStream(filePath + fileName, FileMode.Create);
            book.Write(fileHssf);
            fileHssf.Close();

            jm.code = 0;
            jm.msg = GlobalConstVars.ExcelExportSuccess;
            jm.data = tpath + fileName;

            return new JsonResult(jm);
        }

        #endregion
    }
}