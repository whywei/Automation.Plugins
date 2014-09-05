using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Service.OPC;

namespace Automation.Plugins.AS.Sorting.Service
{
    public class SortingOPCService : AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "分拣OPC服务[AB]";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "SortPLC";
            this.TargetService = new OPCService(GetConfigFilePath());
        }
    }
}
