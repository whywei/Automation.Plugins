using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Service.OPC;

namespace Automation.Plugins.YZ.Stocking.Service
{
    public class StockingOPCService : AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "补货AB服务";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "Stock_AB";
            this.TargetService = new OPCService(GetConfigFilePath());
        }
    }
}
