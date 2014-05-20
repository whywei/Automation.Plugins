using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core.Option;
using Automation.Plugins.MDJ.WCS.Properties;

namespace Automation.Plugins.MDJ.WCS.Options
{
    public class WCSParameterOption:AbstractOption
    {
        public override void Initialize()
        {
            this.NodeName = "WCSParameterOption";
            this.Caption = "WCS系统参数";
            this.NodeImage = Resources.set_address_16x16;
            this.ParentNodeName = "";
            base.Initialize();
        }
    }
}
