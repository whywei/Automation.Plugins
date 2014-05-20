using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Plugins.MDJ.WCS.Model
{
    [Serializable]
    public class AlarmInfo
    {
        public string AlarmCode { get; set; }
        public string Description { get; set; }
    }
}
