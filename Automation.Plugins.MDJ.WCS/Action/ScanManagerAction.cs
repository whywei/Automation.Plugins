using System;
using Automation.Core;
using DotSpatial.Controls.Header;
using System.Windows.Forms;
using System.Threading.Tasks;
using DevExpress.XtraSplashScreen;
using Automation.Plugins.MDJ.WCS.Properties;
using Automation.Plugins.MDJ.WCS;
using DevExpress.XtraEditors;
using Automation.Plugins.MDJ.WCS.View.Dialogs;
using Automation.Plugins.MDJ.WCS.Dal;
using System.Data;
using System.Linq;
using Automation.MainPlugin.View;
using Automation.Plugins.MDJ.WCS.View.Controls;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel.Composition;
using System.Threading;

namespace Automation.MainPlugin.Action
{
    public class ScanManagerAction : AbstractAction
    {
        private const string rootKey = "kScan";

        private const string memoryServiceName1 = "MemoryTemporarilySingleDataService";
        private const string memoryItemName1 = "Handheld barcode scanning mode";

        private const string memoryServiceName2 = "MemoryTemporarilyDataService";
        private const string memoryItemName2 = "Handheld barcode scanning data";

        private const string plcServiceName = "THOKPLC";
        private const string I_Whole_Pallet_StockIn_Scan_Request = "I_Whole_Pallet_StockIn_Scan_Request";
        private const string O_Stockin_Scan_Alarm = "O_Stockin_Scan_Alarm";

        private DropDownActionItem dropItem = null;

        public override void Initialize()
        {
            DefaultSortOrder = 1;
        }

        public override void Activate()
        {
            IHeaderControl header = App.HeaderControl;
            header.Add(new SimpleActionItem(rootKey, "刷新", btnRefresh_Click) { SortOrder = 100, GroupCaption = "件烟扫码", SmallImage = Resources.refresh_16x16, LargeImage = Resources.refresh_32x32 });
            header.Add(new SimpleActionItem(rootKey, "停止刷新", btnStopRefresh_Click) { SortOrder = 100, GroupCaption = "件烟扫码", SmallImage = Resources.refresh_stop_16x16, LargeImage = Resources.refresh_stop_32x32 }); 
            header.Add(new SimpleActionItem(rootKey, "读取", btnRead_Click) { SortOrder = 100, GroupCaption = "件烟扫码", SmallImage = Resources.read_16x16, LargeImage = Resources.read_32x32 });
            header.Add(new SimpleActionItem(rootKey, "新增", btnNew_Click) { SortOrder = 100, GroupCaption = "件烟扫码", SmallImage = Resources.add_16x16, LargeImage = Resources.add_32x32 });
            header.Add(new SimpleActionItem(rootKey, "扫码", btnScan_Click) { SortOrder = 100, GroupCaption = "件烟扫码", SmallImage = Resources.scan_16x16, LargeImage = Resources.scan_32x32 });
            header.Add(new SimpleActionItem(rootKey, "停止", btnPause_Click) { SortOrder = 100, GroupCaption = "件烟扫码", SmallImage = Resources.pause_black_16x16, LargeImage = Resources.pause_black_32x32 });
            header.Add(new SimpleActionItem(rootKey, "完成", btnComplete_Click) { SortOrder = 100, GroupCaption = "件烟扫码", SmallImage = Resources.finish_16x16, LargeImage = Resources.finish_32x32 });
            header.Add(new SimpleActionItem(rootKey, "全部停止", btnStop_Click) { SortOrder = 100, GroupCaption = "件烟扫码", SmallImage = Resources.scan_stop_16x16, LargeImage = Resources.scan_stop_32x32 });
            header.Add(new SimpleActionItem(rootKey, "故障复位", btnReset_Click) { SortOrder = 100,GroupCaption = "件烟扫码", SmallImage = Resources.error_reset_16x16, LargeImage = Resources.error_reset_32x32 });
            
            header.Add(new SimpleActionItem(rootKey, "更新尺寸", btnUploadSize_Click) { SortOrder = 100, GroupCaption = "操作", SmallImage = Resources.update_size_16x16, LargeImage = Resources.update_size_32x32 });
            header.Add(new SimpleActionItem(rootKey, "更新条码", btnUploadBarcode_Click) { SortOrder = 100, GroupCaption = "操作", SmallImage = Resources.scan_update_16x16, LargeImage = Resources.scan_update_32x32 });
            header.Add(new SimpleActionItem(rootKey, "手工扫码", btnHandScan_Click) { SortOrder = 100, GroupCaption = "操作", SmallImage = Resources.scan_hand_16x16, LargeImage = Resources.scan_hand_32x32 });

            dropItem = new DropDownActionItem { RootKey = rootKey, GroupCaption = "手持扫码模式", Width = 170, Items = { "件烟扫码故障复位", "RFID整托盘入库", "手持扫码整托盘入库", "手持扫码盘点返库", "手持扫码出库余烟返库" } };
            dropItem.SelectedValueChanged += new EventHandler<SelectedValueChangedEventArgs>(dropItem_SelectedValueChanged);
            header.Add(dropItem);
            dropItem.DisplayText = "请选择手持扫码模式";
            dropItem.SelectedItem = "件烟扫码故障复位";
        }
       
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var view = AutomationContext.GetView<ScanManagerView>();
            if (view != null)
            {
                view.Refresh();
                view.Focus = true;
            }
        }

        private void btnStopRefresh_Click(object sender, EventArgs e)
        {
            var view = AutomationContext.GetView<ScanManagerView>();
            if (view != null)
            {
                view.Focus = false;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                var view = AutomationContext.GetView<ScanManagerView>();
                if (view != null)
                {
                    view.Read();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("新增扫码任务失败，详情原因 ： {0}", ex.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                var view = AutomationContext.GetView<ScanManagerView>();
                if (view != null)
                {
                    view.New();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("新增扫码任务失败，详情原因 ： {0}", ex.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                var view = AutomationContext.GetView<ScanManagerView>();
                if (view != null)
                {
                    view.Scan();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("开始扫码失败，详情原因 ： {0}", ex.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                var view = AutomationContext.GetView<ScanManagerView>();
                if (view != null)
                {
                    view.Pause();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("暂停扫码失败，详情原因 ： {0}", ex.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                var view = AutomationContext.GetView<ScanManagerView>();
                if (view != null)
                {
                    view.Complete();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("暂停扫码失败，详情原因 ： {0}", ex.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                var view = AutomationContext.GetView<ScanManagerView>();
                if (view != null)
                {
                    view.Stop();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("停止扫码失败，详情原因 ： {0}", ex.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            AutomationContext.Write(plcServiceName, O_Stockin_Scan_Alarm, 0);
        }

        private void btnUploadSize_Click(object sender, EventArgs e)
        {
            try
            {
                var view = AutomationContext.GetView<ScanManagerView>();
                if (view != null)
                {
                    view.UploadSize();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("更新尺寸信息失败，详情原因 ： {0}", ex.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUploadBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                var view = AutomationContext.GetView<ScanManagerView>();
                if (view != null)
                {
                    string text = "手工更新卷烟条码信息！";
                    string productCode = "";
                    string barcode = "";
                    view.UpdateBarcode(text, productCode, barcode);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("更新条码失败，详情原因 ： {0}", ex.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHandScan_Click(object sender, EventArgs e)
        {
            try
            {
                object state = AutomationContext.Read(memoryServiceName1, memoryItemName1);
                if (state == null || state.ToString() != "WholePalletScan")
                {
                    XtraMessageBox.Show("当手持扫码模式不是 [手持扫码整托盘入库]！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                state = AutomationContext.Read(plcServiceName, I_Whole_Pallet_StockIn_Scan_Request);
                state = ObjectUtil.GetObject(state);
                if (state == null || !Convert.ToBoolean(state))
                {
                    XtraMessageBox.Show("当前PLC未请求扫码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ScanDialog scanDialog = new ScanDialog();
                scanDialog.Text = "整盘入库手工扫码！";
                if (scanDialog.ShowDialog() == DialogResult.OK)
                {
                    int[] data = new int[] { scanDialog.ProductNo, scanDialog.Quantity };
                    AutomationContext.Write(memoryServiceName2, memoryItemName2, data);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("手工扫码失败，详情原因 ： {0}", ex.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void dropItem_SelectedValueChanged(object sender, SelectedValueChangedEventArgs e)
        {
            string data = string.Empty;
            switch (e.SelectedItem.ToString())
            {
                case "件烟扫码故障复位":
                    data = "ScanCodeFaultReset";
                    break;
                case "RFID整托盘入库":
                    data = "WholePalletScanRFID";
                    break;
                case "手持扫码整托盘入库":
                    data = "WholePalletScan";
                    break;
                case "手持扫码盘点返库":
                    data = "InventoryWholePalletScan";
                    break;
                case "手持扫码出库余烟返库":
                    data = "StockOutWholePalletScan";
                    break;
                default:
                    break;
            }
            if (!AutomationContext.Write(memoryServiceName1, memoryItemName1, data))
            {
                dropItem.SelectedItem = "";
                e.SelectedItem = "";
                XtraMessageBox.Show(string.Format("设置失败，详情请查看日志！"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        [Export("BeforeStopping", typeof(Func<bool>))]
        public bool BeforeStopping()
        {
            AutomationContext.Write(plcServiceName, O_Stockin_Scan_Alarm, 1);
            return true;
        }
    }
}
