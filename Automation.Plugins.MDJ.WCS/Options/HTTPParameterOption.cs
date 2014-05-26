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

namespace Automation.Plugins.MDJ.WCS.Options
{
    public class HTTPParameterOption:AbstractOption
    {
        private const string memoryServiceName = "MemoryPermanentSingleDataService";
        private const string memoryHttpUrl = "HttpUrl";
        private const string httpUrl = "http://10.57.64.171:8080/TaskRest/";

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
            var state = Ops.Read<string>(memoryServiceName, memoryHttpUrl);
            if (state != null)
            {
                BaseUrl = state;
            }
            else
            {
                BaseUrl = httpUrl;
                Ops.Write(memoryServiceName, memoryHttpUrl, BaseUrl);
            }

            ((HTTPParameterControl)control).txtHTTP.Text = BaseUrl;
            ((HTTPParameterControl)control).txtHTTP.EditValueChanged += new EventHandler(txtHTTP_EditValueChanged);
        }

        private void txtHTTP_EditValueChanged(object sender, EventArgs e)
        {
            string BaseUrl = ((HTTPParameterControl)control).txtHTTP.Text.Trim();
            Ops.Write(memoryServiceName, memoryHttpUrl, BaseUrl);
        }
    }
}
