namespace CoreCms.Net.Model.ViewModels.UI
{
    /// <summary>
    /// 微信接口回调Json实体
    /// </summary>
    public class WebApiCallBack
    {
        private bool _status = false;
        private string _msg = "接口响应成功";
        private object _data;
        private int _code = 0;
        private object _otherData = null;
        private string _methodDescription;

        /// <summary>
        /// 请求接口返回说明
        /// </summary>
        public string methodDescription
        {
            get { return _methodDescription; }
            set { _methodDescription = value; }
        }


        /// <summary>
        /// 提交数据
        /// </summary>
        public object otherData
        {
            get => _otherData;
            set => _otherData = value;
        }
        /// <summary>
        /// 状态码
        /// </summary>
        public bool status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 信息说明。
        /// </summary>
        public string msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object data
        {
            get => _data;
            set => _data = value;
        }

        /// <summary>
        /// 返回编码
        /// </summary>
        public int code
        {
            get { return _code; }
            set { _code = value; }
        }

    }
}
