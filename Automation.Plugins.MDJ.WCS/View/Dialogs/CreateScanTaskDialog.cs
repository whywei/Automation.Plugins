using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UnitConversion;

namespace Automation.Plugins.MDJ.WCS.View.Dialogs
{
    public partial class CreateScanTaskDialog : DevExpress.XtraEditors.XtraForm
    {
        public CreateScanTaskDialog(DataTable table)
        {
            InitializeComponent();
            lookUpEdit1.EditValue = "product_code";
            lookUpEdit1.Properties.DisplayMember = "product_name";
            lookUpEdit1.Properties.ValueMember = "product_code";
            lookUpEdit1.Properties.DataSource = table;
        }

        public string SelectedCigaretteCode
        {
            get { return lookUpEdit1.EditValue.ToString(); }
        }

        public string SelectedCigaretteName
        {
            get { return lookUpEdit1.Text.ToString(); }
        }

        public int Quantity
        {
            get
            {
                int i = 0;
                if (!int.TryParse(textEdit1.Text, out i))
                {
                    //DevExpress.Xpf.Core.DXMessageBox.Show("请输入数字！");
                    DevExpress.XtraEditors.XtraMessageBox.Show("请输入数字!");
                }
                return i;
            }
        }
    }
}