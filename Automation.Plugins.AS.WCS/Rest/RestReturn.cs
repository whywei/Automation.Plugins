using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Common.SRM;

namespace Automation.Plugins.AS.WCS.Rest
{
    public class RestReturn
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public SRMTask Data { get; set; }
    }

    public class RestReturn<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
