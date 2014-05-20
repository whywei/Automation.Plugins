using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core.Option;
using Automation.Plugins.MDJ.WCS.Properties;
using Automation.Plugins.MDJ.WCS.Options.Controls;
using System.Windows.Forms;
using System.Xml.Linq;

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
            XElement doc = XElement.Load(@"TransactionScopeFactoryProviderConfig.xml");
            var el = (from d in doc.Elements("HttpConnection") select new { HTTP = d.Element("HttpUrl") }).ToList();
            if (el != null)
            {
                ((HTTPParameterControl)control).txtHTTP.Text = el[0].HTTP.Attribute("value").Value;
                ((HTTPParameterControl)control).txtHTTP.EditValueChanged += new EventHandler(txtHTTP_EditValueChanged);
            }
        }

        private void txtHTTP_EditValueChanged(object sender, EventArgs e)
        {
            XElement doc = XElement.Load(@"TransactionScopeFactoryProviderConfig.xml");
            var el = (from d in doc.Elements("HttpConnection") select new { HTTP = d.Element("HttpUrl") }).ToList();
            if (el != null)
            {
                el[0].HTTP.Attribute("value").Value = ((HTTPParameterControl)control).txtHTTP.Text.Trim();
                doc.Save(@"TransactionScopeFactoryProviderConfig.xml");
            }
        }
    }
}
