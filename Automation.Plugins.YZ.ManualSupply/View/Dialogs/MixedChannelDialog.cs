using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Automation.Plugins.YZ.ManualSupply.View.Dialogs
{
    public partial class MixedChannelDialog : DevExpress.XtraEditors.XtraForm
    {
        public MixedChannelDialog(DataTable table)
        {
            InitializeComponent();
            lookUpEdit1.EditValue ="null";
            lookUpEdit1.Properties.DisplayMember = "channel_name";
            lookUpEdit1.Properties.ValueMember = "channel_code";
            lookUpEdit1.Properties.DataSource = table;
        }

        public string SelectedChannelCode
        {
            get { return lookUpEdit1.EditValue.ToString(); }
        }

        public string SelectedChannelName
        {
            get { return lookUpEdit1.Text.ToString(); }
        }
        
    }
}