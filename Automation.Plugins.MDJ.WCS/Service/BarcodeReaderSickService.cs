using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Service.BarcodeReader;

namespace Automation.Plugins.MDJ.WCS.Service
{
    public class BarcodeReaderSickService : AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "件烟扫码服务";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "Scanner01";
            this.TargetService = new BarcodeReaderService(GetConfigFilePath());
        }
    }
}
