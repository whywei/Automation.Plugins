using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core.Option;
using Automation.Plugins.Share.Sorting.Properties;

namespace Automation.Plugins.Share.Sorting.Options
{
    public class ParameterOption : AbstractOption
    {
        public override void Initialize()
        {
            this.NodeName = "YZSortParameterOption";
            this.Caption = "分拣系统参数";
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
