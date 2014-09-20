using Automation.Core.Option;
using System.Windows.Forms;
using Automation.Plugins.Common.Forklift.Options.Controls;

namespace Automation.Plugins.Common.Forklift.Options
{
    public class ForkliftParameterOption:AbstractOption
    {
        private ForkliftParameterControl control = null;

        public override void Initialize()
        {
            this.NodeName = "ForkliftParameterOption";
            this.Caption = "车载参数";
            this.Order = 3;
            this.ParentNodeName = "";

            control = new ForkliftParameterControl();
            this.InnerControl = control;
            base.Initialize();
        }

        public override void OnSelected()
        {

        }
    }
}
