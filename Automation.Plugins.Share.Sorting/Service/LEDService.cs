using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;

namespace Automation.Plugins.Share.Sorting.Service
{
    public class LEDService : AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "分拣LED服务";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "SortLED";
            this.TargetService = new Automation.Service.LED.LEDService();
        }
    }
}
