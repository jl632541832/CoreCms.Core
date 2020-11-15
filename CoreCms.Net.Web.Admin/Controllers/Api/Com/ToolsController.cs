using Aliyun.OSS;
using Aliyun.OSS.Util;
using CoreCms.Net.Auth.HttpContextUser;
using CoreCms.Net.CodeGenerator.Services;
using CoreCms.Net.Configuration;
using CoreCms.Net.Filter;
using CoreCms.Net.IServices;
using CoreCms.Net.Loging;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.Entities.Expression;
using CoreCms.Net.Model.FromBody;
using CoreCms.Net.Model.ViewModels.Echarts;
using CoreCms.Net.Model.ViewModels.Options;
using CoreCms.Net.Model.ViewModels.UI;
using CoreCms.Net.Model.ViewModels.View;
using CoreCms.Net.Utility.Extensions;
using CoreCms.Net.Utility.Helper;
using COSXML;
using COSXML.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCms.Net.Web.Admin.Controllers
{
    /// <summary>
    ///     后端常用方法
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ToolsController : ControllerBase
    {
        private readonly ICodeGeneratorServices _codeGeneratorServices;

        private readonly ISysMenuServices _sysMenuServices;
        private readonly ISysOrganizationServices _sysOrganizationServices;
        private readonly ISysRoleServices _sysRoleServices;
        private readonly ISysUserRoleServices _sysUserRoleServices;

        private readonly ISysRoleMenuServices _sysRoleMenuServices;

        private readonly ISysUserServices _sysUserServices;
        private readonly IHttpContextUser _user;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ISysLoginRecordServices _sysLoginRecordServices;
        private readonly ISysNLogRecordsServices _sysNLogRecordsServices;

        private readonly FilesStorageOptions _filesStorageOptions;

        /// <summary>
        ///     构造函数
        /// </summary>
        public ToolsController(
            IHttpContextUser user
            , IWebHostEnvironment webHostEnvironment
                        , ISysUserServices sysUserServices
            , ISysRoleServices sysRoleServices
            , ISysMenuServices sysMenuServices
            , ISysUserRoleServices sysUserRoleServices
            , ISysOrganizationServices sysOrganizationServices, ICodeGeneratorServices codeGeneratorServices,
            ISysLoginRecordServices sysLoginRecordServices, ISysNLogRecordsServices sysNLogRecordsServices, IOptions<FilesStorageOptions> filesStorageOptions, ISysRoleMenuServices sysRoleMenuServices)
        {
            _user = user;
            _webHostEnvironment = webHostEnvironment;
            _sysUserServices = sysUserServices;
            _sysRoleServices = sysRoleServices;
            _sysMenuServices = sysMenuServices;
            _sysUserRoleServices = sysUserRoleServices;
            _sysOrganizationServices = sysOrganizationServices;
            _codeGeneratorServices = codeGeneratorServices;
            _sysLoginRecordServices = sysLoginRecordServices;
            _sysNLogRecordsServices = sysNLogRecordsServices;
            _sysRoleMenuServices = sysRoleMenuServices;
            _filesStorageOptions = filesStorageOptions.Value;
        }

        #region 获取登录用户用户信息(用于面板展示)====================================================

        /// <summary>
        ///     获取登录用户用户信息(用于面板展示)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> GetUserInfo()
        {
            var jm = new AdminUiCallBack();
            var userModel = await _sysUserServices.QueryByIdAsync(_user.ID);
            jm.code = 0;
            jm.msg = "数据获取正常";
            jm.data = new
            {
                userModel.userName,
                userModel.nickName,
                userModel.createTime
            };
            return new JsonResult(jm);
        }

        #endregion 获取登录用户用户信息(用于面板展示)====================================================

        #region 获取登录用户用户全部信息(用于编辑个人信息)====================================================

        /// <summary>
        ///     获取登录用户用户全部信息(用于编辑个人信息)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> GetEditUserInfo()
        {
            var jm = new AdminUiCallBack();
            var userModel = await _sysUserServices.QueryByIdAsync(_user.ID);

            if (userModel != null)
            {
                var roles = await _sysUserRoleServices.QueryListByClauseAsync(p => p.userId == userModel.id);
                if (roles.Any())
                {
                    var roleIds = roles.Select(p => p.roleId).ToList();
                    userModel.roles = await _sysRoleServices.QueryListByClauseAsync(p => roleIds.Contains(p.id));
                }

                if (userModel.organizationId != null && userModel.organizationId > 0)
                {
                    var organization = await _sysOrganizationServices.QueryByIdAsync(userModel.organizationId);
                    if (organization != null) userModel.organizationName = organization.organizationName;
                }
            }

            jm.code = 0;
            jm.msg = "数据获取正常";
            jm.data = userModel;
            return new JsonResult(jm);
        }

        #endregion 获取登录用户用户全部信息(用于编辑个人信息)====================================================

        #region 获取角色列表信息====================================================

        /// <summary>
        ///     获取角色列表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> GetManagerRoles()
        {
            var jm = new AdminUiCallBack();
            var roles = await _sysRoleServices.QueryAsync();
            jm.code = 0;
            jm.msg = "数据获取正常";
            jm.data = roles.Select(p => new { title = p.roleName, value = p.id });
            return new JsonResult(jm);
        }

        #endregion 获取角色列表信息====================================================

        #region 用户编辑个人登录账户密码====================================================

        /// <summary>
        ///     获取登录用户用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> EditLoginUserPassWord([FromBody] FMEditLoginUserPassWord entity)
        {
            var jm = new AdminUiCallBack();

            if (string.IsNullOrEmpty(entity.oldPassword))
            {
                jm.msg = "请键入旧密码";
                return new JsonResult(jm);
            }

            if (string.IsNullOrEmpty(entity.password))
            {
                jm.msg = "请键入新密码";
                return new JsonResult(jm);
            }

            if (string.IsNullOrEmpty(entity.repassword))
            {
                jm.msg = "请键入新密码确认密码";
                return new JsonResult(jm);
            }

            if (entity.password != entity.repassword)
            {
                jm.msg = "新密码与确认密码不相符";
                return new JsonResult(jm);
            }

            if (CommonHelper.Md5For32(entity.oldPassword) == CommonHelper.Md5For32(entity.password))
            {
                jm.msg = "新密码与旧密码相同,无需修改";
                return new JsonResult(jm);
            }

            var userModel = await _sysUserServices.QueryByIdAsync(_user.ID);

            if (userModel.passWord != CommonHelper.Md5For32(entity.oldPassword))
            {
                jm.msg = "旧密码输入错误";
                return new JsonResult(jm);
            }

            userModel.passWord = CommonHelper.Md5For32(entity.password);
            var bl = await _sysUserServices.UpdateAsync(userModel);

            jm.code = bl ? 0 : 1;
            jm.msg = bl ? "修改成功" : "修改失败";
            return new JsonResult(jm);
        }

        #endregion 用户编辑个人登录账户密码====================================================

        #region 用户编辑个人非安全隐私数据====================================================

        /// <summary>
        ///     用户编辑个人非安全隐私数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> EditLoginUserInfo([FromBody] EditLoginUserInfo entity)
        {
            var jm = new AdminUiCallBack();

            var userModel = await _sysUserServices.QueryByIdAsync(_user.ID);

            if (!string.IsNullOrEmpty(entity.nickName)) userModel.nickName = entity.nickName;
            if (!string.IsNullOrEmpty(entity.avatar)) userModel.avatar = entity.avatar;
            if (entity.sex > 0) userModel.sex = entity.sex;
            if (!string.IsNullOrEmpty(entity.phone)) userModel.phone = entity.phone;
            if (!string.IsNullOrEmpty(entity.email)) userModel.email = entity.email;
            if (!string.IsNullOrEmpty(entity.introduction)) userModel.introduction = entity.introduction;

            if (!string.IsNullOrEmpty(entity.trueName)) userModel.trueName = entity.trueName;
            if (!string.IsNullOrEmpty(entity.idCard)) userModel.idCard = entity.idCard;
            if (entity.birthday != null) userModel.birthday = entity.birthday;

            userModel.updateTime = DateTime.Now;
            var bl = await _sysUserServices.UpdateAsync(userModel);

            jm.code = bl ? 0 : 1;
            jm.msg = bl ? "修改成功" : "修改失败";
            return new JsonResult(jm);
        }

        #endregion 用户编辑个人非安全隐私数据====================================================

        #region 反射获取后端Api的controller和action

        /// <summary>
        ///     反射获取后端Api的controller和action
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetAllControllerAndActionByAssembly()
        {
            var jm = new AdminUiCallBack();
            var data = AdminsControllerPermission.GetAllControllerAndActionByAssembly();
            jm.data = data.OrderBy(u => u.name).ToList();
            jm.code = 0;
            jm.msg = "获取成功";
            return new JsonResult(jm);
        }

        #endregion 反射获取后端Api的controller和action

        //通用操作=========================================================================

        #region 通用上传接口====================================================

        /// <summary>
        ///     通用上传接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> UploadFiles()
        {
            var jm = new AdminUiCallBack();
            try
            {
                //初始化上传参数
                var maxSize = 1024 * 1024 * _filesStorageOptions.MaxSize; //上传大小5M

                var file = Request.Form.Files["file"];
                if (file == null)
                {
                    jm.msg = "请选择文件";
                    return new JsonResult(jm);
                }

                var fileName = file.FileName;
                var fileExt = Path.GetExtension(fileName).ToLowerInvariant();

                //检查大小
                if (file.Length > maxSize)
                {
                    jm.msg = "上传文件大小超过限制，最大允许上传" + _filesStorageOptions.MaxSize + "M";
                    return new JsonResult(jm);
                }

                //检查文件扩展名
                if (string.IsNullOrEmpty(fileExt) ||
                    Array.IndexOf(_filesStorageOptions.FileTypes.Split(','), fileExt.Substring(1).ToLower()) == -1)
                {
                    jm.msg = "上传文件扩展名是不允许的扩展名,请上传后缀名为：" + _filesStorageOptions.FileTypes;
                    return new JsonResult(jm);
                }

                var newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
                var today = DateTime.Now.ToString("yyyyMMdd");

                if (_filesStorageOptions.StorageType == GlobalEnumVars.FilesStorageOptionsType.LocalStorage.ToString())
                {
                    var saveUrl = "/upload/" + today + "/";
                    var dirPath = _webHostEnvironment.WebRootPath + saveUrl;
                    if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
                    var filePath = dirPath + newFileName;
                    var fileUrl = saveUrl + newFileName;

                    string bucketBindDomain = AppSettingsHelper.GetContent("AppConfig", "AppUrl");

                    await using (var fs = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(fs);
                        fs.Flush();
                    }

                    jm.code = 0;
                    jm.msg = "上传成功!";
                    jm.data = new
                    {
                        fileUrl,
                        src = bucketBindDomain + fileUrl
                    };
                }
                else if (_filesStorageOptions.StorageType == GlobalEnumVars.FilesStorageOptionsType.AliYunOSS.ToString())
                {
                    //上传到阿里云
                    await using (var fileStream = file.OpenReadStream()) //转成Stream流
                    {
                        var md5 = OssUtils.ComputeContentMd5(fileStream, file.Length);

                        var filePath = "Upload/" + today + "/" + newFileName; //云文件保存路径
                        //初始化阿里云配置--外网Endpoint、访问ID、访问password
                        var aliyun = new OssClient(_filesStorageOptions.Endpoint, _filesStorageOptions.AccessKeyId, _filesStorageOptions.AccessKeySecret);
                        //将文件md5值赋值给meat头信息，服务器验证文件MD5
                        var objectMeta = new ObjectMetadata
                        {
                            ContentMd5 = md5
                        };
                        //文件上传--空间名、文件保存路径、文件流、meta头信息(文件md5) //返回meta头信息(文件md5)
                        aliyun.PutObject(_filesStorageOptions.BucketName, filePath, fileStream, objectMeta);
                        //返回给UEditor的插入编辑器的图片的src
                        jm.code = 0;
                        jm.msg = "上传成功";
                        jm.data = new
                        {
                            fileUrl = _filesStorageOptions.BucketBindUrl + filePath,
                            src = _filesStorageOptions.BucketBindUrl + filePath
                        };
                    }
                }
                else if (_filesStorageOptions.StorageType == GlobalEnumVars.FilesStorageOptionsType.QCloudOSS.ToString())
                {
                    var filePath = "Upload/" + today + "/" + newFileName; //云文件保存路径

                    //上传到腾讯云OSS
                    //初始化 CosXmlConfig
                    string appid = _filesStorageOptions.AccountId;//设置腾讯云账户的账户标识 APPID
                    string region = _filesStorageOptions.CosRegion; //设置一个默认的存储桶地域
                    CosXmlConfig config = new CosXmlConfig.Builder()
                        .IsHttps(true)  //设置默认 HTTPS 请求
                        .SetRegion(region)  //设置一个默认的存储桶地域
                        .SetDebugLog(true)  //显示日志
                        .Build();  //创建 CosXmlConfig 对象

                    long durationSecond = 600;  //每次请求签名有效时长，单位为秒
                    QCloudCredentialProvider qCloudCredentialProvider = new DefaultQCloudCredentialProvider(_filesStorageOptions.AccessKeyId, _filesStorageOptions.AccessKeySecret, durationSecond);

                    byte[] bytes;
                    await using (var ms = new MemoryStream())
                    {
                        await file.CopyToAsync(ms);
                        bytes = ms.ToArray();
                    }

                    var cosXml = new CosXmlServer(config, qCloudCredentialProvider);
                    COSXML.Model.Object.PutObjectRequest putObjectRequest = new COSXML.Model.Object.PutObjectRequest(_filesStorageOptions.BucketName, filePath, bytes);
                    cosXml.PutObject(putObjectRequest);

                    jm.code = 0;
                    jm.msg = "上传成功";
                    jm.data = new
                    {
                        fileUrl = _filesStorageOptions.BucketBindUrl + filePath,
                        src = _filesStorageOptions.BucketBindUrl + filePath
                    };
                }
            }
            catch (Exception e)
            {
                jm.code = 1;
                jm.msg = "上传异常错误";
                jm.data = e.ToString();
            }

            return new JsonResult(jm);
        }

        #endregion 通用上传接口====================================================

        #region 裁剪Base64上传====================================================

        /// <summary>
        ///     裁剪Base64上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> UploadFilesFByBase64([FromBody] FMBase64Post entity)
        {
            var jm = new AdminUiCallBack();
            try
            {
                if (string.IsNullOrEmpty(entity.base64))
                {
                    jm.msg = "请上传合法内容";
                    return new JsonResult(jm);
                }

                entity.base64 = entity.base64.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "").Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");//将base64头部信息替换
                byte[] bytes = Convert.FromBase64String(entity.base64);
                MemoryStream memStream = new MemoryStream(bytes);

                Image mImage = Image.FromStream(memStream);
                Bitmap bp = new Bitmap(mImage);

                var newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + ".jpg";
                var today = DateTime.Now.ToString("yyyyMMdd");

                if (_filesStorageOptions.StorageType == GlobalEnumVars.FilesStorageOptionsType.LocalStorage.ToString())
                {
                    var saveUrl = "/upload/" + today + "/";
                    var dirPath = _webHostEnvironment.WebRootPath + saveUrl;
                    string bucketBindDomain = AppSettingsHelper.GetContent("AppConfig", "AppUrl");

                    if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
                    var filePath = dirPath + newFileName;
                    var fileUrl = saveUrl + newFileName;

                    bp.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);//注意保存路径

                    jm.code = 0;
                    jm.msg = "上传成功!";
                    jm.data = new
                    {
                        fileUrl,
                        src = bucketBindDomain + fileUrl
                    };
                    jm.otherData = GlobalEnumVars.FilesStorageOptionsType.LocalStorage.ToString();
                }
                else if (_filesStorageOptions.StorageType == GlobalEnumVars.FilesStorageOptionsType.AliYunOSS.ToString())
                {
                    //上传到阿里云

                    // 设置当前流的位置为流的开始
                    memStream.Seek(0, SeekOrigin.Begin);

                    await using (var fileStream = memStream) //转成Stream流
                    {
                        var md5 = OssUtils.ComputeContentMd5(fileStream, memStream.Length);

                        var filePath = "Upload/" + today + "/" + newFileName; //云文件保存路径
                        //初始化阿里云配置--外网Endpoint、访问ID、访问password
                        var aliyun = new OssClient(_filesStorageOptions.Endpoint, _filesStorageOptions.AccessKeyId, _filesStorageOptions.AccessKeySecret);
                        //将文件md5值赋值给meat头信息，服务器验证文件MD5
                        var objectMeta = new ObjectMetadata
                        {
                            ContentMd5 = md5
                        };
                        //文件上传--空间名、文件保存路径、文件流、meta头信息(文件md5) //返回meta头信息(文件md5)
                        aliyun.PutObject(_filesStorageOptions.BucketName, filePath, fileStream, objectMeta);
                        //返回给UEditor的插入编辑器的图片的src
                        jm.code = 0;
                        jm.msg = "上传成功";
                        jm.data = new
                        {
                            fileUrl = _filesStorageOptions.BucketBindUrl + filePath,
                            src = _filesStorageOptions.BucketBindUrl + filePath
                        };
                    }
                    jm.otherData = GlobalEnumVars.FilesStorageOptionsType.AliYunOSS.ToString();
                }
                else if (_filesStorageOptions.StorageType == GlobalEnumVars.FilesStorageOptionsType.QCloudOSS.ToString())
                {
                    //上传到腾讯云OSS
                    //初始化 CosXmlConfig
                    string appid = _filesStorageOptions.AccountId;//设置腾讯云账户的账户标识 APPID
                    string region = _filesStorageOptions.CosRegion; //设置一个默认的存储桶地域
                    CosXmlConfig config = new CosXmlConfig.Builder()
                        .IsHttps(true)  //设置默认 HTTPS 请求
                        .SetRegion(region)  //设置一个默认的存储桶地域
                        .SetDebugLog(true)  //显示日志
                        .Build();  //创建 CosXmlConfig 对象

                    long durationSecond = 600;  //每次请求签名有效时长，单位为秒
                    QCloudCredentialProvider qCloudCredentialProvider = new DefaultQCloudCredentialProvider(
                        _filesStorageOptions.AccessKeyId, _filesStorageOptions.AccessKeySecret, durationSecond);

                    var cosXml = new CosXmlServer(config, qCloudCredentialProvider);

                    var filePath = "Upload/" + today + "/" + newFileName; //云文件保存路径
                    COSXML.Model.Object.PutObjectRequest putObjectRequest = new COSXML.Model.Object.PutObjectRequest(_filesStorageOptions.BucketName, filePath, bytes);

                    cosXml.PutObject(putObjectRequest);

                    jm.code = 0;
                    jm.msg = "上传成功";
                    jm.data = new
                    {
                        fileUrl = _filesStorageOptions.BucketBindUrl + filePath,
                        src = _filesStorageOptions.BucketBindUrl + filePath
                    };
                }
            }
            catch (Exception e)
            {
                jm.code = 1;
                jm.msg = "上传异常错误";
                jm.data = e.ToString();
            }

            return new JsonResult(jm);
        }

        #endregion 裁剪Base64上传====================================================

        #region CKEditor编辑上传接口====================================================

        /// <summary>
        ///     CKEditor编辑上传接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CkEditorUploadFiles()
        {
            var jm = new CKEditorUploadedResult();
            try
            {
                //初始化上传参数
                var maxSize = 1024 * 1024 * _filesStorageOptions.MaxSize; //上传大小5M

                var file = Request.Form.Files["upload"];
                if (file == null)
                {
                    jm.error.message = "请选择文件";
                    return new JsonResult(jm);
                }

                var fileName = file.FileName;
                var fileExt = Path.GetExtension(fileName).ToLowerInvariant();

                //检查大小
                if (file.Length > maxSize)
                {
                    jm.error.message = "上传文件大小超过限制，最大允许上传" + _filesStorageOptions.MaxSize + "M";
                    return new JsonResult(jm);
                }

                //检查文件扩展名
                if (string.IsNullOrEmpty(fileExt) ||
                    Array.IndexOf(_filesStorageOptions.FileTypes.Split(','), fileExt.Substring(1).ToLower()) == -1)
                {
                    jm.error.message = "上传文件扩展名是不允许的扩展名,请上传后缀名为：" + _filesStorageOptions.FileTypes;
                    return new JsonResult(jm);
                }

                var newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
                var today = DateTime.Now.ToString("yyyyMMdd");

                if (_filesStorageOptions.StorageType == GlobalEnumVars.FilesStorageOptionsType.LocalStorage.ToString())
                {
                    var saveUrl = "/upload/" + today + "/";
                    var dirPath = _webHostEnvironment.WebRootPath + saveUrl;
                    if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
                    var filePath = dirPath + newFileName;
                    var fileUrl = saveUrl + newFileName;

                    string bucketBindDomain = AppSettingsHelper.GetContent("AppConfig", "AppUrl");

                    await using (var fs = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(fs);
                        fs.Flush();
                    }

                    jm.uploaded = 1;
                    jm.fileName = fileName;
                    jm.url = bucketBindDomain + fileUrl;
                }
                else if (_filesStorageOptions.StorageType == GlobalEnumVars.FilesStorageOptionsType.AliYunOSS.ToString())
                {
                    //上传到阿里云
                    await using (var fileStream = file.OpenReadStream()) //转成Stream流
                    {
                        var md5 = OssUtils.ComputeContentMd5(fileStream, file.Length);

                        var filePath = "Upload/" + today + "/" + newFileName; //云文件保存路径
                        //初始化阿里云配置--外网Endpoint、访问ID、访问password
                        var aliyun = new OssClient(_filesStorageOptions.Endpoint, _filesStorageOptions.AccessKeyId, _filesStorageOptions.AccessKeySecret);
                        //将文件md5值赋值给meat头信息，服务器验证文件MD5
                        var objectMeta = new ObjectMetadata
                        {
                            ContentMd5 = md5
                        };
                        //文件上传--空间名、文件保存路径、文件流、meta头信息(文件md5) //返回meta头信息(文件md5)
                        aliyun.PutObject(_filesStorageOptions.BucketName, filePath, fileStream, objectMeta);
                        //返回给UEditor的插入编辑器的图片的src

                        jm.uploaded = 1;
                        jm.fileName = fileName;
                        jm.url = _filesStorageOptions.BucketBindUrl + filePath;
                    }
                }
                else if (_filesStorageOptions.StorageType == GlobalEnumVars.FilesStorageOptionsType.QCloudOSS.ToString())
                {
                    var filePath = "Upload/" + today + "/" + newFileName; //云文件保存路径

                    //上传到腾讯云OSS
                    //初始化 CosXmlConfig
                    string appid = _filesStorageOptions.AccountId;//设置腾讯云账户的账户标识 APPID
                    string region = _filesStorageOptions.CosRegion; //设置一个默认的存储桶地域
                    CosXmlConfig config = new CosXmlConfig.Builder()
                        .IsHttps(true)  //设置默认 HTTPS 请求
                        .SetRegion(region)  //设置一个默认的存储桶地域
                        .SetDebugLog(true)  //显示日志
                        .Build();  //创建 CosXmlConfig 对象

                    long durationSecond = 600;  //每次请求签名有效时长，单位为秒
                    QCloudCredentialProvider qCloudCredentialProvider = new DefaultQCloudCredentialProvider(_filesStorageOptions.AccessKeyId, _filesStorageOptions.AccessKeySecret, durationSecond);

                    byte[] bytes;
                    await using (var ms = new MemoryStream())
                    {
                        await file.CopyToAsync(ms);
                        bytes = ms.ToArray();
                    }

                    var cosXml = new CosXmlServer(config, qCloudCredentialProvider);
                    COSXML.Model.Object.PutObjectRequest putObjectRequest = new COSXML.Model.Object.PutObjectRequest(_filesStorageOptions.BucketName, filePath, bytes);
                    cosXml.PutObject(putObjectRequest);

                    jm.uploaded = 1;
                    jm.fileName = fileName;
                    jm.url = _filesStorageOptions.BucketBindUrl + filePath;
                }
            }
            catch (Exception e)
            {
                jm.uploaded = 0;
                jm.error.message = "上传异常错误";
                jm.otherData = e;
            }
            return new JsonResult(jm);
        }

        #endregion CKEditor编辑上传接口====================================================

        //通用页面获取=========================================================================

        //用户相关=========================================================================

        #region 根据用户权限获取对应左侧菜单列表====================================================

        /// <summary>
        ///     根据用户权限获取对应左侧菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> GetNavs()
        {
            var jm = new AdminUiCallBack();

            //先获取用户关联角色
            var roles = await _sysUserRoleServices.QueryListByClauseAsync(p => p.userId == _user.ID);
            if (roles.Any())
            {
                var roleIds = roles.Select(p => p.roleId).ToList();
                var sysRoleMenu = await _sysRoleMenuServices.QueryListByClauseAsync(p => roleIds.Contains(p.roleId));

                var menuIds = sysRoleMenu.Select(p => p.menuId).ToList();

                var where = PredicateBuilder.True<SysMenu>();
                where = where.And(p => p.deleted == false && p.hide == false && p.menuType == 0);
                where = where.And(p => menuIds.Contains(p.id));

                var navs = await _sysMenuServices.QueryListByClauseAsync(where, p => p.sortNumber, OrderByType.Asc);
                var menus = GetMenus(navs, 0);

                jm.data = menus;
            }

            jm.msg = "数据获取正常";
            jm.code = 0;

            return new JsonResult(jm);
        }

        /// <summary>
        ///     迭代方法
        /// </summary>
        /// <param name="oldNavs"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        private static List<AdminUiMenu> GetMenus(List<SysMenu> oldNavs, int parentId)
        {
            var childTree = new List<AdminUiMenu>();
            if (parentId == 0)
            {
                var topMenu = new AdminUiMenu { title = "主页", icon = "layui-icon-home", name = "HomePanel" };
                var list = new List<AdminUiMenu>
                {
                    new AdminUiMenu
                        {title = "控制台", jump = "/", name = "controllerPanel", list = new List<AdminUiMenu>()}
                };
                topMenu.list = list;
                childTree.Add(topMenu);
            }

            var model = oldNavs.Where(p => p.parentId == parentId).ToList();
            foreach (var item in model)
            {
                var menu = new AdminUiMenu
                {
                    name = item.identificationCode,
                    title = item.menuName,
                    icon = item.menuIcon,
                    jump = !string.IsNullOrEmpty(item.path) ? item.path : null
                };
                childTree.Add(menu);
                menu.list = GetMenus(oldNavs, item.id);
            }

            return childTree;
        }

        #endregion 根据用户权限获取对应左侧菜单列表====================================================


        //后端首页使用数据

        #region 获取最近登录日志============================================================

        // POST: Api/Tools/GetSysLoginRecord
        /// <summary>
        ///     获取最近登录日志
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("获取最近登录日志")]
        public async Task<JsonResult> GetSysLoginRecord()
        {
            var jm = new AdminUiCallBack();

            //获取数据
            var list = await _sysLoginRecordServices.QueryPageAsync(p => p.id > 0, p => p.createTime, OrderByType.Desc, 1, 10);
            //返回数据
            jm.data = list;
            jm.code = 0;
            jm.count = list.TotalCount;
            jm.msg = "数据调用成功!";
            return new JsonResult(jm);
        }

        #endregion 获取最近登录日志============================================================

        #region 获取全局Nlog日志============================================================

        // POST: Api/Tools/GetSysNLogRecords
        /// <summary>
        ///     获取全局Nlog日志
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("获取全局Nlog日志")]
        public async Task<JsonResult> GetSysNLogRecords()
        {
            var jm = new AdminUiCallBack();
            //获取数据
            var list = await _sysNLogRecordsServices.QueryPageAsync(p => p.id > 0, p => p.id, OrderByType.Desc, 1, 10);
            //返回数据
            jm.data = list;
            jm.code = 0;
            jm.count = list.TotalCount;
            jm.msg = "数据调用成功!";
            return new JsonResult(jm);
        }

        #endregion 获取全局Nlog日志============================================================
    }
}