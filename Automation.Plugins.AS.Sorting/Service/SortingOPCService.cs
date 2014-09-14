using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Service.OPC;
using System.IO;
using Automation.Plugins.AS.Sorting.Properties;
using System.ComponentModel.Composition;

namespace Automation.Plugins.AS.Sorting.Service
{
    public class SortingOPCService : AbstractServiceWrapper
    {
        [Import("SortLineCode", typeof(string))]
        public string SortLineCode { get; set; }

        public override void Initialize()
        {
            Description = "分拣OPC服务[AB]";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "SortPLC";
            this.TargetService = new OPCService(GetConfigFilePath().Replace(".xml", string.Format("[{0}].xml", SortLineCode)));
        }
    }
}
