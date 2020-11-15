/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        Projectname= 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *         CreateTime: 2020-03-02 23:52:48
 *        Description: 暂无
 ***********************************************************************/


using System.Collections.Generic;
using CoreCms.Net.Model.ViewModels.Basics;

namespace CoreCms.Net.Configuration
{
    /// <summary>
    /// 全局基础配置字典类型
    /// </summary>
    public static class GlobalSettingDictionary
    {

        /// <summary>
        /// 获取系统配置字典，不匹配数据库(1是2否)
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, DictionaryKeyValues> GetConfig()
        {
            Dictionary<string, DictionaryKeyValues> di = new Dictionary<string, DictionaryKeyValues>();
            //平台设置
            di.Add(GlobalSettingConstVars.ShopName, new DictionaryKeyValues() { sKey = "平台名称", sValue = "核心内容管理系统" });
            di.Add(GlobalSettingConstVars.ShopDesc, new DictionaryKeyValues() { sKey = "平台描述", sValue = "平台描述会展示在前台及微信分享描述" });
            di.Add(GlobalSettingConstVars.ShopAddress, new DictionaryKeyValues() { sKey = "平台地址", sValue = "我的平台地址" });
            di.Add(GlobalSettingConstVars.ShopBeian, new DictionaryKeyValues() { sKey = "备案信息", sValue = "网站备案信息" });
            di.Add(GlobalSettingConstVars.ShopLogo, new DictionaryKeyValues() { sKey = "平台logo", sValue = "" });
            di.Add(GlobalSettingConstVars.ShopFavicon, new DictionaryKeyValues() { sKey = "Favicon图标", sValue = "" });
            di.Add(GlobalSettingConstVars.ShopDefaultImage, new DictionaryKeyValues() { sKey = "默认图", sValue = "" });
            di.Add(GlobalSettingConstVars.StoreSwitch, new DictionaryKeyValues() { sKey = "开启门店自提", sValue = "2" });
            di.Add(GlobalSettingConstVars.CateStyle, new DictionaryKeyValues() { sKey = "分类样式", sValue = "3" });
            di.Add(GlobalSettingConstVars.CateType, new DictionaryKeyValues() { sKey = "H5分类样式", sValue = "1" });
            di.Add(GlobalSettingConstVars.AboutArticleId, new DictionaryKeyValues() { sKey = "关于我们文章", sValue = "2" });
            di.Add(GlobalSettingConstVars.AboutArticle, new DictionaryKeyValues() { sKey = "关于我们文章", sValue = "" });
            di.Add(GlobalSettingConstVars.UserAgreementId, new DictionaryKeyValues() { sKey = "用户协议", sValue = "3" });
            di.Add(GlobalSettingConstVars.UserAgreement, new DictionaryKeyValues() { sKey = "用户协议", sValue = "" });
            di.Add(GlobalSettingConstVars.PrivacyPolicyId, new DictionaryKeyValues() { sKey = "隐私政策", sValue = "4" });
            di.Add(GlobalSettingConstVars.PrivacyPolicy, new DictionaryKeyValues() { sKey = "隐私政策", sValue = "" });
            //搜索发现关键字
            di.Add(GlobalSettingConstVars.RecommendKeys, new DictionaryKeyValues() { sKey = "搜索发现关键词", sValue = "核心,内容,管理,系统" });
            //分享设置
            di.Add(GlobalSettingConstVars.ShareImage, new DictionaryKeyValues() { sKey = "分享图片", sValue = "" });
            di.Add(GlobalSettingConstVars.ShareTitle, new DictionaryKeyValues() { sKey = "分享标题", sValue = "优质好店邀您共享" });
            di.Add(GlobalSettingConstVars.ShareDesc, new DictionaryKeyValues() { sKey = "分享描述", sValue = "" });
            //会员设置
            di.Add(GlobalSettingConstVars.ShopMobile, new DictionaryKeyValues() { sKey = "商家手机号", sValue = "" });
            //1绑定，2不绑定-第三方的登陆的时候，是否需要绑定手机号码，强烈建议用户开启，除非只在微信小程序内使用
            di.Add(GlobalSettingConstVars.IsBindMobile, new DictionaryKeyValues() { sKey = "绑定手机号码", sValue = "1" });
            //商品设置
            di.Add(GlobalSettingConstVars.GoodsStocksWarn, new DictionaryKeyValues() { sKey = "库存警报数量", sValue = "10" });
            di.Add(GlobalSettingConstVars.GoodsShowWord1, new DictionaryKeyValues() { sKey = "商品显示文字1", sValue = "" });
            di.Add(GlobalSettingConstVars.GoodsShowWord2, new DictionaryKeyValues() { sKey = "商品显示文字2", sValue = "" });
            di.Add(GlobalSettingConstVars.GoodsShowWord3, new DictionaryKeyValues() { sKey = "商品显示文字3", sValue = "10" });
            di.Add(GlobalSettingConstVars.GoodsShowWord4, new DictionaryKeyValues() { sKey = "商品显示文字4", sValue = "10" });
            //订单管理
            di.Add(GlobalSettingConstVars.OrderCancelTime, new DictionaryKeyValues() { sKey = "订单取消时间", sValue = "1" });
            di.Add(GlobalSettingConstVars.OrderCompleteTime, new DictionaryKeyValues() { sKey = "订单完成时间", sValue = "30" });
            di.Add(GlobalSettingConstVars.OrderAutoSignTime, new DictionaryKeyValues() { sKey = "订单确认收货时间", sValue = "20" });
            di.Add(GlobalSettingConstVars.OrderAutoEvalTime, new DictionaryKeyValues() { sKey = "订单自动评价时间", sValue = "30" });
            di.Add(GlobalSettingConstVars.RemindOrderTime, new DictionaryKeyValues() { sKey = "订单提醒付款时间", sValue = "1" });
            di.Add(GlobalSettingConstVars.ReshipName, new DictionaryKeyValues() { sKey = "退货联系人", sValue = "" });
            di.Add(GlobalSettingConstVars.ReshipMobile, new DictionaryKeyValues() { sKey = "退货联系方式", sValue = "" });
            di.Add(GlobalSettingConstVars.ReshipAreaId, new DictionaryKeyValues() { sKey = "退货区域", sValue = "" });
            di.Add(GlobalSettingConstVars.ReshipAddress, new DictionaryKeyValues() { sKey = "退货详细地址", sValue = "" });

            //分销功能

            di.Add(GlobalSettingConstVars.OpenDistribution, new DictionaryKeyValues() { sKey = "是否开启三级分销", sValue = "1" });
            di.Add(GlobalSettingConstVars.DistributionNotes, new DictionaryKeyValues() { sKey = "用户须知", sValue = "" });
            di.Add(GlobalSettingConstVars.DistributionAgreement, new DictionaryKeyValues() { sKey = "分销协议", sValue = "" });
            di.Add(GlobalSettingConstVars.DistributionStore, new DictionaryKeyValues() { sKey = "是否开启店铺", sValue = "2" });
            //di.Add(GlobalSettingConstVars.FirstPushAward, new DictionaryKeyValues() { sKey = "直推奖励", sValue = "0" });
            //di.Add(GlobalSettingConstVars.SecondPushAward, new DictionaryKeyValues() { sKey = "次推奖励", sValue = "0" });
            di.Add(GlobalSettingConstVars.ShowInviterInfo, new DictionaryKeyValues() { sKey = "是否显示邀请人信息", sValue = "2" });


            di.Add(GlobalSettingConstVars.DistributionLevel, new DictionaryKeyValues() { sKey = "分销层级", sValue = "2" });
            di.Add(GlobalSettingConstVars.DistributionType, new DictionaryKeyValues() { sKey = "成为分销商条件", sValue = "1" });
            di.Add(GlobalSettingConstVars.DistributionMoney, new DictionaryKeyValues() { sKey = "消费自动成为分销商", sValue = "100" });
            di.Add(GlobalSettingConstVars.DistributionGoods, new DictionaryKeyValues() { sKey = "购买商品成为分销商", sValue = "1" });
            di.Add(GlobalSettingConstVars.DistributionGoodsId, new DictionaryKeyValues() { sKey = "购买商品成为分销商指定商品序列号", sValue = "0" });

            di.Add(GlobalSettingConstVars.CommissionType, new DictionaryKeyValues() { sKey = "佣金类型", sValue = "1" });
            di.Add(GlobalSettingConstVars.CommissionFirst, new DictionaryKeyValues() { sKey = "一级佣金", sValue = "0" });
            di.Add(GlobalSettingConstVars.CommissionSecond, new DictionaryKeyValues() { sKey = "二级佣金", sValue = "0" });
            di.Add(GlobalSettingConstVars.CommissionThird, new DictionaryKeyValues() { sKey = "三级佣金", sValue = "0" });

            //积分设置
            di.Add(GlobalSettingConstVars.SignPointType, new DictionaryKeyValues() { sKey = "签到奖励类型", sValue = "2" });
            di.Add(GlobalSettingConstVars.SignRandomMin, new DictionaryKeyValues() { sKey = "随机奖励积分最小值", sValue = "1", });
            di.Add(GlobalSettingConstVars.SignRandomMax, new DictionaryKeyValues() { sKey = "随机奖励积分最大值", sValue = "10" });
            di.Add(GlobalSettingConstVars.FirstSignPoint, new DictionaryKeyValues() { sKey = "首次奖励积分", sValue = "1" });
            di.Add(GlobalSettingConstVars.ContinuitySignAdditional, new DictionaryKeyValues() { sKey = "连续签到追加", sValue = "1" });
            di.Add(GlobalSettingConstVars.SignMostPoint, new DictionaryKeyValues() { sKey = "单日最大奖励", sValue = "10" });
            di.Add(GlobalSettingConstVars.PointSwitch, new DictionaryKeyValues() { sKey = "开启积分功能", sValue = "1" });
            di.Add(GlobalSettingConstVars.PointDiscountedProportion, new DictionaryKeyValues() { sKey = "订单积分折现比例", sValue = "100" });
            di.Add(GlobalSettingConstVars.OrdersPointProportion, new DictionaryKeyValues() { sKey = "订单积分使用比例", sValue = "10" });
            di.Add(GlobalSettingConstVars.OrdersRewardProportion, new DictionaryKeyValues() { sKey = "订单积分奖励比例", sValue = "1" });

            di.Add(GlobalSettingConstVars.SignAppointDateStatus, new DictionaryKeyValues() { sKey = "指定特殊日期状态", sValue = "false" });
            di.Add(GlobalSettingConstVars.SignAppointDate, new DictionaryKeyValues() { sKey = "指定特殊日期", sValue = "" });
            di.Add(GlobalSettingConstVars.SignAppointDataType, new DictionaryKeyValues() { sKey = "指定日期奖励类型", sValue = "1" });
            di.Add(GlobalSettingConstVars.SignAppointDateRate, new DictionaryKeyValues() { sKey = "指定日期倍率", sValue = "2" });
            di.Add(GlobalSettingConstVars.SignAppointDateAdditional, new DictionaryKeyValues() { sKey = "指定日期追加", sValue = "10" });

            // 提现设置
            di.Add(GlobalSettingConstVars.TocashMoneyLow, new DictionaryKeyValues() { sKey = "最低提现金额", sValue = "0.01" });
            di.Add(GlobalSettingConstVars.TocashMoneyRate, new DictionaryKeyValues() { sKey = "提现服务费率", sValue = "0" });
            di.Add(GlobalSettingConstVars.TocashMoneyLimit, new DictionaryKeyValues() { sKey = "每日提现上限", sValue = "0" });

            //小程序设置
            di.Add(GlobalSettingConstVars.WxUrl, new DictionaryKeyValues() { sKey = "小程序部署URL", sValue = "https://", });
            di.Add(GlobalSettingConstVars.WxNickName, new DictionaryKeyValues() { sKey = "小程序名称", sValue = "CoreCms.Shop", });
            di.Add(GlobalSettingConstVars.WxAppid, new DictionaryKeyValues() { sKey = "AppId", sValue = "", });
            di.Add(GlobalSettingConstVars.WxAppSecret, new DictionaryKeyValues() { sKey = "AppSecret", sValue = "" });
            di.Add(GlobalSettingConstVars.WxToken, new DictionaryKeyValues() { sKey = "小程序验证TOKEN", sValue = "", });
            di.Add(GlobalSettingConstVars.WxEncodeaeskey, new DictionaryKeyValues() { sKey = "小程序EncodingAESKey", sValue = "" });
            di.Add(GlobalSettingConstVars.WxUserName, new DictionaryKeyValues() { sKey = "原始Id", sValue = "", });
            di.Add(GlobalSettingConstVars.WxPrincipalName, new DictionaryKeyValues() { sKey = "主体信息", sValue = "核心内容管理系统", });
            di.Add(GlobalSettingConstVars.WxSignature, new DictionaryKeyValues() { sKey = "简介", sValue = "核心内容管理系统", });

            //公众号设置
            di.Add(GlobalSettingConstVars.WxOfficialUrl, new DictionaryKeyValues() { sKey = "公众号部署URL", sValue = "https://", });
            di.Add(GlobalSettingConstVars.WxOfficialName, new DictionaryKeyValues() { sKey = "公众号名称", sValue = "", });
            di.Add(GlobalSettingConstVars.WxOfficialId, new DictionaryKeyValues() { sKey = "微信号", sValue = "", });
            di.Add(GlobalSettingConstVars.WxOfficialAppid, new DictionaryKeyValues() { sKey = "AppId", sValue = "", });
            di.Add(GlobalSettingConstVars.WxOfficialAppSecret, new DictionaryKeyValues() { sKey = "AppSecret", sValue = "", });
            di.Add(GlobalSettingConstVars.WxOfficialSourceId, new DictionaryKeyValues() { sKey = "公众号原始ID", sValue = "", });
            di.Add(GlobalSettingConstVars.WxOfficialToken, new DictionaryKeyValues() { sKey = "微信验证TOKEN", sValue = "", });
            di.Add(GlobalSettingConstVars.WxOfficialEncodeaeskey, new DictionaryKeyValues() { sKey = "EncodingAESKey", sValue = "" });
            di.Add(GlobalSettingConstVars.WxOfficialType, new DictionaryKeyValues() { sKey = "公众号类型", sValue = "service" });
            di.Add(GlobalSettingConstVars.WxOfficialQrCode, new DictionaryKeyValues() { sKey = "公众号二维码", sValue = "" });

            //其他设置
            di.Add(GlobalSettingConstVars.QqMapKey, new DictionaryKeyValues() { sKey = "腾讯地图key", sValue = "" });
            di.Add(GlobalSettingConstVars.Kuaidi100Customer, new DictionaryKeyValues() { sKey = "公司编号", sValue = "" });
            di.Add(GlobalSettingConstVars.Kuaidi100Key, new DictionaryKeyValues() { sKey = "授权key", sValue = "" });

            //统计代码
            di.Add(GlobalSettingConstVars.StatisticsCode, new DictionaryKeyValues() { sKey = "百度统计代码", sValue = "" });
            //发票开关
            di.Add(GlobalSettingConstVars.InvoiceSwitch, new DictionaryKeyValues() { sKey = "发票功能", sValue = "1" });
            //支付宝小程序appid
            di.Add(GlobalSettingConstVars.MpAlipayAppid, new DictionaryKeyValues() { sKey = "支付宝小程序appid", sValue = "" });
            //客服ID
            di.Add(GlobalSettingConstVars.EntId, new DictionaryKeyValues() { sKey = "客服ID", sValue = "" });
            //易源接口授权
            di.Add(GlobalSettingConstVars.ShowApiAppid, new DictionaryKeyValues() { sKey = "AppId", sValue = "" });
            di.Add(GlobalSettingConstVars.ShowApiSecret, new DictionaryKeyValues() { sKey = "授权Secret", sValue = "" });

            //凯信通短信设置
            return di;
        }

        /// <summary>
        /// 获取促销添加参数类型字典
        /// </summary>
        /// <returns></returns>
        public static List<CommonKeyValues> GetPromotionConditionType()
        {
            var list = new List<CommonKeyValues>
            {
                new CommonKeyValues() {sDescription = "所有商品满足条件", sValue = "goods", sKey = "GOODS_ALL"},
                new CommonKeyValues() {sDescription = "指定某些商品满足条件", sValue = "goods", sKey = "GOODS_IDS"},
                new CommonKeyValues() {sDescription = "指定商品分类满足条件", sValue = "goods", sKey = "GOODS_CATS"},
                new CommonKeyValues() {sDescription = "指定商品品牌满足条件", sValue = "goods", sKey = "GOODS_BRANDS"},
                new CommonKeyValues() {sDescription = "订单满XX金额满足条件", sValue = "order", sKey = "ORDER_FULL"},
                new CommonKeyValues() {sDescription = "用户符合指定等级", sValue = "user", sKey = "USER_GRADE"}
            };
            return list;
        }


        /// <summary>
        /// 获取促销添加结果类型字典
        /// </summary>
        /// <returns></returns>
        public static List<CommonKeyValues> GetPromotionResultType()
        {
            var list = new List<CommonKeyValues>
            {
                new CommonKeyValues() {sDescription = "指定商品减固定金额", sValue = "goods", sKey = "GOODS_REDUCE"},
                new CommonKeyValues() {sDescription = "指定商品打X折", sValue = "goods", sKey = "GOODS_DISCOUNT"},
                new CommonKeyValues() {sDescription = "指定商品一口价", sValue = "goods", sKey = "GOODS_ONE_PRICE"},
                new CommonKeyValues() {sDescription = "订单减指定金额", sValue = "order", sKey = "ORDER_REDUCE"},
                new CommonKeyValues() {sDescription = "订单打X折", sValue = "order", sKey = "ORDER_DISCOUNT"},
                new CommonKeyValues() {sDescription = "指定商品每第几件减指定金额", sValue = "goods", sKey = "GOODS_HALF_PRICE"}
            };
            return list;
        }
    }
}
