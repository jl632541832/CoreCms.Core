using System.ComponentModel;

namespace CoreCms.Net.Configuration
{
    /// <summary>
    /// 系统常用枚举类
    /// </summary>
    public class GlobalEnumVars
    {
        #region 系统相关===============================================================

        /// <summary>
        /// 订单编号类型大全
        /// </summary>
        public enum SerialNumberType
        {
            [Description("订单编号")]
            订单编号 = 1,
            [Description("支付单编号")]
            支付单编号 = 2,
            [Description("商品编号")]
            商品编号 = 3,
            [Description("货品编号")]
            货品编号 = 4,
            [Description("售后单编号")]
            售后单编号 = 5,
            [Description("退款单编号")]
            退款单编号 = 6,
            [Description("退货单编号")]
            退货单编号 = 7,
            [Description("发货单编号")]
            发货单编号 = 8,
            [Description("提货单号")]
            提货单号 = 9,
            [Description("服务订单编号")]
            服务订单编号 = 10,
            [Description("服务券兑换码")]
            服务券兑换码 = 11,
        }


        /// <summary>
        /// 用户登录日志类型
        /// </summary>

        public enum LoginRecordType
        {
            登录成功 = 0,
            登录失败 = 1,
            退出登录 = 2,
            刷新Token = 0
        }


        /// <summary>
        /// 附件存储支持类型
        /// </summary>
        public enum FilesStorageOptionsType
        {
            [Description("本地存储")]
            LocalStorage = 0,
            [Description("阿里云OSS")]
            AliYunOSS = 1,
            [Description("腾讯云OSS")]
            QCloudOSS = 2,
        }

        #endregion

        #region User用户相关===========================================================================
        /// <summary>
        /// 性别[1男2女3未知]
        /// 对应CoreCmsUserWX表的gender类型
        /// </summary>
        public enum UserSexTypes
        {
            [Description("男")]
            男 = 1,
            [Description("女")]
            女 = 2,
            [Description("未知")]
            未知 = 3
        }

        #endregion



    }
}
