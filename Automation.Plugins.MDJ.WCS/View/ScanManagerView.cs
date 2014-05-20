using System;
using Automation.Core;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel.Composition;
using Automation.Plugins.MDJ.WCS.Properties;
using Automation.Plugins.MDJ.WCS.View.Controls;
using DevExpress.XtraEditors;
using Automation.Plugins.MDJ.WCS;
using Automation.Plugins.MDJ.WCS.Dal;
using Automation.Plugins.MDJ.WCS.View.Dialogs;
using System.Linq;
using System.Threading;
using DevExpress.XtraGrid;
using System.Collections.Generic;
using System.Data;
using DevExpress.Data;
using System.Linq;

namespace Automation.MainPlugin.View
{
    public class ScanManagerView : AbstractView, IPartImportsSatisfiedNotification
    {
        private const string memoryServiceName = "MemoryPermanentSingleDataService";
        private const string memoryItemName = "CigaretteScanInfoStack";

        private GridControl gridControl = null;
        private GridView gridView = null;

        private const string plcServiceName = "THOKPLC";        
        private const string O_StockIn_Scan_Info = "O_StockIn_Scan_Info";
        private const string I_StockIn_Scan_Info = "I_StockIn_Scan_Info";
        private const string O_StockIn_Scan_Complete = "O_StockIn_Scan_Complete";
        private const string O_StockIn_Scan_Cancel = "O_StockIn_Scan_Cancel";

        public static IDictionary<string, CigaretteScanInfo> cigaretteScanInfoStack = null;
        
        public IDictionary<string, CigaretteScanInfo> CigaretteScanInfoStack
        {
            get
            {
                return cigaretteScanInfoStack;
            }
            set
            {
                cigaretteScanInfoStack = value;
            }
        }

        public override void Initialize()
        {
            this.DefaultSortOrder = 101;
        }

        public override void Activate()
        {
            this.Key = "kScan";
            this.Caption = "件烟扫码";
            this.InnerControl = new ScanManagerPanel();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.info_rhombus_32x32;
            this.gridControl = ((ScanManagerPanel)this.InnerControl).gridControl1;
            this.gridView = ((ScanManagerPanel)this.InnerControl).gridView1;
        }

        public override void RefreshView()
        {
            Refresh();
        }

        public void OnImportsSatisfied()
        {
            App.ExtensionsActivated += new EventHandler(App_ExtensionsActivated);
        }

        private void App_ExtensionsActivated(object sender, EventArgs e)
        {
            Refresh();
        }

        private RealTimeSource realTimeSource = new RealTimeSource();
        internal void Refresh()
        {
            if (!ScanManagerView.InitCigaretteScanInfoStack()) return;
            realTimeSource.DataSource = CigaretteScanInfoStack.Values.OrderByDescending(c => c.State).ThenBy(c => c.Index).ToArray();
            if (gridControl.DataSource == null)
            {
                gridControl.DataSource = realTimeSource;
            }
        }

        internal void Read()
        {
            if (!ScanManagerView.InitCigaretteScanInfoStack()) return;
            TaskDal task = new TaskDal();
            var table = task.FindStockInProduct();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    ProductDal productDal = new ProductDal();
                    CigaretteScanInfo info = productDal.FindProductForScan(Convert.ToString(row["product_code"]));
                    if (info != null && !CigaretteScanInfoStack.Keys.Contains(Convert.ToString(row["product_code"])))
                    {
                        info.ProductCode = Convert.ToString(row["product_code"]);
                        info.ProductName = Convert.ToString(row["product_name"]);
                        info.Quantity = Convert.ToInt32(row["task_quantity"]);
                        info.Index = 0;
                        info.State = "0";
                        lock (CigaretteScanInfoStack)
                        {
                            CigaretteScanInfoStack.Add(info.ProductCode, info);
                        }
                    }
                    else if (info == null)
                    {
                        XtraMessageBox.Show(string.Format("当前卷烟 {0} : {1} 没有尺寸信息，请先行进行维护！",
                            Convert.ToString(row["product_code"]), Convert.ToString(row["product_name"]))
                            , "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show(string.Format("当前卷烟 {0} : {1} 已有扫码任务！",
                            Convert.ToString(row["product_code"]), Convert.ToString(row["product_name"]))
                            , "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                AutomationContext.Write(memoryServiceName, memoryItemName, CigaretteScanInfoStack);
            }
            else
            {
                XtraMessageBox.Show("当前没有卷烟入库任务！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            Refresh();
        }

        internal void New()
        {
            if (!ScanManagerView.InitCigaretteScanInfoStack()) return;
            TaskDal task = new TaskDal();
            var table = task.FindStockInProduct();
            if (table.Rows.Count > 0)
            {
                CreateScanTaskDialog createScanTaskDialog = new CreateScanTaskDialog(table);
                if (createScanTaskDialog.ShowDialog() == DialogResult.OK && createScanTaskDialog.Quantity > 0)
                {
                    ProductDal productDal = new ProductDal();
                    CigaretteScanInfo info = productDal.FindProductForScan(createScanTaskDialog.SelectedCigaretteCode);
                    if (info != null && !CigaretteScanInfoStack.Keys.Contains(createScanTaskDialog.SelectedCigaretteCode))
                    {
                        info.ProductCode = createScanTaskDialog.SelectedCigaretteCode;
                        info.ProductName = createScanTaskDialog.SelectedCigaretteName;
                        info.Quantity = createScanTaskDialog.Quantity;
                        info.Index = 0;
                        info.State = "0";
                        lock (CigaretteScanInfoStack)
                        {
                            CigaretteScanInfoStack.Add(info.ProductCode, info);
                        }
                        AutomationContext.Write(memoryServiceName, memoryItemName, CigaretteScanInfoStack);
                    }
                    else if (info == null)
                    {
                        XtraMessageBox.Show("当前卷烟没有尺寸信息，请先行进行维护！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("当前卷烟已有扫码任务！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("当卷烟没有入库任务！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Refresh();
        }
               
        internal void Scan()
        {
            if (!ScanManagerView.InitCigaretteScanInfoStack()) return;
            string productCode = gridView.GetSelectedRows().Count() >0 ? gridView.GetRowCellValue(gridView.GetSelectedRows()[0], "ProductCode").ToString() : "";
            CigaretteScanInfo info = CigaretteScanInfoStack.Keys.Contains(productCode)
                                        ? CigaretteScanInfoStack[productCode] : null;
            if (info == null)
            {
                XtraMessageBox.Show("请选择要扫码的品牌！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (info.State == "2" || info.State == "3" || info.State == "4")
            {
                XtraMessageBox.Show("请选择未扫码的品牌！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int[] data = new int[] { info.ProductNo, info.Quantity - info.ScanQuantity, info.Length, info.Width, info.Height, info.AreaNo, 1 };
            if (AutomationContext.Write(plcServiceName, O_StockIn_Scan_Info, data))
            {
                Thread.Sleep(1000);
                object obj = AutomationContext.Read(plcServiceName, I_StockIn_Scan_Info);
                if (obj is Array)
                {
                    Array arrayObj = (Array)obj;
                    if (arrayObj.Length == 7
                        && data[0] == Convert.ToInt32(arrayObj.GetValue(0))
                        && data[1] == Convert.ToInt32(arrayObj.GetValue(1))
                        && data[2] == Convert.ToInt32(arrayObj.GetValue(2))
                        && data[3] == Convert.ToInt32(arrayObj.GetValue(3))
                        && data[4] == Convert.ToInt32(arrayObj.GetValue(4))
                        && data[5] == Convert.ToInt32(arrayObj.GetValue(5))
                        && data[6] == Convert.ToInt32(arrayObj.GetValue(6)))
                    {
                        if (AutomationContext.Write(plcServiceName, O_StockIn_Scan_Complete, 1))
                        {
                            info.Index = CigaretteScanInfoStack.Values.Max(c => c.Index) + 1;
                            info.State = "2";
                            AutomationContext.Write(memoryServiceName, memoryItemName, CigaretteScanInfoStack);
                        }
                    }
                }
            }
            Refresh();
        }

        internal void Pause()
        {
            if (!ScanManagerView.InitCigaretteScanInfoStack()) return;
            string productCode = gridView.GetSelectedRows().Count() > 0 ? gridView.GetRowCellValue(gridView.GetSelectedRows()[0], "ProductCode").ToString() : "";
            CigaretteScanInfo info = CigaretteScanInfoStack.Keys.Contains(productCode)
                                        ? CigaretteScanInfoStack[productCode] : null;
            if (info == null)
            {
                XtraMessageBox.Show("请选择要停止扫码的品牌！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (info.State == "0" || info.State == "1" || info.State == "4")
            {
                XtraMessageBox.Show("请选择等待扫码或正在扫码的品牌！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string productName = gridView.GetSelectedRows().Count() > 0 ? gridView.GetRowCellValue(gridView.GetSelectedRows()[0], "ProductName").ToString() : "";
            if (XtraMessageBox.Show("确认暂停扫码？当前[" + productName + "]码盘会清空！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                info.Index = 0; info.State = "1";
                AutomationContext.Write(plcServiceName, O_StockIn_Scan_Cancel, info.ProductNo);
                lock (CigaretteScanInfoStack)
                {
                    CigaretteScanInfoStack.Remove(info.ProductCode);
                }                
                AutomationContext.Write(memoryServiceName, memoryItemName, CigaretteScanInfoStack);
            }
            Refresh();
        }

        internal void Complete()
        {
            if (!ScanManagerView.InitCigaretteScanInfoStack()) return;
            string productCode = gridView.GetSelectedRows().Count() > 0 ? gridView.GetRowCellValue(gridView.GetSelectedRows()[0], "ProductCode").ToString() : "";
            CigaretteScanInfo info = CigaretteScanInfoStack.Keys.Contains(productCode)
                                        ? CigaretteScanInfoStack[productCode] : null;
            if (info == null)
            {
                XtraMessageBox.Show("请选择要完成扫码的品牌！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (info.State != "3")
            {
                XtraMessageBox.Show("请选择正在扫码的品牌！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string productName = gridView.GetSelectedRows().Count() > 0 ? gridView.GetRowCellValue(gridView.GetSelectedRows()[0], "ProductName").ToString() : "";
            if (XtraMessageBox.Show("确认完成扫码吗？当前[" + productName + "]码盘是否确实已完成！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                info.Index = 0; info.State = "4";
                lock (CigaretteScanInfoStack)
                {
                    CigaretteScanInfoStack.Remove(info.ProductCode);
                }
                AutomationContext.Write(memoryServiceName, memoryItemName, CigaretteScanInfoStack);
            }
            Refresh();
        }

        internal void Stop()
        {
            if (!ScanManagerView.InitCigaretteScanInfoStack()) return;
            if (XtraMessageBox.Show("确认停止扫码？所有的数据会清空，请谨慎操作！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                AutomationContext.Write(plcServiceName, O_StockIn_Scan_Cancel, 10000);
                lock (CigaretteScanInfoStack)
                {
                    CigaretteScanInfoStack.Clear();
                }
                AutomationContext.Write(memoryServiceName, memoryItemName, CigaretteScanInfoStack);
            }
            Refresh();
        }

        internal void UploadSize()
        {
            foreach (var cigaretteScanInfo in CigaretteScanInfoStack.Values)
            {
                ProductDal productDal = new ProductDal();
                CigaretteScanInfo info = productDal.FindProductForScan(cigaretteScanInfo.ProductCode);
                cigaretteScanInfo.ProductNo = info.ProductNo;
                cigaretteScanInfo.Length = info.Length;
                cigaretteScanInfo.Width = info.Width;
                cigaretteScanInfo.Height = info.Height;
                cigaretteScanInfo.Barcode = info.Barcode;
            }
            AutomationContext.Write(memoryServiceName, memoryItemName, CigaretteScanInfoStack);
        }

        internal void UpdateBarcode(string text, string productCode, string barcode)
        {
            if (!ScanManagerView.InitCigaretteScanInfoStack()) return;
            ProductDal productDal = new ProductDal();
            if (barcode != string.Empty && productDal.Exist(barcode))
                return;
            DataTable table = productDal.FindProduct(productCode);
            if (table.Rows.Count > 0)
            {
                UpdateBarcodeDialog updateBarcodeDialog = new UpdateBarcodeDialog(CigaretteScanInfoStack.Values.ToArray());
                updateBarcodeDialog.setInformation(text, barcode);
                if (updateBarcodeDialog.ShowDialog() == DialogResult.OK)
                {
                    if (updateBarcodeDialog.IsPass && updateBarcodeDialog.Barcode.Length == 6)
                    {
                        productCode = updateBarcodeDialog.SelectedCigaretteCode;
                        barcode = updateBarcodeDialog.Barcode;
                        productDal.UpdateBarcode(productCode, barcode);
                        CigaretteScanInfoStack[productCode].Barcode = barcode;
                        AutomationContext.Write(memoryServiceName, memoryItemName, CigaretteScanInfoStack);
                    }
                    else
                    {
                        XtraMessageBox.Show("验证码错误,或者条码格式不对！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private static object locker = new object();
        public static bool InitCigaretteScanInfoStack()
        {
            if (cigaretteScanInfoStack == null)
            {
                lock (locker)
                {
                    cigaretteScanInfoStack = Ops.Read(memoryServiceName, memoryItemName) as IDictionary<string, CigaretteScanInfo>;
                    if (cigaretteScanInfoStack == null)
                    {
                        cigaretteScanInfoStack = new Dictionary<string, CigaretteScanInfo>();
                    }
                }
            }

            if (cigaretteScanInfoStack == null) return false;
            Ops.Write(memoryServiceName, memoryItemName, cigaretteScanInfoStack);
            return true;
        }
    }
}
