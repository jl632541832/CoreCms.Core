using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.ViewModels.Basics;
using CoreCms.Net.Repository;
using SqlSugar;

namespace CoreCms.Net.CodeGenerator.Repository
{
    public class CodeGeneratorRepository : BaseRepository<object>, ICodeGeneratorRepository
    {
        public CodeGeneratorRepository(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {

        }

        /// <summary>
        /// 获取所有的表
        /// </summary>
        /// <returns></returns>
        public List<DbTableInfo> GetDbTables()
        {
            var tables = dbClient.DbMaintenance.GetTableInfoList(false).OrderBy(p => p.Name).ToList();
            var views = dbClient.DbMaintenance.GetViewInfoList(false).OrderBy(p => p.Name).ToList();
            if (!views.Any()) return tables;
            var newList = tables.Union(views).ToList();
            return newList;
        }

        /// <summary>
        /// 获取表下面所有的字段
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<DbColumnInfo> GetDbTablesColumns(string tableName)
        {
            var columns = dbClient.DbMaintenance.GetColumnInfosByTableName(tableName, false);
            return columns;
        }


        /// <summary>
        /// 自动生成代码
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public byte[] CodeGen(string tableName, string fileType)
        {
            var tables = dbClient.DbMaintenance.GetTableInfoList(false);
            var views = dbClient.DbMaintenance.GetViewInfoList(false);
            var tb = tables.Find(p => p.Name == tableName) ?? views.Find(p => p.Name == tableName);
            if (tb == null)
            {
                return null;
            }
            else
            {
                var columns = dbClient.DbMaintenance.GetColumnInfosByTableName(tb.Name, false);
                return CoreCms.Net.CodeGenerator.GeneratorCodeHelper.CodeGenerator(tb.Name, tb.Description, columns, fileType);
            }
        }


        /// <summary>
        /// 自动生成类型的所有数据库代码
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public byte[] CodeGenByAll(string fileType)
        {

            var tables = dbClient.DbMaintenance.GetTableInfoList(false);
            var views = dbClient.DbMaintenance.GetViewInfoList(false);
            var newList = tables;
            if (views.Any()) newList = tables.Union(views).ToList();

            var allDb = new List<DbTableInfoAndColumns>();
            newList.ForEach(p =>
            {
                var model = new DbTableInfoAndColumns();
                model.Name = p.Name;
                model.DbObjectType = p.DbObjectType;
                model.Description = p.Description;
                model.columns = dbClient.DbMaintenance.GetColumnInfosByTableName(p.Name, false);
                allDb.Add(model);
            });

            if (!allDb.Any())
            {
                return null;
            }
            else
            {
                return CoreCms.Net.CodeGenerator.GeneratorCodeHelper.CodeGeneratorAll(allDb, fileType);
            }
        }



    }
}