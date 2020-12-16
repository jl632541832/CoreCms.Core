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
        /// 缓存优先级:低、普通、高、永不移除
        /// </summary>
        public enum CacheItemPriority
        {
            Low = 0,
            Normal = 1,
            High = 2,
            NeverRemove = 3
        }
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
        /// 来源
        /// 订单来源[对应CoreCmsOrder表source字段]
        /// </summary>
        public enum Source
        {
            [Description("PC页面")]
            PC页面 = 1,
            [Description("H5页面")]
            H5页面 = 2,
            [Description("微信小程序")]
            微信小程序 = 3,
            [Description("支付宝小程序")]
            支付宝小程序 = 4,
            [Description("APP")]
            APP = 5,
            [Description("头条系小程序")]
            头条 = 6
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
        /// <summary>
        /// 第三方账号来源
        /// [对应CoreCmsUserWX表的type类型]
        /// </summary>
        public enum UserAccountTypes
        {
            [Description("微信公众号")]
            微信公众号 = 1,
            [Description("微信小程序")]
            微信小程序 = 2,
            [Description("支付宝小程序")]
            支付宝小程序 = 3,
            [Description("微信APP快捷登陆")]
            微信APP快捷登陆 = 4,
            [Description("QQ在APP中快捷登陆")]
            QQ在APP中快捷登陆 = 5,
            [Description("头条系小程序")]
            头条系小程序 = 6,
        }
        #endregion

        #region 微信配置相关=========================================================

        /// <summary>
        /// 授权方认证类型[关联CoreCmsWeixinAuthor表verifyTypeInfo字段]
        /// </summary>
        public enum WeiChatAuthorVerifyTypes
        {
            未认证 = -1, 微信认证 = 0
        }

        /// <summary>
        /// 微信消息类型[关联CoreCmsWeixinMessage表type字段]
        /// </summary>
        public enum WeiChatMessageTypes
        {
            [Description("文本消息")]
            文本消息 = 1,
            [Description("图片消息")]
            图片消息 = 2,
            [Description("图文消息")]
            图文消息 = 3
        }

        /// <summary>
        /// 微信支付交易类型
        /// </summary>
        public enum WeiChatPayTradeType
        {
            [Description("JSAPI")]
            JSAPI = 1,
            [Description("JSAPI_OFFICIAL")]
            JSAPI_OFFICIAL = 2,
            [Description("NATIVE")]
            NATIVE = 3,
            [Description("APP")]
            APP = 4,
            [Description("MWEB")]
            MWEB = 5
        }


        #endregion

        #region 促销相关===================================================
        /// <summary>
        /// 促销形式类型【对应CoreCmsPromotion.type字段】
        /// </summary>
        public enum PromotionType
        {
            /// <summary>
            /// 促销
            /// </summary>
            [Description("促销")]
            Promotion = 1,
            /// <summary>
            /// 优惠券
            /// </summary>
            [Description("优惠券")]
            Coupon = 2,
            /// <summary>
            /// 团购
            /// </summary>
            [Description("团购")]
            Group = 3,
            /// <summary>
            /// 秒杀
            /// </summary>
            [Description("秒杀")]
            Seckill = 4,
        }
        #endregion

        #region 评价=======================================
        /// <summary>
        /// 评价类型
        /// </summary>
        public enum CommentTypes
        {
            [Description("好评")]
            好评 = 1,
            [Description("中评")]
            中评 = 2,
            [Description("差评")]
            差评 = -1
        }
        #endregion

        #region HangFire定时任务相关

        public enum HangFireQueuesConfig
        {
            /// <summary>
            /// 默认
            /// </summary>
            [Description("默认")]
            @default = 1,
            /// <summary>
            /// 接口
            /// </summary>
            [Description("接口")]
            apis = 2,
            /// <summary>
            /// 网站
            /// </summary>
            [Description("网站")]
            web = 3,
            /// <summary>
            /// 循环时间
            /// </summary>
            [Description("循环时间")]
            recurring = 4,
        }

        #endregion

    }
}