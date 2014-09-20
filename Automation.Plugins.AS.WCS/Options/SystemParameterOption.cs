using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core.Option;
using Automation.Plugins.AS.WCS.Properties;
using Automation.Plugins.AS.WCS.Options.Controls;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Automation.Plugins.AS.WCS.Options
{
    public class SystemParameterOption : AbstractOption
    {
        private Control control = null;
        private TextEdit txtHttpUrl = null;
        private TextEdit txtSRMCount = null;

        public override void Initialize()
        {
            base.Initialize();
            this.NodeName = "WCSSystemParameterOption";
            this.Caption = "运用程序参数";
            this.Order = 3;
            this.ParentNodeName = "WCSParameterOption";
            this.NodeImage = Resources.ParameterOption_16;
            this.InnerControl = new SystemParameterPanel();
            this.control = this.InnerControl;
            txtHttpUrl = ((SystemParameterPanel)this.control).txtHttpUrl;
            txtHttpUrl.EditValueChanged += new EventHandler(TxtHttpUrl_EditValueChanged);
            txtSRMCount = ((SystemParameterPanel)this.control).txtSRMCount;
            txtSRMCount.EditValueChanged += new EventHandler(TxtSTMCounte_EditValueChanged);
        }

        public override void OnSelected()
        {
            txtHttpUrl.Text = Settings.Default.HttpUrl;
            txtSRMCount.Text = Settings.Default.SRMCount.ToString(); ;
        }

        private void TxtHttpUrl_EditValueChanged(object sender, EventArgs e)
        {
            if (txtHttpUrl.Text.Trim().Length <= 0)
            {
                XtraMessageBox.Show("分拣线编码不能为空！", "提示");
                return;
            }
            Settings.Default.HttpUrl = txtHttpUrl.Text.Trim();
        }

        private void TxtSTMCounte_EditValueChanged(object sender, EventArgs e)
        {
            Settings.Default.SRMCount = Convert.ToInt32(txtSRMCount.Text);
        }
    }
}
