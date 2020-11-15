namespace CoreCms.Net.Model.ViewModels.UI
{
    /// <summary>
    /// LayUIAdmin后端UI回调Json实体
    /// </summary>
    public class AdminUiCallBack
    {
        private int _code = 1;
        private string _msg = "空数据返回";
        private object _data;
        private object _otherData;
        private int _count = 0;
        /// <summary>
        /// 状态码(ok = 0, error = 1, timeout = 401)
        /// </summary>
        public int code
        {
            get { return _code; }
            set { _code = value; }
        }

        /// <summary>
        /// 可选。信息内容。
        /// </summary>
        public string msg
        {
            get { return _msg; }
            set { _msg = value; }
        }

        public object data
        {
            get => _data;
            set => _data = value;
        }
        public object otherData
        {
            get => _otherData;
            set => _otherData = value;
        }

        public int count
        {
            get { return _count; }
            set { _count = value; }
        }

    }
}
