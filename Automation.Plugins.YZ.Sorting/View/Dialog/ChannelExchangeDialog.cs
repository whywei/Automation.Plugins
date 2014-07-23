using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.View.Controls;
using Automation.Plugins.YZ.Sorting.Dal;

namespace Automation.Plugins.YZ.Sorting.View.Dialog
{
    public partial class ChannelExchangeDialog : DevExpress.XtraEditors.XtraForm
    {
        ChannelDal channelDal = new ChannelDal();

        public ChannelExchangeDialog(DataTable datatable)
        {
            InitializeComponent();
            
            lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("channel_code", 20, "烟道编码"));
            lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("channel_name", 20, "烟道名称"));

            lookUpEdit1.EditValue = "channel_code";
            lookUpEdit1.Properties.ValueMember = "channel_code";
            lookUpEdit1.Properties.DisplayMember = "channel_name";
            lookUpEdit1.Properties.NullText = null;
            lookUpEdit1.Properties.DataSource = datatable;
        }
    }
}
