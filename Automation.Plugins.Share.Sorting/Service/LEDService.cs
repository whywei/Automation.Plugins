using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;

namespace Automation.Plugins.YZ.Sorting.Service
{
    public class LEDService : AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "LED服务";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "LED";
            this.TargetService = new Automation.Service.LED.LEDService();
        }
    }
}
