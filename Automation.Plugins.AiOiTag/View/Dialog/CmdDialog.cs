using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Automation.Plugins.AiOiTag.View.Dialog
{
    public partial class CmdDialog : DevExpress.XtraEditors.XtraForm
    {
        Automation.Plugins.AiOiTag.Util.AiOiTag aiOiTag = new Automation.Plugins.AiOiTag.Util.AiOiTag(new Form());
        private string IP = "";
        private short Port = 0;

        public CmdDialog(string ip, string port)
        {
            InitializeComponent();
            IP = ip;
            try
            {
                Port = Convert.ToInt16(port);
            }
            catch
            {
                XtraMessageBox.Show("端口号不符合要求！请重新设置！","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
        }

        private void CmdDialog_Load(object sender, EventArgs e)
        {
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

        private void Set_Click(string str,string address, string action)
        {
            if (address == "" || address == null)
            {
                XtraMessageBox.Show("请输入电子标签地址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!aiOiTag.SendCommand(str + address + action))
            {
                XtraMessageBox.Show("设置失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Show_Click(string address)
        {
            if (address == "" || address == null)
            {
                XtraMessageBox.Show("请输入电子标签地址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!aiOiTag.SendCommand("P100" + address + "12345"))
            {
                XtraMessageBox.Show("显示失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Stop_Click(string address)
        {
            if (address == "" || address == null)
            {
                XtraMessageBox.Show("请输入电子标签地址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!aiOiTag.SendCommand("D" + address ))
            {
                XtraMessageBox.Show("停止显示失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSet1_CheckedChanged(object sender, EventArgs e)
        {
            Set_Click("Am1", txtAddress1.Text.Trim().ToString(), selectControl1.SelectResult);
        }

        private void btnShow1_CheckedChanged(object sender, EventArgs e)
        {
            Show_Click(txtAddress1.Text.Trim().ToString());
        }

        private void btnStop1_CheckedChanged(object sender, EventArgs e)
        {
            Stop_Click(txtAddress1.Text.Trim().ToString());
        }

        private void btnSet2_CheckedChanged(object sender, EventArgs e)
        {
            Set_Click("Am2", txtAddress2.Text.Trim().ToString(), selectControl2.SelectResult);
        }

        private void btnShow2_CheckedChanged(object sender, EventArgs e)
        {
            Show_Click(txtAddress2.Text.Trim().ToString());
        }

        private void btnStop2_CheckedChanged(object sender, EventArgs e)
        {
            Stop_Click(txtAddress2.Text.Trim().ToString());
        }

        private void btnSet3_CheckedChanged(object sender, EventArgs e)
        {
            Set_Click("Am3", txtAddress3.Text.Trim().ToString(), selectControl3.SelectResult);
        }

        private void btnShow3_CheckedChanged(object sender, EventArgs e)
        {
            Show_Click(txtAddress3.Text.Trim().ToString());
        }

        private void btnStop3_CheckedChanged(object sender, EventArgs e)
        {
            Stop_Click(txtAddress3.Text.Trim().ToString());
        }

        private void btnSet4_CheckedChanged(object sender, EventArgs e)
        {
            Set_Click("Am4", txtAddress4.Text.Trim().ToString(), setControl1.SelectResult.ToString());
        }

        private void btnShow4_CheckedChanged(object sender, EventArgs e)
        {
            Show_Click(txtAddress4.Text.Trim().ToString());
        }

        private void btnStop4_CheckedChanged(object sender, EventArgs e)
        {
            Stop_Click(txtAddress4.Text.Trim().ToString());
        }

        private void btnSet5_CheckedChanged(object sender, EventArgs e)
        {
            string strData = "";
            if (txtData5.Text.ToString().Length > 5)
            {
                strData = txtData5.Text.ToString().Substring(0, 5);
            }
            else
            {
                strData = txtData5.Text.ToString().PadLeft(5, ' ');
            }
            Set_Click("Am7", txtAddress5.Text.Trim().ToString(), strData);
        }

        private void btnShow5_CheckedChanged(object sender, EventArgs e)
        {
            Show_Click(txtAddress5.Text.Trim().ToString());
        }

        private void btnStop5_CheckedChanged(object sender, EventArgs e)
        {
            Stop_Click(txtAddress5.Text.Trim().ToString());
        }
    }
}