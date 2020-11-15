using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CoreCms.Net.Utility.Helper
{
    public class EnumHelper
    {
        /// <summary>
        /// 将枚举转成List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<EnumberEntity> EnumToList<T>()
        {
            List<EnumberEntity> list = new List<EnumberEntity>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                EnumberEntity m = new EnumberEntity();
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objArr != null && objArr.Length > 0)
                {
                    DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                    m.Des = da.Description;
                }
                m.Value = Convert.ToInt32(e);
                m.Title = e.ToString();
                list.Add(m);
            }
            return list;
        }

        /// <summary>
        /// 根据枚举值来获取单个枚举实体
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="value">value</param>
        /// <returns></returns>
        public static EnumberEntity GetEnumberEntity<T>(int value)
        {
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                EnumberEntity m = new EnumberEntity();
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objArr != null && objArr.Length > 0)
                {
                    DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                    m.Des = da.Description;
                }
                m.Value = Convert.ToInt32(e);
                m.Title = e.ToString();
                if (value == m.Value)
                {
                    return m;
                }
            }
            return null;
        }


        /// <summary>
        /// 根据枚举值value来获取单个枚举实体的文字描述内容
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="value">value</param>
        /// <returns></returns>
        public static string GetEnumDescriptionByValue<T>(int value)
        {
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                EnumberEntity m = new EnumberEntity();
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objArr != null && objArr.Length > 0)
                {
                    DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                    m.Des = da.Description;
                }
                m.Value = Convert.ToInt32(e);
                m.Title = e.ToString();
                if (value == m.Value)
                {
                    return m.Des;
                }
            }
            return "";
        }

        /// <summary>
        /// 根据枚举key来获取单个枚举实体的文字描述内容
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="key">value</param>
        /// <returns></returns>
        public static string GetEnumDescriptionByKey<T>(string key)
        {
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                EnumberEntity m = new EnumberEntity();
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objArr != null && objArr.Length > 0)
                {
                    DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                    m.Des = da.Description;
                }
                m.Value = Convert.ToInt32(e);
                m.Title = e.ToString();
                if (key == m.Title)
                {
                    return m.Des;
                }
            }
            return "";
        }

    }


    /// <summary>
    /// 枚举实体
    /// </summary>
    public class EnumberEntity
    {
        /// <summary>  
        /// 枚举的描述  
        /// </summary>  
        public string Des { set; get; }

        /// <summary>  
        /// 枚举名称  
        /// </summary>  
        public string Title { set; get; }

        /// <summary>  
        /// 枚举对象的值  
        /// </summary>  
        public int Value { set; get; }
    }

}
