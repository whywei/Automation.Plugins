using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Service.OPC;

namespace Automation.Plugins.MDJ.WCS.Service
{
    public class THOKOPCService : AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "密集库OPC服务";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "THOKPLC";
            this.TargetService = new OPCService(GetConfigFilePath());
        }
    }
}
