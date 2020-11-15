/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *           Versions: 1.0                                             *
 *         CreateTime: 2020-02-03 22:45:34
 *           FileName: SqlSugarSetup
 *   ClassDescription: 
 ***********************************************************************/


using System;
using CoreCms.Net.Configuration;
using CoreCms.Net.Loging;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;

namespace CoreCms.Net.Core.Extensions
{
    /// <summary>
    /// SqlSugar 启动服务
    /// </summary>
    public static class SqlSugarSetup
    {
        public static void AddSqlSugarSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            string connectionString = AppSettingsHelper.GetContent("ConnectionStrings", "SqlServerConnection");
            string connId = AppSettingsHelper.GetContent("ConnectionStrings", "ConnId");

            services.AddScoped<ISqlSugarClient>(o =>
                {
                    //RedisCache是继承ICacheService自已实现的一个类
                    //ICacheService myCache = new SqlSugarRedisCache("127.0.0.1");
                    //ICacheService myCache = new SqlSugarHttpRuntimeCache();

                    var db = new SqlSugarClient(new ConnectionConfig()
                    {
                        ConnectionString = connectionString, //必填
                        DbType = SqlSugar.DbType.SqlServer, //必填
                        IsAutoCloseConnection = true, //默认false (设为true我们不需要close或者Using的操作，比较推荐)
                        InitKeyType = InitKeyType.Attribute,
                        MoreSettings = new ConnMoreSettings()
                        {
                            IsWithNoLockQuery = true //为true表式查询的时候默认会加上.With(SqlWith.NoLock)，可以用With(SqlWith.Null)让全局的失效
                        }
                        //InitKeyType = InitKeyType.SystemTable,
                        //ConfigureExternalServices = new ConfigureExternalServices()
                        //{
                        //    DataInfoCacheService = myCache
                        //},
                        //设为true相同线程是同一个SqlConnection
                        //IsShardSameThread = true
                        //读写分离 HitRate表示权重 值越大执行的次数越高，如果想停掉哪个连接可以把HitRate设为0
                        //SlaveConnectionConfigs = new List<SlaveConnectionConfig>() {
                        //    new SlaveConnectionConfig() { HitRate=10, ConnectionString=DataBaseOperationConfig.ConnectionString2 },
                        //    new SlaveConnectionConfig() { HitRate=30, ConnectionString=DataBaseOperationConfig.ConnectionString3 }
                        //}
                    }); //默认SystemTable



                    //日志处理
                    ////SQL执行前 可以修改SQL
                    //db.Aop.OnLogExecuting = (sql, pars) =>
                    //{
                    //    //获取sql
                    //    Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                    //    Console.WriteLine();

                    //    //通过TempItems这个变量来算出这个SQL执行时间（1）
                    //    if (db.TempItems == null) db.TempItems = new Dictionary<string, object>();
                    //    db.TempItems.Add("logTime", DateTime.Now);
                    //    //通过TempItems这个变量来算出这个SQL执行时间（2）
                    //    var startingTime = db.TempItems["logTime"];
                    //    db.TempItems.Remove("time");
                    //    var completedTime = DateTime.Now;


                    //};
                    //db.Aop.OnLogExecuted = (sql, pars) => //SQL执行完事件
                    //{

                    //};
                    //db.Aop.OnLogExecuting = (sql, pars) => //SQL执行前事件
                    //{

                    //};
                    db.Aop.OnError = (exp) =>//执行SQL 错误事件
                    {
                        NLogUtil.WriteFileLog(NLog.LogLevel.Error, LogType.Other, "执行SQL错误事件", exp);
                    };
                    return db;
                });

        }
    }
}
