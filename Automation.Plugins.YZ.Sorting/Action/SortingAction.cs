using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Sorting.Properties;
using Automation.Plugins.YZ.Sorting.View;
using Automation.Plugins.YZ.Sorting.Action;
using DotSpatial.Controls.Docking;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace Automation.Plugins.YZ.Sorting.Action
{
    public class SortingAction : AbstractAction
    {
        private const string rootKey = "yzSorting";
        private SimpleActionItem btnDown = null;
        private SimpleActionItem btnStart = null;
        private SimpleActionItem btnStop = null;

        private DataDownLoad download = new DataDownLoad();
        public override void Initialize()
        {

            DefaultSortOrder = 1;
            RootKey = rootKey;
            ((Form)Shell).FormClosing += new FormClosingEventHandler(HomeMenuAction_FormClosing);
        }

        private void HomeMenuAction_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!btnStart.Enabled)
            {
                e.Cancel = true;
                XtraMessageBox.Show("先停止分拣才能退出系统！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void Activate()
        {
            IHeaderControl header = App.HeaderControl;

            btnDown = new SimpleActionItem(rootKey, "数据下载", DataDownLoad_click) { ToolTipText = "数据下载", GroupCaption = "操作", SortOrder = 1, LargeImage = Resources.download_32x32 };
            header.Add(btnDown);
            btnStart = new SimpleActionItem(rootKey, "开始分拣", StartSort_Click) { ToolTipText = "开始分拣", GroupCaption = "操作", SortOrder = 2, LargeImage = Resources.start_32x32 };
            header.Add(btnStart);
            btnStop = new SimpleActionItem(rootKey, "停止分拣", StopSort_click) { Enabled = false, ToolTipText = "停止分拣", GroupCaption = "操作", SortOrder = 3, LargeImage = Resources.spouse_32x32 };
            header.Add(btnStop);

            header.Add(new SimpleActionItem(rootKey, "烟道盘点", ChannelQuery_Click) { ToolTipText = "分拣烟道盘点", GroupCaption = "查询", SortOrder = 1, LargeImage = Resources.yandao_32x32 });
            header.Add(new SimpleActionItem(rootKey, "烟包查询", PackNoQuery_Click) { ToolTipText = "分拣订单查询", GroupCaption = "查询", SortOrder = 2, LargeImage = Resources.package_32x32 });
            header.Add(new SimpleActionItem(rootKey, "订单查询", CustomerQuery_Click) { ToolTipText = "客户订单查询", GroupCaption = "查询", SortOrder = 3, LargeImage = Resources.customer_32x32 });
            header.Add(new SimpleActionItem(rootKey, "缓存查询", CacheOrderQuery_Click) { ToolTipText = "缓存订单查询", GroupCaption = "查询", SortOrder = 4, LargeImage = Resources.CacheOrderQuery_32 });
            header.Add(new SimpleActionItem(rootKey, "下单记录", SortingRecordQuery_Click) { ToolTipText = "下单记录查询", GroupCaption = "查询", SortOrder = 5, LargeImage = Resources.Sorting_Query_32 });
            header.Add(new SimpleActionItem(rootKey, "手工补货", HandSuppyQuery_Click) { ToolTipText = "手工补货查询", GroupCaption = "查询", SortOrder = 6, LargeImage = Resources.handwork_32x32 });
            header.Add(new SimpleActionItem(rootKey, "包装机数据", PackDataQuery_Click) { ToolTipText = "包装机数据查询", GroupCaption = "查询", SortOrder = 7, LargeImage = Resources.package_data_32x32 });
            header.Add(new SimpleActionItem(rootKey, "分拣进度", SortingProgressQuery_Click) { ToolTipText = "分拣进度查询", GroupCaption = "查询", SortOrder = 8, LargeImage = Resources.bar_32x32 });
            header.Add(new SimpleActionItem(rootKey, "分拣效率", SortingEfficiencyQuery_Click) { ToolTipText = "分拣效率查询", GroupCaption = "查询", SortOrder = 9, LargeImage = Resources.Efficiency_32x32 });
        }

        private void DataDownLoad_click(object sender, EventArgs e)
        {
            download.Data();
        }
        private void StartSort_Click(object sender, EventArgs e)
        {
            SwitchStatus(true);
        }
        private void StopSort_click(object sender, EventArgs e)
        {
            SwitchStatus(false);
        }

        private void SwitchStatus(bool isStart)
        {
            btnDown.Enabled = !isStart;
            btnStart.Enabled = !isStart;
            btnStop.Enabled = isStart;
            AutomationContext.Write(Global.memoryServiceName_TemporarilySingleData, Global.memoryItemName_SortingState, isStart);
        }

        private void AddDockablePanel(IView view)
        {
            view.Initialize();
            view.Activate();
            App.DockManager.Add(new DockablePanel(view.Key, view.Caption, view.InnerControl, view.Dock) { SmallImage = view.SmallImage, DefaultSortOrder = view.DefaultSortOrder });
        }
        private void ChannelQuery_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<ChannelQueryView>();
        }
        private void PackNoQuery_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<PackNoView>();
        }
        private void CustomerQuery_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<CustomerQueryView>();
        }
        private void CacheOrderQuery_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<CacheOrderQueryView>();
        }

        private void SortingRecordQuery_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<SortingRecordView>();
        }

        private void HandSuppyQuery_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<HandSuppyView>();
        }

        private void PackDataQuery_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<PackDataView>();
        }

        private void SortingProgressQuery_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<SortingProgressView>();
        }

        private void SortingEfficiencyQuery_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<SortingEfficiencyView>();
        }
    }
}
