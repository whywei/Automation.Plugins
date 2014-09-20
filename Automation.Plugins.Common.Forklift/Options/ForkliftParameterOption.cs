using Automation.Core.Option;
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

            control.txtForkliftName.Text = Properties.Settings.Default.ForkliftName;
            control.txtForkliftName.EditValueChanged += new System.EventHandler(txtForkliftName_EditValueChanged);
        }

        private void txtForkliftName_EditValueChanged(object sender, System.EventArgs e)
        {
            string forkliftName = control.txtForkliftName.Text.Trim();
            Properties.Settings.Default.ForkliftName = forkliftName;
            Properties.Settings.Default.Save();
        }

        public override void OnSelected()
        {

        }
    }
}
