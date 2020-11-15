/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *         CreateTime: 2020-03-22 22:10:13
 *        Description: 暂无
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCms.Net.Model.FromBody
{
    /// <summary>
    /// 根据where查询条件和order排序获取列表
    /// </summary>
    public class FMPageByWhereOrder
    {
        private int _page = 1;
        private int _limit = 10;
        private string _order;
        private string _where;

        /// <summary>
        /// 当前页码
        /// </summary>
        public int page
        {
            get => _page;
            set => _page = value;
        }

        /// <summary>
        /// 每页数据量
        /// </summary>
        public int limit
        {
            get => _limit;
            set => _limit = value;
        }

        /// <summary>
        /// 排序
        /// </summary>
        public string order
        {
            get => _order;
            set => _order = value;
        }

        /// <summary>
        /// 判断条件
        /// </summary>
        public string where
        {
            get => _where;
            set => _where = value;
        }
    }


    /// <summary>
    /// 根据int类型id加where查询条件和order排序获取列表(一般用于直接id分页)
    /// </summary>
    public class FMPageByIntId
    {
        private int _page = 1;
        private int _limit = 10;
        private string _order;
        private string _where;
        private int _id;
        private Object _otherData;


        public Object otherData
        {
            get => _otherData;
            set => _otherData = value;
        }


        public int id
        {
            get => _id;
            set => _id = value;
        }


        /// <summary>
        /// 当前页码
        /// </summary>
        public int page
        {
            get => _page;
            set => _page = value;
        }

        /// <summary>
        /// 每页数据量
        /// </summary>
        public int limit
        {
            get => _limit;
            set => _limit = value;
        }

        /// <summary>
        /// 排序
        /// </summary>
        public string order
        {
            get => _order;
            set => _order = value;
        }

        /// <summary>
        /// 判断条件
        /// </summary>
        public string where
        {
            get => _where;
            set => _where = value;
        }
    }

    /// <summary>
    /// 根据String类型id加where查询条件和order排序获取列表(一般用于直接id分页)
    /// </summary>
    public class FMPageByStringId
    {
        private int _page = 1;
        private int _limit = 10;
        private string _order;
        private string _where;
        private string _id;

        public string id
        {
            get => _id;
            set => _id = value;
        }


        /// <summary>
        /// 当前页码
        /// </summary>
        public int page
        {
            get => _page;
            set => _page = value;
        }

        /// <summary>
        /// 每页数据量
        /// </summary>
        public int limit
        {
            get => _limit;
            set => _limit = value;
        }

        /// <summary>
        /// 排序
        /// </summary>
        public string order
        {
            get => _order;
            set => _order = value;
        }

        /// <summary>
        /// 判断条件
        /// </summary>
        public string where
        {
            get => _where;
            set => _where = value;
        }
    }


}
