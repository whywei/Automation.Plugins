using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Plugins.AS.WCS.Rest
{
    public class RestReturn
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class RestReturn<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
