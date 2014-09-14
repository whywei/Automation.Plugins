using DotSpatial.Controls;
using Automation.Core;
using System.ComponentModel.Composition;
using DotSpatial.Controls.Header;
using System.Windows.Forms;
using Automation.Plugins.Share.Stocking.Properties;
using System;
using Automation.Plugins.Share.Stocking.View;
using Automation.Plugins.Share.Stocking.View.Dialog;
using System.Reflection;
using System.Drawing;
using Automation.Plugins.Share.Stocking.Dal;
using System.Data;
using DevExpress.XtraEditors;
using System.Linq;
using Automation.Core;

namespace Automation.Plugins.Share.Stocking
{
    public class StockingPlugin : Extension
    {
        [Import]
        public AutomationContext AutomationContext { get; set; }        

        [Import("Shell", typeof(ContainerControl))]
        public ContainerControl Shell { get; set; }

        private SimpleActionItem btnUpdateBarcode = null;
        private SimpleActionItem btnStart = null;
        private SimpleActionItem btnStop = null;
        private UpdateBarcodeDialog UpdateBarcodeDialog = new UpdateBarcodeDialog();

        public override void Activate()
        {
            AddHeaderRootItems();
            AutomationContext.ActivateAction();
            AutomationContext.ActivateView();     
            base.Activate();            
        }

        public override void Deactivate()
        {
            AutomationContext.DeactivateAction();
            AutomationContext.DeactivateView();
            App.HeaderControl.RemoveAll();
            base.Deactivate();
        }

        private void AddHeaderRootItems()
        {
            IHeaderControl header = App.HeaderControl;
            header.Add(new RootItem("kStocking", "补货") { SortOrder = 104 });

            btnUpdateBarcode = new SimpleActionItem("kStocking", "更新条码", UpdateBarcode_Click) { GroupCaption = "操作", SortOrder = 1, LargeImage = Resources.UpdateBarcode_32 };
            header.Add(btnUpdateBarcode);
            btnStart = new SimpleActionItem("kStocking", "开始补货", StartStock_Click) { GroupCaption = "操作", SortOrder = 2, LargeImage = Resources.start_32x32 };
            header.Add(btnStart);
            btnStop = new SimpleActionItem("kStocking", "停止补货", StopStock_click) { GroupCaption = "操作", SortOrder = 3, Enabled = false, LargeImage = Resources.spouse_32x32 };
            header.Add(btnStop);

            header.Add(new SimpleActionItem("kStocking", "拆盘位置", StockPosition_Click) { GroupCaption = "查询", SortOrder = 1, LargeImage = Resources.position_32 });
            header.Add(new SimpleActionItem("kStocking", "位置库存", StockPositionStorage_Click) {  GroupCaption = "查询", SortOrder = 2, LargeImage = Resources.yandao_32x32 });
            header.Add(new SimpleActionItem("kStocking", "补货任务", StockTask_Click) { GroupCaption = "查询", SortOrder = 3, LargeImage = Resources.Task_32 });

            UpdateBarcodeDialog.Load += new EventHandler(UpdateBarcodeDialog_Load);
            UpdateBarcodeDialog.btnOK.Click += new EventHandler(UpdateBarcodeDialog_btnOK_Click);
        }

        private void UpdateBarcode_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            UpdateBarcodeDialog.Icon = Icon.ExtractAssociatedIcon(assembly.Location);
            UpdateBarcodeDialog.ShowDialog();
        }

        private void StartStock_Click(object sender, EventArgs e)
        {
            try
            {
                OrderDal orderDal = new OrderDal();
                DataTable productTable = orderDal.FindProduct();

                int[] productBarcodeList = new int[200];
                string[] productNameList = new string[200];

                for (int i = 0; i < productTable.Rows.Count; i++)
                {
                    if (productTable.Rows[i]["piece_barcode"] != null && productTable.Rows[i]["piece_barcode"].ToString().Trim().Length == 6)
                    {
                        productBarcodeList[i] = Convert.ToInt32(productTable.Rows[i]["piece_barcode"].ToString().Trim());
                        productNameList[i] = productTable.Rows[i]["product_name"].ToString();
                    }
                    else
                    {
                        string msg = string.Format("{0}:{1}条码格式不正确，", productTable.Rows[i]["piece_barcode"], productTable.Rows[i]["product_name"]);
                        Logger.Error(msg);
                        XtraMessageBox.Show(msg, "提示");
                        return;
                    }
                }

                var tmp = productBarcodeList.Where(p => productBarcodeList.Where(b => b == p).Count() > 1);
                if (tmp.Count() > 0)
                {
                    string msg = string.Format("{0} ,条码重复，请检查！",tmp.ToArray().ConvertToString());
                    Logger.Error(msg);
                    XtraMessageBox.Show(msg, "提示");
                    return;
                }

                productNameList.AsParallel().ForAll(n => { 
                    n =  System.Text.Encoding.GetEncoding("gb2312").GetString(System.Text.Encoding.Default.GetBytes(n));
                });

                Ops.Write(Global.PLC_SERVICE_NAME, "Cigarette_Barcode_Information", productBarcodeList);
                Ops.Write(Global.PLC_SERVICE_NAME, "Cigarette_Name_Information", productNameList);

                SwitchStatus(true);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Logger.Error(msg);
                XtraMessageBox.Show(msg, "提示");
            }
        }

        private void StopStock_click(object sender, EventArgs e)
        {
            SwitchStatus(false);
        }

        private void SwitchStatus(bool isStart)
        {
            if (Ops.Write(Global.MemoryTemporarilySingleDataService, Global.MemoryItemNameStockState, isStart))
            {
                btnUpdateBarcode.Enabled = !isStart;
                btnStart.Enabled = !isStart;
                btnStop.Enabled = isStart;
            }
        }

        private void StockPosition_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<StockPositionView>();
        }

        private void StockPositionStorage_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<StockPositionStorageView>();
        }

        private void StockTask_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<StockTaskView>();
        }

        private void UpdateBarcodeDialog_Load(object sender, EventArgs e)
        {
            OrderDal orderDal = new OrderDal();
            DataTable productTable = orderDal.FindProduct();
            UpdateBarcodeDialog.cmbProduct.Properties.ValueMember = "product_code";
            UpdateBarcodeDialog.cmbProduct.Properties.DisplayMember = "product_name";
            UpdateBarcodeDialog.cmbProduct.Properties.DataSource = productTable;
        }

        private void UpdateBarcodeDialog_btnOK_Click(object sender, EventArgs e)
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
