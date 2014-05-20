using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Plugins.MDJ.WCS.Rest
{
    public class RestReturn
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
