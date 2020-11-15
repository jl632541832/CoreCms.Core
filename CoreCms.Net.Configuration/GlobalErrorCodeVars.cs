/***********************************************************************
 *            Project: CoreCms.Net                                     *
 *                Web: https://CoreCms.Net                             *
 *        ProjectName: 核心内容管理系统                                *
 *             Author: 大灰灰                                          *
 *              Email: JianWeie@163.com                                *
 *         CreateTime: 2020-03-28 23:22:14
 *        Description: 暂无
 ***********************************************************************/

namespace CoreCms.Net.Configuration
{
    /// <summary>
    /// 数据接口错误编码返回
    /// 11000 用户
    /// 12000 商品
    /// 13000 订单
    /// 14000 api
    /// 15000 促销&优惠券
    /// </summary>
    public class GlobalErrorCodeVars
    {

        public const string Code10000 = "未定义的错误信息";
        public const string Code10002 = "没有找到此记录";
        public const string Code10003 = "参数不正确";
        public const string Code10004 = "保存失败";
        public const string Code10005 = "用户信息没有修改";
        public const string Code10006 = "图片超过限定张数";
        public const string Code10007 = "删除失败";
        public const string Code10008 = "没有此配置参数";
        public const string Code10009 = "没有此消息编码，请确认";
        public const string Code10010 = "您没有该操作权限";
        public const string Code10011 = "请选择商户";
        public const string Code10012 = "验证码错误";
        public const string Code10013 = "请输入验证码";
        public const string Code10014 = "没有此推荐人";
        public const string Code10015 = "商户公众号未配置";



        public const string Code10050 = "此支付方式未启用";
        public const string Code10051 = "缺少参数，请确认";
        public const string Code10052 = "此支付方式未启用，或不是一个有效的支付方式";
        public const string Code10053 = "已开启过此支付方式，不需要重复开启";
        public const string Code10054 = "没有此支付类型,请确认";
        public const string Code10055 = "请选择支付方式";
        public const string Code10056 = "请输入支付单号";
        public const string Code10057 = "没有此支付方式";
        public const string Code10058 = "没有此支付方式，或此支付方式未启用";
        public const string Code10059 = "支付单金额为0，直接支付成功";
        public const string Code10060 = "没有找到此支付单";
        public const string Code10061 = "不需要获取openid";
        public const string Code10062 = "请用户先进行微信登陆或绑定";
        public const string Code10063 = "请用户先进行支付宝登陆或绑定";
        public const string Code10064 = "";
        public const string Code10065 = "";
        public const string Code10066 = "msg里的值就是跳转的url";                  //微信公众号静默登陆
        public const string Code10067 = "公众号支付必须传url参数";
        public const string Code10068 = "code必传";


        public const string Code10100 = "没有此消息编码";


        public const string Code11001 = "用户未登录";
        public const string Code11002 = "此微信用户未登录或当前账号未绑定微信账号";
        public const string Code11003 = "请选择头像";
        public const string Code11004 = "没有找到此用户";
        public const string Code11005 = "此用户没有绑定手机号码，所以发送短信失败";
        public const string Code11006 = "此用户以停用，请联系总管理员";
        public const string Code11007 = "余额不足";
        public const string Code11008 = "请输入用户名，长度6-20位";
        public const string Code11009 = "请输入密码，长度为6-16位";
        public const string Code11010 = "没有找到此管理员";
        public const string Code11011 = "用户名重复";
        public const string Code11012 = "请输入旧密码";
        public const string Code11013 = "请输入新密码";
        public const string Code11014 = "请输入确认密码";
        public const string Code11015 = "用户余额不足";
        public const string Code11016 = "没有找到此提现银行卡";
        public const string Code11017 = "请输入银行卡号";
        public const string Code11018 = "请输入提现金额";
        public const string Code11019 = "已注册过，请直接登陆";
        public const string Code11020 = "请输入正确的充值金额";
        public const string Code11021 = "请检查银行卡号是否有误";
        public const string Code11022 = "账号已停用";
        public const string Code11023 = "超级管理员，就不要编辑了吧？";
        public const string Code11024 = "超级管理员，就不要删除了把？";
        public const string Code11025 = "两次密码输入不一致";
        public const string Code11026 = "密码过期了";
        public const string Code11027 = "请选择出生日期";
        public const string Code11028 = "请输入昵称";
        public const string Code11029 = "请设置出生日期";

        public const string Code11050 = "没有此收货地址信息";
        public const string Code11051 = "请输入手机号码";
        public const string Code11055 = "请选择自提门店";



        public const string Code11070 = "请输入角色名称";
        public const string Code11071 = "没有此角色信息";
        public const string Code11072 = "没有选择权限信息";

        public const string Code11080 = "请输入管理员的手机号码";
        public const string Code11081 = "没有找到此用户";
        public const string Code11082 = "目前一个账号只能绑定一个店铺，此手机号码已注册过店铺，如果是未审核通过的店铺可以联系平台删除对应的店铺，然后再次添加此管理员";
        public const string Code11083 = "手机号码和用户id两者最少写一个";
        public const string Code11084 = "此账号已经是店铺管理员了，请勿重新设置";
        public const string Code11085 = "此账号是超级管理员，不需要添加";
        public const string Code11086 = "您不是管理员，请先成为商户管理员或者创建自己的店铺";
        public const string Code11087 = "用户绑定了多个商户平台，系统不知道你想登陆哪一个，需要用户去选择";      //严格意义上来说这个不是错误信息
        public const string Code11088 = "没有找到控制器，请联系平台管理员";
        public const string Code11089 = "没有找到此方法，请联系平台管理员";
        public const string Code11090 = "没有找到此方法所对应的关联方法，请联系平台管理员";
        public const string Code11091 = "请先清空下级节点";
        public const string Code11092 = "核心参数不能为空";
        public const string Code11093 = "父节点是模块，当前类型就必须是控制器";
        public const string Code11094 = "父节点是控制器，当前类型就必须是方法";
        public const string Code11095 = "父节点是根节点，当前类型就必须是模块";
        public const string Code11096 = "当前节点已经存在，请勿重复提交";
        public const string Code11097 = "设置的父节点可能会陷入死循环";
        public const string Code11098 = "设置的父菜单可能陷入死循环";
        public const string Code11099 = "如果是控制器节点，菜单节点必须和父节点保持一致";



        public const string Code11100 = "购物车商品不能为空，或不是有效的商品";
        public const string Code11101 = "父节点可能会陷入死循环";


        public const string Code11500 = "店铺不存在，请确认";
        public const string Code11501 = "店铺现在处于非正常状态";       //未审核通过或者是到期了




        public const string Code13001 = "请选择收货地址";
        public const string Code13100 = "请输入订单编号";
        public const string Code13101 = "没有找到此订单信息,或者您没有权限查看此信息";
        public const string Code13102 = "已有售后,请联系客服";

        public const string Code13200 = "订单不是可售后状态";
        public const string Code13201 = "退货的数量超过可退的数量";
        public const string Code13202 = "退货商品不正确，请确认";
        public const string Code13203 = "订单状态不可退款";
        public const string Code13204 = "订单状态不可退货";
        public const string Code13205 = "请选择退货商品";
        public const string Code13206 = "总退款金额超过已支付金额";
        public const string Code13207 = "售后单不是待审核状态，或者没有找到此售后单";
        public const string Code13208 = "退款单金额为0，不需要退款";
        public const string Code13209 = "退货数量为空，不需要生成退货单";
        public const string Code13210 = "退款单已退或没权限进行操作";
        public const string Code13211 = "退货单已退或没权限进行操作";
        public const string Code13212 = "请输入退货单编号";
        public const string Code13213 = "请选择物流公司";
        public const string Code13214 = "请输入物流编码";
        public const string Code13215 = "请输入退款单号";
        public const string Code13216 = "请输入退款金额";
        public const string Code13217 = "请输入售后单号";
        public const string Code13218 = "没有找到此售后单";
        public const string Code13219 = "没有找到此退款单或此退款单状态不是未待退款状态";
        public const string Code13220 = "请输入退货单号";
        public const string Code13221 = "没有找到此退货单";
        public const string Code13222 = "请输入售后单号";
        public const string Code13223 = "没有找到此售后单号";
        public const string Code13224 = "没有找到此退款单或此退款单状态不是退款失败状态";
        public const string Code13225 = "缺少物流查询参数";
        public const string Code13226 = "x轴最多1000个节点，请减少时间范围，或者修改粒度";
        public const string Code13227 = "还没发货呢，怎么能收到货呢？";
        public const string Code13228 = "请选择审核状态";




        public const string Code13300 = "订单已完成或取消不能发货";
        public const string Code13301 = "订单未付款不能发货";
        public const string Code13302 = "订单已发货不能再发货";
        public const string Code13303 = "订单中不存在要发货的商品";
        public const string Code13304 = "发货数量大于订单中商品的数量";
        public const string Code13305 = "发货单生成出现未知错误";
        public const string Code13306 = "发货失败，该货品已不存在";
        public const string Code13307 = "发货失败，商品数量不足";
        public const string Code13308 = "发货明细里包含订单之外的商品";






        public const string Code13400 = "评价缺少商品信息";
        public const string Code13401 = "评价缺少订单号";
        public const string Code13402 = "评价缺少商家店铺评价信息";
        public const string Code13403 = "缺少商品ID参数";




        public const string Code14001 = "";
        public const string Code14002 = "method参数结构错误";
        public const string Code14003 = "method参数1不存在";
        public const string Code14004 = "method参数2不存在";
        public const string Code14006 = "请先登录";
        public const string Code14007 = "用户身份过期请重新登录";
        public const string Code14008 = "操作失败，请重试1";
        public const string Code14009 = "操作失败，请重试2";
        public const string Code14011 = "";


        //促销，优惠券
        public const string Code15001 = "请输入促销名称";
        public const string Code15002 = "请输入起止时间";
        public const string Code15003 = "请选择促销条件";
        public const string Code15004 = "没有找到此促销条件";
        public const string Code15005 = "没有找到此促销结果";
        public const string Code15006 = "请输入促销ID参数";
        public const string Code15007 = "该优惠券不存在或状态不可领取";
        public const string Code15008 = "你已领取过了,勿重复领取";
        public const string Code15009 = "优惠券号码不存在";
        public const string Code15010 = "优惠券还没有到开始时间";
        public const string Code15011 = "优惠券已经过期";
        public const string Code15012 = "优惠券禁用了，请联系客服";
        public const string Code15013 = "优惠券已经使用过了";
        public const string Code15014 = "优惠券不符合使用规则";
        public const string Code15015 = "同一类优惠券，只能使用一张";
        public const string Code15016 = "团购或秒杀只能应用一种促销类型";
        public const string Code15017 = "同一个商品只能同时存在一个团购秒杀";
        public const string Code15018 = "已超出领取限额";

        //拼团
        public const string Code15601 = "还没有到时间";
        public const string Code15602 = "已经结束了";
        public const string Code15603 = "没有找到此拼团商品";
        public const string Code15604 = "请传拼团id";
        public const string Code15605 = "请传商品id";
        public const string Code15606 = "请传入订单id或者team_id";
        public const string Code15607 = "没有此拼团记录,或不是已经结束";
        public const string Code15608 = "参加拼团的商品和下单商品不一致";
        public const string Code15609 = "没有找到拼团发起人";
        public const string Code15610 = "该商品已超过当前活动最大购买量";
        public const string Code15611 = "您已超过该活动最大购买量";
        public const string Code15612 = "货品折扣后价格已经小于0元";
        public const string Code15613 = "您不能参加自己的开团";

        //微信消息
        public const string Code16001 = "请输入标题";
        public const string Code16002 = "请先填写内容";

    }
}
