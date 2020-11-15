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
    /// Nlog记录表 接口实现
    /// </summary>
    public class SysNLogRecordsRepository : BaseRepository<SysNLogRecords>, ISysNLogRecordsRepository
    {
        public SysNLogRecordsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

       #region 实现重写增删改查操作==========================================================

        ///// <summary>
        ///// 重写异步插入方法
        ///// </summary>
        ///// <param name="entity">实体数据</param>
        ///// <returns></returns>
        //public new async Task<AdminUiCallBack> InsertAsync(SysNLogRecords entity)
        //{
        //    var jm = new AdminUiCallBack();
        //    try
        //    {
        //        dbClient.Ado.BeginTran();
        //        var bl = await dbClient.Insertable(entity).ExecuteReturnIdentityAsync() > 0;
        //        jm.code = bl ? 0 : 1;
        //        jm.msg = bl ? GlobalConstVars.CreateSuccess : GlobalConstVars.CreateFailure;
        //        dbClient.Ado.CommitTran();
        //    }
        //    catch (Exception ex)
        //    {
        //        dbClient.Ado.RollbackTran();
        //        jm.msg = GlobalConstVars.CreateFailure;
        //        jm.data = ex.ToString();
        //    }
        //    return jm;
        //}

        ///// <summary>
        ///// 重写异步更新方法方法
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public new async Task<AdminUiCallBack> UpdateAsync(SysNLogRecords entity)
        //{
        //    var jm = new AdminUiCallBack();
        //    try
        //    {
        //         dbClient.Ado.BeginTran();
        //         var oldModel = await dbClient.Queryable<SysNLogRecords>().In(entity.id).SingleAsync();
        //         if (oldModel == null)
        //         {
        //            jm.msg = "不存在此信息";
        //            return jm;
        //         }
        //         //事物处理过程开始
        //		  oldModel.id = entity.id;
        //        oldModel.LogDate = entity.LogDate;
        //        oldModel.LogLevel = entity.LogLevel;
        //        oldModel.LogType = entity.LogType;
        //        oldModel.Logger = entity.Logger;
        //        oldModel.Message = entity.Message;
        //        oldModel.MachineName = entity.MachineName;
        //        oldModel.MachineIp = entity.MachineIp;
        //        oldModel.NetRequestMethod = entity.NetRequestMethod;
        //        oldModel.NetRequestUrl = entity.NetRequestUrl;
        //        oldModel.NetUserIsauthenticated = entity.NetUserIsauthenticated;
        //        oldModel.NetUserAuthtype = entity.NetUserAuthtype;
        //        oldModel.NetUserIdentity = entity.NetUserIdentity;
        //        oldModel.Exception = entity.Exception;
        //        
        //        //事物处理过程结束
        //        var bl = await dbClient.Updateable(entity).ExecuteCommandHasChangeAsync();
        //        jm.code = bl ? 0 : 1;
        //        jm.msg = bl ? GlobalConstVars.EditSuccess : GlobalConstVars.EditFailure;
        //        dbClient.Ado.CommitTran();
        //    }
        //    catch (Exception ex)
        //    {
        //        dbClient.Ado.RollbackTran();
        //        jm.msg = GlobalConstVars.EditFailure;
        //        jm.data = ex.ToString();
        //    }
        //    return jm;
        //}

        ///// <summary>
        ///// 重写异步更新方法方法
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public new async Task<AdminUiCallBack> UpdateAsync(List<SysNLogRecords> entity)
        //{
        //    var jm = new AdminUiCallBack();
        //    try
        //    {
        //        dbClient.Ado.BeginTran();
        //        var bl = await dbClient.Updateable(entity).ExecuteCommandHasChangeAsync();
        //        jm.code = bl ? 0 : 1;
        //        jm.msg = bl ? GlobalConstVars.EditSuccess : GlobalConstVars.EditFailure;
        //        dbClient.Ado.CommitTran();
        //    }
        //    catch (Exception ex)
        //    {
        //        dbClient.Ado.RollbackTran();
        //        jm.msg = GlobalConstVars.EditFailure;
        //        jm.data = ex.ToString();
        //    }
        //    return jm;
        //}

        ///// <summary>
        ///// 重写删除指定ID的数据
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public new async Task<AdminUiCallBack> DeleteByIdAsync(object id)
        //{
        //    var jm = new AdminUiCallBack();
        //    try
        //    {
        //        dbClient.Ado.BeginTran();
        //        var bl = await dbClient.Deleteable<SysNLogRecords>(id).ExecuteCommandHasChangeAsync();
        //        jm.code = bl ? 0 : 1;
        //        jm.msg = bl ? GlobalConstVars.DeleteSuccess : GlobalConstVars.DeleteFailure;

        //        dbClient.Ado.CommitTran();
        //    }
        //    catch (Exception ex)
        //    {
        //        dbClient.Ado.RollbackTran();
        //        jm.msg = GlobalConstVars.DeleteFailure;
        //        jm.data = ex.ToString();
        //    }
        //    return jm;
        //}

        ///// <summary>
        ///// 重写删除指定ID集合的数据(批量删除)
        ///// </summary>
        ///// <param name="ids"></param>
        ///// <returns></returns>
        //public new async Task<AdminUiCallBack> DeleteByIdsAsync(int[] ids)
        //{
        //    var jm = new AdminUiCallBack();
        //    try
        //    {
        //        dbClient.Ado.BeginTran();
        //        var bl = await dbClient.Deleteable<SysNLogRecords>().In(ids).ExecuteCommandHasChangeAsync();
        //        jm.code = bl ? 0 : 1;
        //        jm.msg = bl ? GlobalConstVars.DeleteSuccess : GlobalConstVars.DeleteFailure;
        //        dbClient.Ado.CommitTran();
        //    }
        //    catch (Exception ex)
        //    {
        //        dbClient.Ado.RollbackTran();
        //        jm.msg = GlobalConstVars.DeleteFailure;
        //        jm.data = ex.ToString();
        //    }
        //    return jm;
        //}

        #endregion

    }
}
