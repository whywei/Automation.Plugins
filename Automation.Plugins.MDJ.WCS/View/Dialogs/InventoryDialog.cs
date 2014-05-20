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
    public partial class InventoryDialog : DevExpress.XtraEditors.XtraForm
    {

        public int RealQuantity
        {
            get
            {
                int i = 0;
                if (!int.TryParse(txtRealQuantity.Text, out i))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("请输入数字!");
                }
                return i;
            }
        }

        private TaskDal taskDal = new TaskDal();

        public InventoryDialog(int taskID)
        {
            InitializeComponent();

            txtTaskID.Text = taskID.ToString();
            txtCellName.Text = taskDal.GetStockOutCellName(taskID);
            txtProductName.Text = taskDal.GetProductName(taskID);
            txtQuantity.Text = taskDal.GetStorageQuantity(taskID);
        }

        private void InventoryDialog_Shown(object sender, EventArgs e)
        {
            txtRealQuantity.Focus();
        }
    }
}
