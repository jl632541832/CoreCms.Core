

namespace CoreCms.Net.Model.ViewModels.Sms
{

    /// <summary>
    /// 凯信通接口短信
    /// </summary>
    public class KxtSmsOptions
    {

        public bool Enabled { get; set; }
        public string UserId { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string ApiUrl { get; set; }
        public string Signature { get; set; }
    }
}
