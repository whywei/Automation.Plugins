using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Service.OPC;

namespace Automation.Plugins.YZ.Sorting.Service
{
    public class SortingOPCService : AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "分拣AB服务";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "Sort_AB";
            this.TargetService = new OPCService(GetConfigFilePath());
        }
    }
}
