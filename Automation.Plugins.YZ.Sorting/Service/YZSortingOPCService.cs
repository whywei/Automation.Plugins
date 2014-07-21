using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Service.OPC;

namespace Automation.Plugins.YZ.Sorting.Service
{
    public class YZSortingOPCService : AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "永州分拣OPC服务";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "YZ_FJ_PLC";
            this.TargetService = new OPCService(GetConfigFilePath());
        }
    }
}
