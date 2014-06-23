using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Plugins.YZ.Sorting.Model
{
    [Serializable]
    public class ChannelAllot
    {

        public string channel_code { get; set; }
        public string channel_name { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public int real_quantity { get; set; }
        public string channel_type { get; set; }
        public string led_code { get; set; }
        public int remain_quantity { get; set; }
        public int middle_quantity { get; set; }
        public int max_quantity { get; set; }
        public int in_quantity { get; set; }
        public int out_quantity { get; set; }
        public int group_no { get; set; }
        public int order_no { get; set; }
        public int address { get; set; }
        public string cell_code { get; set; }
        public string status { get; set; }


    }
}
