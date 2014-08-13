using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core.Option;
using Automation.Plugins.MDJ.WCS.Properties;
using Automation.Plugins.MDJ.WCS.Options.Controls;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Automation.Plugins.MDJ.WCS.Options
{
    public class StockDatabaseConnectionOption:AbstractOption
    {
        private Control control=null;
        public override void Initialize()
        {
            this.NodeName = "StockDatabaseConnectionOption";
            this.Caption = "补货数据库连接";
            this.Order = 2;
            this.ParentNodeName = "WCSParameterOption";
            this.NodeImage = Resources.database_16;
            this.InnerControl = new StockDatabaseConnectionPanel();
            control = this.InnerControl;
            base.Initialize();
            LoadInfo();
        }

        private void LoadInfo()
        {
            XElement doc = XElement.Load(@"TransactionScopeFactoryProviderConfig.xml");
            IList<XElement> el = (from d in doc.Descendants("key") where d.Attribute("name").Value == Global.THOK_STOCK_DB_NAME select d).ToList();
            if (el != null)
            {
                var node = (from e in el[0].Elements("DataConfiguration")
                            select new
                            {
                                IP = e.Element("IP"),
                                DataBaseName = e.Element("DataBaseName"),
                                User = e.Element("User"),
                                Password = e.Element("Password")
                            }).ToList();
                if (node != null)
                {
                    ((StockDatabaseConnectionPanel)control).txtIP.Text = node[0].IP.Attribute("value").Value;
                    ((StockDatabaseConnectionPanel)control).txtDatabaseName.Text = node[0].DataBaseName.Attribute("value").Value;
                    ((StockDatabaseConnectionPanel)control).txtUser.Text = node[0].User.Attribute("value").Value;
                    ((StockDatabaseConnectionPanel)control).txtPassword.Text = node[0].Password.Attribute("value").Value;
                    ((StockDatabaseConnectionPanel)control).txtIP.EditValueChanged += new EventHandler(txt_EditValueChanged);
                    ((StockDatabaseConnectionPanel)control).txtDatabaseName.EditValueChanged += new EventHandler(txt_EditValueChanged);
                    ((StockDatabaseConnectionPanel)control).txtUser.EditValueChanged += new EventHandler(txt_EditValueChanged);
                    ((StockDatabaseConnectionPanel)control).txtPassword.EditValueChanged += new EventHandler(txt_EditValueChanged);
                }
            }
        }

        private void txt_EditValueChanged(object sender, EventArgs e)
        {
            XElement doc = XElement.Load(@"TransactionScopeFactoryProviderConfig.xml");
            IList<XElement> el = (from d in doc.Descendants("key") where d.Attribute("name").Value == Global.THOK_STOCK_DB_NAME select d).ToList();
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
                    node[0].IP.Attribute("value").Value = ((StockDatabaseConnectionPanel)control).txtIP.Text.Trim();
                    node[0].DataBaseName.Attribute("value").Value = ((StockDatabaseConnectionPanel)control).txtDatabaseName.Text;
                    node[0].User.Attribute("value").Value = ((StockDatabaseConnectionPanel)control).txtUser.Text;
                    node[0].Password.Attribute("value").Value = ((StockDatabaseConnectionPanel)control).txtPassword.Text;
                    doc.Save(@"TransactionScopeFactoryProviderConfig.xml");
                }
            }
        }

        public override void OnSelected()
        {

        }
    }
}
