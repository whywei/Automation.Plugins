using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Plugins.MDJ.WCS.Model
{
    [Serializable]
    public class SRMInfo
    {
        public string PlcServiceName { get; set; }
        public string GetRequestName {get;set;}
        public string GetAllowName {get;set;}
        public string GetCompleteName {get;set;}
        public string PutRequestName {get;set;}
        public string PutAllowName {get;set;}
        public string PutCompleteName {get;set;}
        public string CancelTaskName { get; set; }
    }
}
