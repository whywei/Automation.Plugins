using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.Composition;

namespace Automation.Plugins.YZ.Stocking.View.Dialog
{
    [Export(typeof(UpdateBarcodeDialog))]
    public partial class UpdateBarcodeDialog : DevExpress.XtraEditors.XtraForm
    {
        public UpdateBarcodeDialog()
        {
            InitializeComponent();
        }
    }
}