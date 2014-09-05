using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Automation.Plugins.Share.Sorting.View.Dialog
{
    public partial class GeneratePackDataDialog : DevExpress.XtraEditors.XtraForm
    {
        public string Condition
        {
            get 
            {
                if (txtEndPackNo.Text.Length <= 0 || txtStartPackNo.Text.Length <= 0 || cmbExportNo.Text.Length <= 0)
                    return "";
                else
                    return string.Format("WHERE export_no='{0}' AND A.pack_no>={1} AND A.pack_no<={2}", cmbExportNo.Text, txtStartPackNo.Text, txtEndPackNo.Text);
            }
        }

        public GeneratePackDataDialog(DataTable table)
        {
            InitializeComponent();
            List<string> list = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(row["export_no"].ToString());
            }
            cmbExportNo.Properties.Items.AddRange(list);
        }
    }
}