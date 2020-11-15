using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCms.Net.Model.FromBody
{
    public class FMStoreClerkCURDPost
    {
        public int id { get; set; } = 0;

        public int storeId { get; set; }
        public string phone { get; set; }

    }
}
