using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Service.OPC;

namespace Automation.Plugins.AS.WCS.SRM.Service
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
            Name = "2号堆垛机";
            this.TargetService = new OPCService(GetConfigFilePath());
        }
    }
}
