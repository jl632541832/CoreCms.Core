/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *         CreateTime: 2020-03-03 3:24:15
 *        Description: 暂无
 ***********************************************************************/


namespace CoreCms.Net.Configuration
{
    /// <summary>
    /// 平台设置字段缓存名称定义
    /// </summary>
    public static class GlobalSettingConstVars
    {
        /// <summary>
        /// 平台名称
        /// </summary>
        public const string ShopName = "shop_name";

        /// <summary>
        /// 平台描述
        /// </summary>
        public const string ShopDesc = "shop_desc";

        /// <summary>
        /// 平台地址
        /// </summary>
        public const string ShopAddress = "shop_address";

        /// <summary>
        /// 备案信息
        /// </summary>
        public const string ShopBeian = "shop_beian";

        /// <summary>
        /// 平台logo
        /// </summary>
        public const string ShopLogo = "shop_logo";

        /// <summary>
        /// Favicon图标
        /// </summary>
        public const string ShopFavicon = "shop_favicon";

        /// <summary>
        /// 默认图
        /// </summary>
        public const string ShopDefaultImage = "shop_default_image";

        /// <summary>
        /// 商家手机号
        /// </summary>
        public const string ShopMobile = "shop_mobile";

        /// <summary>
        /// 开启门店自提
        /// </summary>
        public const string StoreSwitch = "store_switch";

        /// <summary>
        /// 分类样式
        /// </summary>
        public const string CateStyle = "cate_style";

        /// <summary>
        /// H5分类样式
        /// </summary>
        public const string CateType = "cate_type";

        /// <summary>
        /// 订单取消时间
        /// </summary>
        public const string OrderCancelTime = "order_cancel_time";

        /// <summary>
        /// 订单完成时间
        /// </summary>
        public const string OrderCompleteTime = "order_complete_time";

        /// <summary>
        /// 订单确认收货时间
        /// </summary>
        public const string OrderAutoSignTime = "order_autoSign_time";

        /// <summary>
        /// 订单自动评价时间
        /// </summary>
        public const string OrderAutoEvalTime = "order_autoEval_time";

        /// <summary>
        /// 订单提醒付款时间
        /// </summary>
        public const string RemindOrderTime = "remind_order_time";


        //分销功能（老分销）=============================================================
        /// <summary>
        /// 是否开启分销
        /// </summary>
        public const string OpenDistribution = "open_distribution";
        /// <summary>
        /// 用户须知：成为分销商后，可以获取佣金，用户只可被推荐一次，越早推荐越返利越多哦。
        /// </summary>
        public const string DistributionNotes = "distribution_notes";
        /// <summary>
        /// 分销协议
        /// </summary>
        public const string DistributionAgreement = "distribution_agreement";
        /// <summary>
        /// 是否开启店铺
        /// </summary>
        public const string DistributionStore = "distribution_store";

        /// <summary>
        /// 显示邀请人信息
        /// </summary>
        public const string ShowInviterInfo = "show_inviter_info";


        /// <summary>
        /// 分销层级1,2层
        /// </summary>
        public const string DistributionLevel = "distribution_level";
        /// <summary>
        /// 成为分销商条件：1无条件(需要审核),2申请(需要审核),3无条件
        /// </summary>
        public const string DistributionType = "distribution_type";
        /// <summary>
        /// 消费自动成为分销商：元
        /// </summary>
        public const string DistributionMoney = "distribution_money";
        /// <summary>
        /// 购买商品成为分销商：1关闭，2任意商品，3指定商品
        /// </summary>
        public const string DistributionGoods = "distribution_goods";
        /// <summary>
        /// 购买商品成为分销商指定商品序列号
        /// </summary>
        public const string DistributionGoodsId = "distribution_goods_id";
        /// <summary>
        /// 佣金类型：1百分比，2固定金额
        /// </summary>
        public const string CommissionType = "commission_type";
        /// <summary>
        /// 一级佣金
        /// </summary>
        public const string CommissionFirst = "commission_first";
        /// <summary>
        /// 二级佣金
        /// </summary>
        public const string CommissionSecond = "commission_second";
        /// <summary>
        /// 三级佣金
        /// </summary>
        public const string CommissionThird = "commission_third";


        /// <summary>
        /// 库存警报数量
        /// </summary>
        public const string GoodsStocksWarn = "goods_stocks_warn";

        /// <summary>
        /// 商品显示文字1
        /// </summary>
        public const string GoodsShowWord1 = "goods_show_word1";

        /// <summary>
        /// 商品显示文字2
        /// </summary>
        public const string GoodsShowWord2 = "goods_show_word2";

        /// <summary>
        /// 商品显示文字3
        /// </summary>
        public const string GoodsShowWord3 = "goods_show_word3";

        /// <summary>
        /// 商品显示文字4
        /// </summary>
        public const string GoodsShowWord4 = "goods_show_word4";

        /// <summary>
        /// 退货联系人
        /// </summary>
        public const string ReshipName = "reship_name";

        /// <summary>
        /// 退货联系方式
        /// </summary>
        public const string ReshipMobile = "reship_mobile";

        /// <summary>
        /// 退货区域
        /// </summary>
        public const string ReshipAreaId = "reship_area_id";

        /// <summary>
        /// 退货详细地址
        /// </summary>
        public const string ReshipAddress = "reship_address";

        /// <summary>
        /// 签到奖励类型
        /// </summary>
        public const string SignPointType = "sign_point_type";

        /// <summary>
        /// 随机奖励积分最小值
        /// </summary>
        public const string SignRandomMin = "sign_random_min";

        /// <summary>
        /// 随机奖励积分最大值
        /// </summary>
        public const string SignRandomMax = "sign_random_max";

        /// <summary>
        /// 首次奖励积分
        /// </summary>
        public const string FirstSignPoint = "first_sign_point";

        /// <summary>
        /// 连续签到追加
        /// </summary>
        public const string ContinuitySignAdditional = "continuity_sign_additional";

        /// <summary>
        /// 单日最大奖励
        /// </summary>
        public const string SignMostPoint = "sign_most_point";

        /// <summary>
        /// 开启积分功能
        /// </summary>
        public const string PointSwitch = "point_switch";

        /// <summary>
        /// 订单积分折现比例
        /// </summary>
        public const string PointDiscountedProportion = "point_discounted_proportion";

        /// <summary>
        /// 订单积分使用比例
        /// </summary>
        public const string OrdersPointProportion = "orders_point_proportion";

        /// <summary>
        /// 订单积分奖励比例
        /// </summary>
        public const string OrdersRewardProportion = "orders_reward_proportion";

        /// <summary>
        /// 指定特殊日期状态
        /// </summary>
        public const string SignAppointDateStatus = "sign_appoint_date_status";

        /// <summary>
        /// 指定特殊日期
        /// </summary>
        public const string SignAppointDate = "sign_appoint_date";

        /// <summary>
        /// 指定日期奖励类型
        /// </summary>
        public const string SignAppointDataType = "sign_appoint_data_type";

        /// <summary>
        /// 指定日期倍率
        /// </summary>
        public const string SignAppointDateRate = "sign_appoint_date_rate";

        /// <summary>
        /// 指定日期追加
        /// </summary>
        public const string SignAppointDateAdditional = "sign_appoint_date_additional";




        //小程序设置============================================================================
        /// <summary>
        /// 小程序部署URL
        /// </summary>
        public const string WxUrl = "wx_url";
        /// <summary>
        /// 小程序名称
        /// </summary>
        public const string WxNickName = "wx_nick_name";

        /// <summary>
        /// 小程序AppId
        /// </summary>
        public const string WxAppid = "wx_appid";

        /// <summary>
        /// 小程序AppSecret
        /// </summary>
        public const string WxAppSecret = "wx_app_secret";

        /// <summary>
        /// 小程序TOKEN
        /// </summary>
        public const string WxToken = "wx_token";

        /// <summary>
        /// 小程序EncodingAESKey
        /// </summary>
        public const string WxEncodeaeskey = "wx_encodeaeskey";


        /// <summary>
        /// 原始Id
        /// </summary>
        public const string WxUserName = "wx_user_name";

        /// <summary>
        /// 主体信息
        /// </summary>
        public const string WxPrincipalName = "wx_principal_name";

        /// <summary>
        /// 简介
        /// </summary>
        public const string WxSignature = "wx_signature";


        //公众号设置============================================================================

        /// <summary>
        /// 公众号部署URL
        /// </summary>
        public const string WxOfficialUrl = "wx_official_url";
        /// <summary>
        /// 公众号名称
        /// </summary>
        public const string WxOfficialName = "wx_official_name";

        /// <summary>
        /// 微信号
        /// </summary>
        public const string WxOfficialId = "wx_official_id";

        /// <summary>
        /// AppId
        /// </summary>
        public const string WxOfficialAppid = "wx_official_appid";

        /// <summary>
        /// AppSecret
        /// </summary>
        public const string WxOfficialAppSecret = "wx_official_app_secret";

        /// <summary>
        /// 公众号原始ID
        /// </summary>
        public const string WxOfficialSourceId = "wx_official_source_id";

        /// <summary>
        /// 微信验证TOKEN
        /// </summary>
        public const string WxOfficialToken = "wx_official_token";

        /// <summary>
        /// EncodingAESKey
        /// </summary>
        public const string WxOfficialEncodeaeskey = "wx_official_encodeaeskey";

        /// <summary>
        /// 公众号类型
        /// </summary>
        public const string WxOfficialType = "wx_official_type";
        /// <summary>
        /// 公众号二维码
        /// </summary>
        public const string WxOfficialQrCode = "wx_official_QR_code";


        // 提现设置============================================================================
        /// <summary>
        /// 最低提现金额
        /// </summary>
        public const string TocashMoneyLow = "tocash_money_low";

        /// <summary>
        /// 提现服务费率
        /// </summary>
        public const string TocashMoneyRate = "tocash_money_rate";

        /// <summary>
        /// 每日提现上限
        /// </summary>
        public const string TocashMoneyLimit = "tocash_money_limit";


        //其他设置============================================================================

        /// <summary>
        /// 腾讯地图key
        /// </summary>
        public const string QqMapKey = "qq_map_key";

        /// <summary>
        /// 公司编号
        /// </summary>
        public const string Kuaidi100Customer = "kuaidi100_customer";

        /// <summary>
        /// 授权key
        /// </summary>
        public const string Kuaidi100Key = "kuaidi100_key";


        //搜索发现关键字============================================================================
        /// <summary>
        /// 搜索发现关键词
        /// </summary>
        public const string RecommendKeys = "recommend_keys";


        //统计代码============================================================================
        /// <summary>
        /// 百度统计代码
        /// </summary>
        public const string StatisticsCode = "statistics_code";


        //发票开关============================================================================
        /// <summary>
        /// 发票功能
        /// </summary>
        public const string InvoiceSwitch = "invoice_switch";


        //第三方的登陆的时候，是否需要绑定手机号码，强烈建议用户开启，除非只在微信小程序内使用============================================================================
        //1绑定，2不绑定
        /// <summary>
        /// 绑定手机号码
        /// </summary>
        public const string IsBindMobile = "is_bind_mobile";

        //支付宝小程序appid============================================================================

        /// <summary>
        /// 支付宝小程序appid
        /// </summary>
        public const string MpAlipayAppid = "mp_alipay_appid";

        /// <summary>
        /// 分享图片
        /// </summary>
        public const string ShareImage = "share_image";

        /// <summary>
        /// 分享标题
        /// </summary>
        public const string ShareTitle = "share_title";

        /// <summary>
        /// 分享描述
        /// </summary>
        public const string ShareDesc = "share_desc";

        /// <summary>
        /// 关于我们文章
        /// </summary>
        public const string AboutArticleId = "about_article_id";

        /// <summary>
        /// 关于我们文章
        /// </summary>
        public const string AboutArticle = "about_article";

        /// <summary>
        /// 客服ID
        /// </summary>
        public const string EntId = "ent_id";

        /// <summary>
        /// 用户协议
        /// </summary>
        public const string UserAgreementId = "user_agreement_id";

        /// <summary>
        /// 用户协议
        /// </summary>
        public const string UserAgreement = "user_agreement";

        /// <summary>
        /// 隐私政策
        /// </summary>
        public const string PrivacyPolicyId = "privacy_policy_id";

        /// <summary>
        /// 隐私政策
        /// </summary>
        public const string PrivacyPolicy = "privacy_policy";


        //第三方接口============================================================================
        /// <summary>
        /// 易源接口授权key
        /// </summary>
        public const string ShowApiAppid = "showApiAppid";
        /// <summary>
        /// 易源接口授权密钥
        /// </summary>
        public const string ShowApiSecret = "showApiSecret";

    }
}