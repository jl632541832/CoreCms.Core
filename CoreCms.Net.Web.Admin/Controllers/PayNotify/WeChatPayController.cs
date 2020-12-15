using System;
using System.Threading.Tasks;
using CoreCms.Net.Configuration;
using CoreCms.Net.IServices;
using CoreCms.Net.Loging;
using CoreCms.Net.Model.Entities;
using Essensoft.AspNetCore.Payment.WeChatPay;
using Essensoft.AspNetCore.Payment.WeChatPay.Notify;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CoreCms.Net.Web.WebApi.Controllers.PayNotify
{
    /// <summary>
    /// 微信支付异步通知
    /// </summary>
    [Route("Notify/[controller]/[action]")]
    public class WeChatPayController : Controller
    {
        private readonly IWeChatPayNotifyClient _client;
        private readonly IOptions<WeChatPayOptions> _optionsAccessor;


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="client"></param>
        /// <param name="optionsAccessor"></param>
        /// <param name="billPaymentsServices"></param>
        /// <param name="billRefundServices"></param>
        public WeChatPayController(
            IWeChatPayNotifyClient client
            , IOptions<WeChatPayOptions> optionsAccessor)
        {
            _client = client;
            _optionsAccessor = optionsAccessor;
        }

        /// <summary>
        /// 统一下单支付结果通知
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Unifiedorder()
        {

            var notify = await _client.ExecuteAsync<WeChatPayUnifiedOrderNotify>(Request, _optionsAccessor.Value);
            if (notify.ReturnCode == WeChatPayCode.Success)
            {
                if (notify.ResultCode == WeChatPayCode.Success)
                {


                    return WeChatPayNotifyResult.Success;
                }
                else
                {
                    var msg = notify.ErrCode + ":" + notify.ErrCodeDes;
                    return WeChatPayNotifyResult.Success;
                }
            }
            return NoContent();

        }

        /// <summary>
        /// 退款结果通知
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Refund()
        {
            try
            {
                var notify = await _client.ExecuteAsync<WeChatPayRefundNotify>(Request, _optionsAccessor.Value);
                NLogUtil.WriteDbLog(NLog.LogLevel.Trace, LogType.Refund, "退款结果通知" + JsonConvert.SerializeObject(notify));
                NLogUtil.WriteFileLog(NLog.LogLevel.Trace, LogType.Refund, "退款结果通知" + JsonConvert.SerializeObject(notify));

                if (notify.ReturnCode == WeChatPayCode.Success)
                {
                    if (notify.RefundStatus == WeChatPayCode.Success)
                    {
                        //Console.WriteLine("OutTradeNo: " + notify.OutTradeNo);

                        var memo = JsonConvert.SerializeObject(notify);



                        return WeChatPayNotifyResult.Success;
                    }
                }
                return NoContent();
            }
            catch
            {
                return NoContent();
            }
        }

    }
}