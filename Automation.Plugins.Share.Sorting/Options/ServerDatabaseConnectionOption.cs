using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core.Option;
using Automation.Plugins.Share.Sorting.Properties;
using Automation.Plugins.Share.Sorting.Options.Controls;
using System.Windows.Forms;
using System.Xml.Linq;
using Automation.Plugins.Share.Sorting.Model;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.ComponentModel.Composition;
using DotSpatial.Controls;
using Automation.Core;
using DevExpress.XtraLayout;

namespace Automation.Plugins.Share.Sorting.Options
{
    public class ServerDatabaseConnectionOption : AbstractOption
    {
        private Control control = null;
        private ConnectionModel connectionModel = null;
        public override void Initialize()
        {
            base.Initialize();
            this.NodeName = "YZServerDatabaseConnectionOption";
            this.Caption = "服务器数据库连接";
            this.Order = 1;
            this.ParentNodeName = "YZSortParameterOption";
            this.NodeImage = Resources.database_16;
            this.InnerControl = new ServerDatabaseConnectionPanel();
            this.control=this.InnerControl;
            ((ServerDatabaseConnectionPanel)this.InnerControl).btnTestConneection.Click+=new EventHandler(btnTestConneection_Click);
            ((ServerDatabaseConnectionPanel)this.InnerControl).btnSave.Click+=new EventHandler(btnSave_Click);
        }

        private void LoadInfo()
        {
            try
            {
                XElement doc = XElement.Load(@"TransactionScopeFactoryProviderConfig.xml");
                IList<XElement> el = (from d in doc.Descendants("key") where d.Attribute("name").Value == Global.SERVER_DATABASE_NAME select d).ToList();
                if (el.Count>0)
                {
                    var node = (from e in el[0].Elements("DataConfiguration")
                                select new
                                {
                                    IP = e.Element("IP").Attribute("value").Value,
                                    DataBaseName = e.Element("DataBaseName").Attribute("value").Value,
                                    User = e.Element("User").Attribute("value").Value,
                                    Password = e.Element("Password").Attribute("value").Value
                                }).ToList();
                    if (node.Count>0)
                    {
                        connectionModel = new ConnectionModel();
                        connectionModel.IP = node[0].IP;
                        connectionModel.DataBaseName = node[0].DataBaseName;
                        connectionModel.User = node[0].User;
                        connectionModel.Password = node[0].Password;
                        connectionModel.ConfirmPassword = node[0].Password;
                        ((ServerDatabaseConnectionPanel)this.InnerControl).propertyGridControl1.SelectedObject = connectionModel;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("加载服务器数据库连接参数失败！原因：{0}", ex.Message));
                XtraMessageBox.Show("加载服务器数据库连接参数失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTestConneection_Click(object sender, EventArgs e)
        {
            if (CheckInformation())
            {
                string connection = "server = " + connectionModel.IP + "; uid = " + connectionModel.User + "; pwd = " + connectionModel.Password + "; database = " + connectionModel.DataBaseName;
                SqlConnection conn = new SqlConnection(connection);
                try
                {
                    conn.Open();
                    XtraMessageBox.Show("连接成功！", "提示");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("连接失败！原因：{0}。", ex.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInformation())
            {
                try
                {
                    XElement doc = XElement.Load(@"TransactionScopeFactoryProviderConfig.xml");
                    IList<XElement> el = (from d in doc.Descendants("key") where d.Attribute("name").Value == Global.SERVER_DATABASE_NAME select d).ToList();
                    if (el .Count>0)
                    {
                        var node = (from item in el[0].Elements("DataConfiguration")
                                    select new
                                    {
                                        IP = item.Element("IP"),
                                        DataBaseName = item.Element("DataBaseName"),
                                        User = item.Element("User"),
                                        Password = item.Element("Password")
                                    }).ToList();
                        if (node .Count>0)
                        {
                            node[0].IP.Attribute("value").Value = connectionModel.IP.Trim();
                            node[0].DataBaseName.Attribute("value").Value = connectionModel.DataBaseName.Trim();
                            node[0].User.Attribute("value").Value = connectionModel.User.Trim();
                            node[0].Password.Attribute("value").Value = connectionModel.Password.Trim();
                            doc.Save(@"TransactionScopeFactoryProviderConfig.xml");
                            XtraMessageBox.Show("保存成功！请重启软件！", "提示");
                        }
                    }
                }
                catch(Exception ex)
                {
                    Logger.Error(string.Format("保存服务器数据库连接参数失败！原因：{0}", ex.Message));
                    XtraMessageBox.Show("保存服务器数据库连接参数失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CheckInformation()
        {
            if (connectionModel != null)
            {
                if (connectionModel.IP.Trim().Length <= 0)
                {
                    XtraMessageBox.Show("服务器名不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (connectionModel.DataBaseName.Trim().Length <= 0)
                {
                    XtraMessageBox.Show("数据库名不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (connectionModel.User.Trim().Length <= 0)
                {
                    XtraMessageBox.Show("登录名称不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (connectionModel.Password.Trim().Length <= 0)
                {
                    XtraMessageBox.Show("登录密码不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (connectionModel.Password.Trim() != connectionModel.ConfirmPassword.Trim())
                {
                    XtraMessageBox.Show("两次输入的密码不匹配", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void OnSelected()
        {
            LoadInfo();
        }
    }
}
