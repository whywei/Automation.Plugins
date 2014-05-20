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
    public partial class StockOutDialog : DevExpress.XtraEditors.XtraForm
    {
        public int StockOutQuantity
        {
            get
            {
                int i = 0;
                if (!int.TryParse(txtStockOutQuantity.Text, out i))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("请输入数字!");
                }
                return i;
            }
        }

        private TaskDal taskDal = new TaskDal();

        public StockOutDialog(int taskID)
        {
            InitializeComponent();

            txtTaskID.Text = taskID.ToString();
            txtCellName.Text = taskDal.GetStockOutCellName(taskID);
            txtProductName.Text = taskDal.GetProductName(taskID);
            txtQuantity.Text = taskDal.GetStorageQuantity(taskID);
            txtStockOutQuantity.Text = taskDal.GetStockOutQuantity(taskID);
        }

        private void StockOutDialog_Shown(object sender, EventArgs e)
        {
            txtStockOutQuantity.Focus();
        }
    }
}
