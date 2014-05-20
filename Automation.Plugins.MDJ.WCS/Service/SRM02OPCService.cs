using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Service.OPC;

namespace Automation.Plugins.MDJ.WCS.Service
{
    public class SRM02OPCService : AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "2号堆垛机OPC服务";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "SRM02";
            this.TargetService = new OPCService(GetConfigFilePath());
        }
    }
}
