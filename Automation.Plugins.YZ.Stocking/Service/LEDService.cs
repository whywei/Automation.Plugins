using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;

namespace Automation.Plugins.YZ.Stocking.Service
{
    public class LEDService: AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "补货LED服务";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "StockLED";
            this.TargetService = new Automation.Service.LED.LEDService();
        }
    }
}
