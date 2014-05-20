using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Automation.Plugins.AiOiTag.Action;
using AxAiPlugControl;
using Automation.Core;
using Automation.Plugins.AiOiTag.Util;

namespace Automation.Plugin.MDJ.WCS.View.Dialog
{
    public partial class SetAdressDialog : DevExpress.XtraEditors.XtraForm
    {
        private string IP="";
        private short Port=0;
        Automation.Plugins.AiOiTag.Util.AiOiTag aiOiTag = new Automation.Plugins.AiOiTag.Util.AiOiTag(new Form());
        
        public SetAdressDialog(string ip,string port)
        {
            InitializeComponent();
            lblIP.Text =IP= ip;
            lblPort.Text= port;
        }

        private void btnOK_CheckedChanged(object sender, EventArgs e)
        {
            if (txtAdress.Text.Trim().ToString() == "")
            {
                XtraMessageBox.Show("请输入电子标签地址！","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (!aiOiTag.SendCommand("Ac" + txtAdress.Text.Trim().ToString()))
            {
                XtraMessageBox.Show("设置失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_CheckedChanged(object sender, EventArgs e)
        {
            aiOiTag.Close();
            this.Close();
        }

        private void SetAdressDialog_Load(object sender, EventArgs e)
        {
            try
            {
                Port = Convert.ToInt16(lblPort.Text);
            }
            catch
            {
                XtraMessageBox.Show("端口号不符合要求！请重新设置！","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            if (!aiOiTag.Open(IP, Port))
            {
                XtraMessageBox.Show("打开连接失败，\n请检查IP和端口号是否正确!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            Microsoft.VisualBasic.Devices.Network network = new Microsoft.VisualBasic.Devices.Network();
            if (!network.Ping(IP))
            {
                XtraMessageBox.Show("控制器IP错误或控制器与本机不在同一个网络！", "提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
        }
    }
}