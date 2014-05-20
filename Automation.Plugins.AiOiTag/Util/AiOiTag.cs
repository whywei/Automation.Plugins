using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Windows.Forms;

namespace Automation.Plugins.AiOiTag.Util
{
    public class AiOiTag
    {
        private Form Owner = null;

        public AxAiPlugControl.AxAiPlug axAiPlug;
        public bool IsOpen { get { return this.axAiPlug.IsConnected; } }

        public AiOiTag(Form owner)
        {
            Owner = owner ?? new Form();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            try
            {
                this.axAiPlug = new AxAiPlugControl.AxAiPlug();
                ((System.ComponentModel.ISupportInitialize)(this.axAiPlug)).BeginInit();
                Owner.Controls.Add(this.axAiPlug);
                ((System.ComponentModel.ISupportInitialize)(this.axAiPlug)).EndInit();
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("{0} 初始化失败，原因详情:{1}{2}", "AiOiTag", ex.Message, ex.StackTrace));
            }
        }

        public bool Open(string ip, short port)
        {
            if (this.axAiPlug.ConnectSocket(ip, port))
            {
                this.SendCommand("Z");
                this.axAiPlug.StartPolling(1);
            }
            return IsOpen;
        }

        public bool Reset()
        {
            return this.SendCommand("Z");
        }

        public bool Close()
        {
            if (this.axAiPlug.IsConnected)
            {
                this.SendCommand("Z");
                this.axAiPlug.StopPolling();
                return this.axAiPlug.CloseController();
            }
            else
            {
                return false;
            }
        }

        public bool SendCommand(string cmd)
        {
            if (this.axAiPlug.IsConnected)
            {
                return axAiPlug.SendCommand(cmd);
            }
            else
            {
                return false;
            }
        }

        public bool OperateWithMode(string address, string content, bool isBlink, bool isBuzz)
        {
            string cmd = string.Empty;
            if (isBuzz && isBlink)
            {
                //闪烁，蜂鸣
                cmd = "P501" + Convert.ToChar(57) + "@" + Convert.ToChar(0x47) + "@@" + address.Trim() + content.Trim().PadLeft(5, ' ');
            }
            else if (!isBuzz && isBlink)
            {
                //闪烁，不蜂鸣
                cmd = "P501" + Convert.ToChar(9) + "@" + Convert.ToChar(0x47) + "@@" + address.Trim() + content.Trim().PadLeft(5, ' ');
            }
            else if (isBuzz && !isBlink)
            {
                //不闪烁，蜂鸣
                cmd = "P501" + Convert.ToChar(53) + "@" + Convert.ToChar(0x47) + "@@" + address.Trim() + content.Trim().PadLeft(5, ' ');
            }
            else
            {
                //不闪烁，不蜂鸣
                cmd = "P501" + Convert.ToChar(5) + "@" + Convert.ToChar(0x47) + "@@" + address.Trim() + content.Trim().PadLeft(5, ' ');
            }

            return SendCommand(cmd);
        }

        public bool OperateStop(string address)
        {
            return SendCommand("D" + address);
        }

        public bool SetAddress(string address)
        {
            return SendCommand("Ac" + address);
        }

        public bool ShowAddress()
        {
            return SendCommand("A");
        }

        public bool SelfChecking(string address)
        {
            return SendCommand("Az" + address);
        }
    }
}
