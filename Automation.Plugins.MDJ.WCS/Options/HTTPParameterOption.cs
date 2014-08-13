using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core.Option;
using Automation.Plugins.MDJ.WCS.Properties;
using Automation.Plugins.MDJ.WCS.Options.Controls;
using System.Windows.Forms;
using System.Xml.Linq;
using Automation.Core;
using Automation.Plugins.MDJ.WCS.Rest;

namespace Automation.Plugins.MDJ.WCS.Options
{
    public class HTTPParameterOption:AbstractOption
    {
        private Control control = null;

        public override void Initialize()
        {
            this.NodeName = "HTTPParameterOption";
            this.Caption = "HTTP连接";
            this.Order = 3;
            this.ParentNodeName = "WCSParameterOption";
            this.NodeImage = Resources.HTTPParameter_16;
            this.InnerControl = new HTTPParameterControl();
            control = this.InnerControl;
            base.Initialize();
            LoadInfo();
        }

        private void LoadInfo()
        {
            string BaseUrl = string.Empty;
            var httpUrl = Properties.Settings.Default.HttpUrl;
            if (!string.IsNullOrEmpty(httpUrl))
            {
                BaseUrl = httpUrl;
            }
            else
            {
                BaseUrl = RestClient.httpUrl;
                Properties.Settings.Default.HttpUrl = RestClient.httpUrl;
                Properties.Settings.Default.Save();
            }

            ((HTTPParameterControl)control).txtHTTP.Text = BaseUrl;
            ((HTTPParameterControl)control).txtHTTP.EditValueChanged += new EventHandler(txtHTTP_EditValueChanged);
        }

        private void txtHTTP_EditValueChanged(object sender, EventArgs e)
        {
            string BaseUrl = ((HTTPParameterControl)control).txtHTTP.Text.Trim();
            Properties.Settings.Default.HttpUrl = BaseUrl;
            Properties.Settings.Default.Save();
        }

        public override void OnSelected()
        {

        }
    }
}
