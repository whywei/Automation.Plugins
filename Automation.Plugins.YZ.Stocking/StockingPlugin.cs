using DotSpatial.Controls;
using Automation.Core;
using System.ComponentModel.Composition;
using DotSpatial.Controls.Header;
using System.Windows.Forms;
using Automation.Plugins.YZ.Stocking.Properties;
using System;
using Automation.Plugins.YZ.Stocking.View;
using Automation.Plugins.YZ.Stocking.View.Dialog;
using System.Reflection;
using System.Drawing;
using Automation.Plugins.YZ.Stocking.Dal;
using System.Data;
using DevExpress.XtraEditors;

namespace Automation.Plugins.YZ.Stocking
{
    public class StockingPlugin : Extension
    {
        [Import]
        public AutomationContext AutomationContext { get; set; }
        [Import]
        public UpdateBarcodeDialog UpdateBarcodeDialog { get; set; }

        [Import("Shell", typeof(ContainerControl))]
        public ContainerControl Shell { get; set; }

        private SimpleActionItem btnUpdateBarcode = null;
        private SimpleActionItem btnStart = null;
        private SimpleActionItem btnStop = null;

        public override void Activate()
        {
            AddHeaderRootItems();
            AutomationContext.ActivateAction();
            AutomationContext.ActivateView();     
            base.Activate();            
        }

        public override void Deactivate()
        {
            AutomationContext.DeactivateView();
            App.HeaderControl.RemoveAll();
            base.Deactivate();
        }

        private void AddHeaderRootItems()
        {
            IHeaderControl header = App.HeaderControl;
            header.Add(new RootItem("kStocking", "补货") { SortOrder = 104 });
            btnUpdateBarcode = new SimpleActionItem("kStocking", "更新条码", UpdateBarcode_Click) { ToolTipText = "更新条码", GroupCaption = "操作", SortOrder = 1, LargeImage = Resources.UpdateBarcode_32 };
            header.Add(btnUpdateBarcode);
            btnStart = new SimpleActionItem("kStocking", "开始补货", StartStock_Click) { ToolTipText = "开始补货", GroupCaption = "操作", SortOrder = 2, LargeImage = Resources.start_32x32 };
            header.Add(btnStart);
            btnStop = new SimpleActionItem("kStocking", "停止补货", StopStock_click) { Enabled = false, ToolTipText = "停止补货", GroupCaption = "操作", SortOrder = 3, LargeImage = Resources.spouse_32x32 };
            header.Add(btnStop);
            header.Add(new SimpleActionItem("kStocking", "拆盘位置", StockPosition_Click) { ToolTipText = "补货状态", GroupCaption = "查询", SortOrder = 1, LargeImage = Resources.position_32 });
            header.Add(new SimpleActionItem("kStocking", "位置库存", StockPosition_Click) { ToolTipText = "拆盘位置", GroupCaption = "查询", SortOrder = 2, LargeImage = Resources.yandao_32x32 });
            header.Add(new SimpleActionItem("kStocking", "补货任务", StockStatus_Click) { ToolTipText = "补货状态", GroupCaption = "查询", SortOrder = 3, LargeImage = Resources.Task_32 });

            UpdateBarcodeDialog.Load+=new EventHandler(dialog_Load);
            UpdateBarcodeDialog.btnOK.Click += new EventHandler(btnOK_Click);
        }

        private void UpdateBarcode_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            UpdateBarcodeDialog.Icon = Icon.ExtractAssociatedIcon(assembly.Location);
            UpdateBarcodeDialog.ShowDialog();
        }

        private void StartStock_Click(object sender, EventArgs e)
        {
            SwitchStatus(true);
            OrderDal orderDal = new OrderDal();
            DataTable product = orderDal.FindProductInformation();
            int[] productCodeList = new int[product.Rows.Count];
            string[] productNameList = new string[product.Rows.Count];
            for (int i = 0; i < product.Rows.Count ; i++)
            {
                if (product.Rows[i]["piece_barcode"].ToString().Trim().Length != 6)
                {
                    productCodeList[i] = i+1;
                }
                else
                {
                    productCodeList[i] = Convert.ToInt32(product.Rows[i]["piece_barcode"]);
                }
                productNameList[i] = product.Rows[i]["product_name"].ToString().Substring(0, 13);
            }
            Ops.Write(Global.plcServiceName, "Cigarette_Barcode_Information", productCodeList);
            Ops.Write(Global.plcServiceName, "Cigarette_Name_Information", productNameList);
        }

        private void StopStock_click(object sender, EventArgs e)
        {
            SwitchStatus(false);
        }

        private void SwitchStatus(bool isStart)
        {
            if (AutomationContext.Write(Global.memoryServiceName_TemporarilySingleData, Global.memoryItemName_SortingState, isStart))
            {
                btnUpdateBarcode.Enabled = !isStart;
                btnStart.Enabled = !isStart;
                btnStop.Enabled = isStart;
            }
        }

        private void StockStatus_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<StockStatusView>();
        }

        private void StockPosition_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<StockPositionView>();
        }

        private void dialog_Load(object sender,EventArgs e)
        {
            OrderDal orderDal = new OrderDal();
            DataTable product = orderDal.FindProductFromOrder();
            UpdateBarcodeDialog.cmbProduct.Properties.ValueMember = "product_code";
            UpdateBarcodeDialog.cmbProduct.Properties.DisplayMember = "product_name";
            UpdateBarcodeDialog.cmbProduct.Properties.DataSource = product;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string productCode = UpdateBarcodeDialog.cmbProduct.EditValue.ToString().Trim();
            if (productCode.Length <= 0)
            {
                XtraMessageBox.Show("请选择卷烟名称！", "提示");
                return;
            }
            string barcode = UpdateBarcodeDialog.txtBarcode.Text.Trim();
            if (barcode.Length != 6)
            {
                XtraMessageBox.Show("条码长度必须为六位数！", "提示");
                return;
            }
            ProductDal productDal = new ProductDal();
            productDal.UpdateBarcode(productCode, barcode);
            StockTaskDal stockTaskDal = new StockTaskDal();
            stockTaskDal.UpdateBarcode(productCode, barcode);
            UpdateBarcodeDialog.Close();
        }
    }
}
