using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core.Option;
using Automation.Plugins.Share.ManualSupply.Properties;

namespace Automation.Plugins.Share.ManualSupply.Options
{
    public class ParameterOption:AbstractOption
    {
        public override void Initialize()
        {
            this.NodeName = "ShareManualSupplyParameterOption";
            this.Caption = "手工补货系统参数";
            this.Order = 3;
            this.NodeImage = Resource.ParameterOption_16;
            this.ParentNodeName = "";
            base.Initialize();
        }

        public override void OnSelected()
        {
        }
    }
}
