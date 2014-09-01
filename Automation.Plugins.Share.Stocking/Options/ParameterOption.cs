using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core.Option;
using Automation.Plugins.YZ.Stocking.Properties;

namespace Automation.Plugins.YZ.Stocking.Options
{
    public class ParameterOption : AbstractOption
    {
        public override void Initialize()
        {
            this.NodeName = "StockParameterOption";
            this.Caption = "补货系统参数";
            this.Order = 3;
            this.NodeImage = Resources.ParameterOption_16;
            this.ParentNodeName = "";
            base.Initialize();
        }

        public override void OnSelected()
        {
        }
    }
}
