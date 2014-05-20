using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Automation.Plugin.MDJ.WCS.View.Dialog
{
    public partial class ModifyIPDialog : DevExpress.XtraEditors.XtraForm
    {
        public ModifyIPDialog(string IP,string Port)
        {
            InitializeComponent();
            txtIP.Text = IP;
            txtPort.Text = Port;
        }

        public string[] Result
        {
            get
            {
                return new string[] { txtIP.Text.ToString(), txtPort.Text.ToString() };
            }
        }
    }
}