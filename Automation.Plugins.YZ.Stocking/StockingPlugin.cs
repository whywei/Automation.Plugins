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

namespace Automation.Plugins.YZ.Stocking
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
            header.Add(new SimpleActionItem("kStocking", "补货状态", StockStatus_Click) { ToolTipText = "补货状态", GroupCaption = "查询", SortOrder = 1, LargeImage = Resources.Task_32 });
            header.Add(new SimpleActionItem("kStocking", "拆盘位置", StockPosition_Click) { ToolTipText = "拆盘位置", GroupCaption = "查询", SortOrder = 2, LargeImage = Resources.yandao_32x32 });
        }

        private void UpdateBarcode_Click(object sender, EventArgs e)
        {
        }

        private void StartStock_Click(object sender, EventArgs e)
        {
            SwitchStatus(true);
        }

        private void StopStock_click(object sender, EventArgs e)
        {
            SwitchStatus(false);
        }

        private void SwitchStatus(bool isStart)
        {
            btnUpdateBarcode.Enabled = !isStart;
            btnStart.Enabled = !isStart;
            btnStop.Enabled = isStart;
            AutomationContext.Write(Global.memoryServiceName_TemporarilySingleData, Global.memoryItemName_SortingState, isStart);
        }

        private void StockStatus_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<StockStatusView>();
        }

        private void StockPosition_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<StockPositionView>();
        }
    }
}
