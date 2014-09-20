using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core.Option;
using Automation.Plugins.AS.WCS.Properties;

namespace Automation.Plugins.AS.WCS.Options
{
    public class ParameterOption : AbstractOption
    {
        public override void Initialize()
        {
            this.NodeName = "WCSParameterOption";
            this.Caption = "WCS系统参数";
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
