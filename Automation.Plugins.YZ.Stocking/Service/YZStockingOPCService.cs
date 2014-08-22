using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Service.OPC;

namespace Automation.Plugins.YZ.Stocking.Service
{
    public class YZStockingOPCService : AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "补货OPC服务";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "YZ_Stock_PLC";
            this.TargetService = new OPCService(GetConfigFilePath());
        }
    }
}
