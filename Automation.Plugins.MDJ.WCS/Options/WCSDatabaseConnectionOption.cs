using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core.Option;
using Automation.Plugins.MDJ.WCS.Properties;
using Automation.Plugins.MDJ.WCS.Options.Controls;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing;
using DevExpress.XtraEditors;

namespace Automation.Plugins.MDJ.WCS.Options
{
    public class WCSDatabaseConnectionOption:AbstractOption
    {
        private Control control = null;
        public override void Initialize()
        {
            this.NodeName = "WCSDatabaseConnectionOption";
            this.Caption = "WCS数据库连接";
            this.Order = 1;
            this.ParentNodeName = "WCSParameterOption";
            this.NodeImage = Resources.database_16;
            this.InnerControl =new WCSDatabaseConnectionPanel();
            control = this.InnerControl;
            base.Initialize();
            LoadInfo();
        }

        private void LoadInfo()
        {
            XElement doc = XElement.Load(@"TransactionScopeFactoryProviderConfig.xml");
            IList<XElement> el = (from d in doc.Descendants("key") where d.Attribute("name").Value ==Global.THOK_WCS_DB_NAME select d).ToList();
            if (el != null)
            {
                var node = (from e in el[0].Elements("DataConfiguration") 
                            select new { 
                                IP = e.Element("IP"),
                                DataBaseName = e.Element("DataBaseName"),
                                User = e.Element("User"),
                                Password = e.Element("Password")
                            }).ToList();
                if(node!=null)
                {
                    ((WCSDatabaseConnectionPanel)control).txtIP.Text = node[0].IP.Attribute("value").Value;
                    ((WCSDatabaseConnectionPanel)control).txtDatabaseName.Text = node[0].DataBaseName.Attribute("value").Value;
                    ((WCSDatabaseConnectionPanel)control).txtUser.Text = node[0].User.Attribute("value").Value;
                    ((WCSDatabaseConnectionPanel)control).txtPassword.Text = node[0].Password.Attribute("value").Value;
                    ((WCSDatabaseConnectionPanel)control).txtIP.EditValueChanged += new EventHandler(txt_EditValueChanged);
                    ((WCSDatabaseConnectionPanel)control).txtDatabaseName.EditValueChanged += new EventHandler(txt_EditValueChanged);
                    ((WCSDatabaseConnectionPanel)control).txtUser.EditValueChanged += new EventHandler(txt_EditValueChanged);
                    ((WCSDatabaseConnectionPanel)control).txtPassword.EditValueChanged += new EventHandler(txt_EditValueChanged);
                }
            }
        }

        private void txt_EditValueChanged(object sender, EventArgs e)
        {
            XElement doc = XElement.Load(@"TransactionScopeFactoryProviderConfig.xml");
            IList<XElement> el = (from d in doc.Descendants("key") where d.Attribute("name").Value == Global.THOK_WCS_DB_NAME select d).ToList();
            if (el != null)
            {
                var node = (from item in el[0].Elements("DataConfiguration")
                            select new
                            {
                                IP = item.Element("IP"),
                                DataBaseName = item.Element("DataBaseName"),
                                User = item.Element("User"),
                                Password = item.Element("Password")
                            }).ToList();
                if (node != null)
                {
                    node[0].IP.Attribute("value").Value = ((WCSDatabaseConnectionPanel)control).txtIP.Text.Trim();
                    node[0].DataBaseName.Attribute("value").Value = ((WCSDatabaseConnectionPanel)control).txtDatabaseName.Text;
                    node[0].User.Attribute("value").Value = ((WCSDatabaseConnectionPanel)control).txtUser.Text;
                    node[0].Password.Attribute("value").Value=((WCSDatabaseConnectionPanel)control).txtPassword.Text;
                    doc.Save(@"TransactionScopeFactoryProviderConfig.xml");
                }
            }
        }
    }
}
