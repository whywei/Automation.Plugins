using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugin.MDJ.WCS.View.Dialog;
using System.Windows.Forms;
using Automation.Plugins.AiOiTag.Properties;
using DevExpress.XtraEditors;
using Automation.Plugins.AiOiTag.View.Dialog;

namespace Automation.Plugins.AiOiTag.Action
{
    public class TagManagerAction : AbstractAction
    {
        private const string rootKey = "kTag";
        private TextEntryActionItem _txtIP = new TextEntryActionItem ();
        private TextEntryActionItem _txtPort = new TextEntryActionItem();
        Automation.Plugins.AiOiTag.Util.AiOiTag aiOiTag = new Automation.Plugins.AiOiTag.Util.AiOiTag(new Form());

        public override void Initialize()
        {
            DefaultSortOrder = 1;
        }

        public override void Activate()
        {
            IHeaderControl header = App.HeaderControl;

            //_txtIP = new TextEntryActionItem() { RootKey = rootKey, GroupCaption = "配置", Width = 170, Text = "192.168.2.240" };
            //header.Add(_txtIP);
            _txtIP.Width = 120;
            _txtIP.ToolTipText = "23211";
            _txtIP.GroupCaption = "配置";
            _txtIP.RootKey = rootKey;
            _txtIP.Caption = "控制器IP：";
            _txtIP.Enabled = false;
            header.Add(_txtIP);
            _txtIP.Text = "192.168.1.254";
            _txtPort.Width = 120;
            _txtPort.GroupCaption = "配置";
            _txtPort.RootKey = rootKey;
            _txtPort.Caption = "　端口号：";
            _txtPort.Enabled = false;
            header.Add(_txtPort);
            _txtPort.Text = "5003";
            header.Add(new SimpleActionItem(rootKey, "设置IP", SetIP_Click) { GroupCaption = "配置", SmallImage = Resources.set_address_16x16, LargeImage = Resources.set_address_32x32 });

            header.Add(new SimpleActionItem(rootKey, "设置地址", SetAdress_Click) { GroupCaption = "测试", SmallImage = Resources.set_address_16x16, LargeImage = Resources.set_address_32x32 });
            header.Add(new SimpleActionItem(rootKey, "显示地址", ShowAdress_Click) { GroupCaption = "测试", SmallImage = Resources.show_16x16, LargeImage = Resources.show_32x32 });
            header.Add(new SimpleActionItem(rootKey, "停止显示", Stop_Click) { GroupCaption = "测试", SmallImage = Resources.show_stop_16x16, LargeImage = Resources.show_stop_32x32 });
            header.Add(new SimpleActionItem(rootKey, "指令测试", Cmd_Click) { GroupCaption = "测试", SmallImage = Resources.cmd_16x16, LargeImage = Resources.cmd_32x32 }); 
        }

        private void SetAdress_Click(object sender, EventArgs e)
        {
            SetAdressDialog setAdressDialog = new SetAdressDialog(_txtIP.Text, _txtPort.Text);
            setAdressDialog.ShowDialog();
        }

        private void ShowAdress_Click(object sender, EventArgs e)
        {
            if (!aiOiTag.IsOpen)
            {
                short port=0;
                try
                {
                    port=Convert.ToInt16(_txtPort.Text.ToString());
                }
                catch
                {
                    XtraMessageBox.Show("端口号不符合要求！","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
                if (!aiOiTag.Open(_txtIP.Text.ToString(), port))
                {
                    XtraMessageBox.Show("打开连接失败，\n请检查IP和端口号是否正确!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            aiOiTag.ShowAddress();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (!aiOiTag.IsOpen)
            {
                short port = 0;
                try
                {
                    port = Convert.ToInt16(_txtPort.Text.ToString());
                }
                catch
                {
                    XtraMessageBox.Show("端口号不符合要求！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!aiOiTag.Open(_txtIP.Text.ToString(), port))
                {
                    XtraMessageBox.Show("打开连接失败，\n请检查IP和端口号是否正确!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            aiOiTag.Close();
        }

        private void Cmd_Click(object sender, EventArgs e)
        {
            CmdDialog cmdDialog = new CmdDialog(_txtIP.Text.ToString(), _txtPort.Text.ToString());
            cmdDialog.Text = "指令测试    控制器IP：" + _txtIP.Text.ToString() + "   端口号：" + _txtPort.Text.ToString();
            cmdDialog.ShowDialog();
        }

        private void SetIP_Click(object sender, EventArgs e)
        {
            ModifyIPDialog modifyIPDialog = new ModifyIPDialog(_txtIP.Text,_txtPort.Text);
            if (modifyIPDialog.ShowDialog() == DialogResult.OK)
            {
                _txtIP.Text = modifyIPDialog.Result[0];
                _txtPort.Text = modifyIPDialog.Result[1];
            }
        }
    }
}
