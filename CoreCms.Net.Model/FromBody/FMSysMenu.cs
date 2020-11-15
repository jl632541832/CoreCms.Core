/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *         CreateTime: 2020-10-22 1:45:46
 *        Description: 暂无
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCms.Net.Model.FromBody
{
   public class FMSysMenuToImportButtonData
    {
        public int menuId { get; set; }
        public string controllerName { get; set; }
        public string actionName { get; set; }
        public string description { get; set; }
    }


   public class FMSysMenuToImportButton
   {
       
       public List<FMSysMenuToImportButtonData> data { get; set; }
   }


}
