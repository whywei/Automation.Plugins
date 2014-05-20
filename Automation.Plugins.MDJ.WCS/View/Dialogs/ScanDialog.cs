using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Automation.Plugins.MDJ.WCS.Dal;

namespace Automation.Plugins.MDJ.WCS.View.Dialogs
{
    public partial class ScanDialog : DevExpress.XtraEditors.XtraForm
    {
        public ScanDialog()
        {
            InitializeComponent();
        }

        private ProductDal productDal = new ProductDal();
        public int ProductNo
        {
            get { return productDal.GetProductNo(txtBarcode.Text); }
        }

        public int Quantity
        {
            get
            {
                int i = 0;
                if (!int.TryParse(txtQuantity.Text, out i))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("请输入数字!");
                }
                return i;
            }
        }

        public void SetBarcode(string barcode)
        {
            txtBarcode.Text = barcode;
        }

        private void ScanDialog_Shown(object sender, EventArgs e)
        {
            txtQuantity.Focus();
        }

        private void btnEdit_CheckedChanged(object sender, EventArgs e)
        {
            this.txtBarcode.Properties.ReadOnly = false;
        }
    }
}