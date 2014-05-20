using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Plugins.MDJ.WCS.Dal;
using Automation.Core.Util;

namespace Automation.Plugins.MDJ.WCS.View.Dialogs
{
    public partial class UpdateBarcodeDialog : DevExpress.XtraEditors.XtraForm
    {
        private string text = "";

        public UpdateBarcodeDialog(CigaretteScanInfo[] table)
        {
            InitializeComponent();
            lookUpEdit1.Properties.DataSource = table;
            lookUpEdit1.Properties.ValueMember = "ProductCode";
            lookUpEdit1.Properties.DisplayMember = "ProductName";
        }

        private void UpdateBarcodeDialog_Load(object sender, EventArgs e)
        {
            pictureEdit1.Image = GraphicsUtil.CreateRandomBitmap(out text);
        }

        public bool IsPass
        {
            get { return textEdit2.Text == text; }
        }

        public string SelectedCigaretteCode
        {
            get { return lookUpEdit1.EditValue.ToString(); }
        }

        public string Barcode
        {
            get { return textEdit1.Text.ToString(); }
        }

        internal void setInformation(string text,string barcode)
        {
            this.Text = text;
            textEdit1.Text = barcode;
        }
    }
}
