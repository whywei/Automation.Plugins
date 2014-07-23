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

namespace Automation.Plugins.YZ.Sorting.View.Dialogs
{
    public partial class ChannelExchangeDialog : DevExpress.XtraEditors.XtraForm
    {
        ChannelDal channelDal = new ChannelDal();

        public ChannelExchangeDialog(DataTable Datatable)
        {
            InitializeComponent();
            string[] array = new string[Datatable.Rows.Count];
            for (int i = 0; i < Datatable.Rows.Count; i++)
            {
                DataRow dr = Datatable.Rows[i];
                array[i] = Convert.ToString(dr["channel_code"]);
            }
            comboBoxEdit1.Properties.Items.AddRange(array);
        }

        public string SelectedChannelCode
        {
            get { return comboBoxEdit1.SelectedIndex.ToString(); }
        }
    }
}
