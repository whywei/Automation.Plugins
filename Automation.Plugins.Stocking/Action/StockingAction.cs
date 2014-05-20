using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.Stocking.Properties;
using Automation.Plugins.Stocking.Dal;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Automation.Plugins.Stocking.View.Controls;
using DotSpatial.Controls.Docking;
using Automation.Plugins.Stocking.View;

namespace Automation.Plugins.Stocking.Action
{
    
    public class StockingAction:AbstractAction
    {
        private const string rootKey = "kStocking";
        private bool stateManagerViewIsOpen = false;
        private StockChannelQueryView stockChannelQueryView = new StockChannelQueryView();
        private bool stockChannelQueryIsOpen = false;
        private bool sortChannelQueryIsOpen = false;
        private bool orderQueryViewIsOpen = false;
        ActionItem [] actionItem = new ActionItem[10];
        

        public override void Initialize()
        {
            DefaultSortOrder = 1;
        }

        public override void Activate()
        {
            IHeaderControl header = App.HeaderControl;
            header.Add(new SimpleActionItem(rootKey, "补货烟道", StockChannelQuery_Click) { ToolTipText = "仓库补货烟道查询", GroupCaption = "作业查询", LargeImage = Resources.SconQuery_32 });
            header.Add(new SimpleActionItem(rootKey, "分拣烟道", SortChannelQuery_Click) { ToolTipText = "分拣烟道查询", GroupCaption = "作业查询", LargeImage = Resources.SconQuery_32 });
            header.Add(new SimpleActionItem(rootKey, "扫码状态", ScanQuery_Click) { ToolTipText = "扫码状态查询", GroupCaption = "状态查询", LargeImage = Resources.SconQuery_32 });
            header.Add(new SimpleActionItem(rootKey, "订单状态", OrderQuery_Click) { ToolTipText = "订单状态查询", GroupCaption = "状态查询", LargeImage = Resources.SconQuery_32 });
            actionItem[0]= new SimpleActionItem(rootKey, "刷新", StockChannelRefresh_Click) { ToolTipText = "刷新补货烟道",GroupCaption="补货烟道操作", LargeImage = Resources.refresh_32x32 };
            actionItem[1] = new SimpleActionItem(rootKey, "刷新", SortChannelRefresh_Click) { ToolTipText = "刷新分拣烟道", GroupCaption = "分拣烟道操作", LargeImage = Resources.refresh_32x32 };
            actionItem[2] = new SimpleActionItem(rootKey, "交换烟道", SortChannelSwap_Click) { GroupCaption = "交换分拣烟道", LargeImage = Resources.SortChannelSwap_32 };
            actionItem[3] = new DropDownActionItem() { RootKey = rootKey, Caption = "选择扫码器：", Width = 200, NullValuePrompt = "请选择", GroupCaption = "订单操作" };
            actionItem[4] = new SimpleActionItem(rootKey, "刷新", OrderStateRefresh_Click) { ToolTipText = "刷新订单状态", GroupCaption = "订单操作", LargeImage = Resources.refresh_32x32 };
            actionItem[5] = new DropDownActionItem() { RootKey = rootKey, Caption = "选择扫码器：", Width = 170, NullValuePrompt = "请选择", GroupCaption = "扫码操作" };
            actionItem[6] = new SimpleActionItem(rootKey, "刷新", ScanRefresh_Click) { ToolTipText = "刷新扫码状态", LargeImage = Resources.refresh_32x32, GroupCaption = "扫码操作" };
            
            App.DockManager.PanelClosed += new EventHandler<DockablePanelEventArgs>(DockManager_PanelClosed);
            App.DockManager.ActivePanelChanged += new EventHandler<DockablePanelEventArgs>(DockManager_ActivePanelChanged);
        }

        private void DockManager_PanelClosed(object sender,DockablePanelEventArgs e)
        {
            switch (e.ActivePanelKey)
            {
                case "kStockChannelQuery":
                    stockChannelQueryIsOpen = false;
                    App.DockManager.Remove("kStockChannelQuery");
                    App.HeaderControl.Remove(actionItem[0].Key);
                    return;
                case "kScanQuery":
                    stateManagerViewIsOpen=false;
                    App.HeaderControl.Remove(actionItem[5].Key);
                    App.HeaderControl.Remove(actionItem[6].Key);
                    App.DockManager.Remove("kScanQuery");
                    return;
                case "kSortChannelQuery":
                    sortChannelQueryIsOpen = false;
                    App.HeaderControl.Remove(actionItem[1].Key);
                    App.HeaderControl.Remove(actionItem[2].Key);
                    App.DockManager.Remove("kSortChannelQuery");
                    return;
                case "kOrderStateQuery":
                    orderQueryViewIsOpen = false;
                    App.HeaderControl.Remove(actionItem[3].Key);
                    App.HeaderControl.Remove(actionItem[4].Key);
                    App.DockManager.Remove(AutomationContext.GetView<OrderStateQueryView>().Key);
                    return;
            }
        }

        private void DockManager_ActivePanelChanged(object sender, DockablePanelEventArgs e)
        {
            if (e.ActivePanelKey == "kStockChannelQuery")
            {
                try
                {
                    App.HeaderControl.Add((SimpleActionItem)actionItem[0]);
                }
                catch { }
                App.HeaderControl.SelectRoot("kStocking");
            }
            else
            {
                App.HeaderControl.Remove(actionItem[0].Key);
            }
            if (e.ActivePanelKey == "kSortChannelQuery")
            {
                try
                {
                    App.HeaderControl.Add((SimpleActionItem)actionItem[1]);
                    App.HeaderControl.Add((SimpleActionItem)actionItem[2]);
                }
                catch
                { }
                App.HeaderControl.SelectRoot("kStocking");
            }
            else
            {
                App.HeaderControl.Remove(actionItem[1].Key);
                App.HeaderControl.Remove(actionItem[2].Key);
            }
            if (e.ActivePanelKey == AutomationContext.GetView<OrderStateQueryView>().Key)
            {
                try
                {
                    ((DropDownActionItem)actionItem[3]).Items.Clear();
                    ((DropDownActionItem)actionItem[3]).Items.AddRange(AutomationContext.GetView<OrderStateQueryView>().FindOrderStateList());
                    App.HeaderControl.Add((DropDownActionItem)actionItem[3]);
                    App.HeaderControl.Add((SimpleActionItem)actionItem[4]);
                }
                catch
                { }
                App.HeaderControl.SelectRoot("kStocking");
            }
            else
            {
                App.HeaderControl.Remove(actionItem[3].Key);
                App.HeaderControl.Remove(actionItem[4].Key);
            }
            if (e.ActivePanelKey == AutomationContext.GetView<ScanQueryView>().Key)
            {
                try
                {
                    ((DropDownActionItem)actionItem[5]).Items.Clear();
                    ((DropDownActionItem)actionItem[5]).Items.AddRange(AutomationContext.GetView<ScanQueryView>().FindScannerListTable());
                    App.HeaderControl.Add((DropDownActionItem)actionItem[5]);
                    App.HeaderControl.Add((SimpleActionItem)actionItem[6]);
                }
                catch { }
                App.HeaderControl.SelectRoot("kStocking");
            }
            else
            {
                App.HeaderControl.Remove(actionItem[5].Key);
                App.HeaderControl.Remove(actionItem[6].Key);
            }
        }

        private void AddDockablePanel(IView view)
        {
            view.Initialize();
            view.Activate();
            App.DockManager.Add(new DockablePanel(view.Key, view.Caption, view.InnerControl, view.Dock) { SmallImage = view.SmallImage, DefaultSortOrder = view.DefaultSortOrder });
        }

        private void ScanQuery_Click(object sender, EventArgs e)
        {
            if (!stateManagerViewIsOpen)
            {
                AddDockablePanel(AutomationContext.GetView<ScanQueryView>());
                stateManagerViewIsOpen = true;
            }
            App.DockManager.SelectPanel(AutomationContext.GetView<ScanQueryView>().Key);
        }

        private void StockChannelQuery_Click(object sender, EventArgs e)
        {
            if (!stockChannelQueryIsOpen)
            {
                AddDockablePanel(stockChannelQueryView);
                stockChannelQueryIsOpen = true;
            }
            App.DockManager.SelectPanel("kStockChannelQuery");
        }

        private void SortChannelQuery_Click(object sender, EventArgs e)
        {
            if (!sortChannelQueryIsOpen)
            {
                AddDockablePanel(AutomationContext.GetView<SortChannelQueryView>());
                sortChannelQueryIsOpen = true;
            }
            App.DockManager.SelectPanel("kSortChannelQuery");
        }

        private void OrderQuery_Click(object sender, EventArgs e)
        {
            if (!orderQueryViewIsOpen)
            {
                AddDockablePanel(AutomationContext.GetView<OrderStateQueryView>());
                orderQueryViewIsOpen = true;
            }
            App.DockManager.SelectPanel(AutomationContext.GetView<OrderStateQueryView>().Key);
        }

        private void StockChannelRefresh_Click(object sender, EventArgs e)
        {
            stockChannelQueryView.Refresh();
        }

        private void SortChannelRefresh_Click(object sender, EventArgs e)
        {
            AutomationContext.GetView<SortChannelQueryView>().Refresh();
        }

        private void OrderStateRefresh_Click(object sender, EventArgs e)
        {
            string index = ((DropDownActionItem)actionItem[3]).SelectedItem == null ? "" : ((DropDownActionItem)actionItem[3]).SelectedItem.ToString().Split('-')[0];
            if (index == "")
                return;
            AutomationContext.GetView<OrderStateQueryView>().Refresh(index);
        }

        private void SortChannelSwap_Click(object sender, EventArgs e)
        {
            AutomationContext.GetView<SortChannelQueryView>().SortChannelSwap();
        }

        private void ScanRefresh_Click(object sender, EventArgs e)
        {
            string index = ((DropDownActionItem)actionItem[5]).SelectedItem == null ? "" : ((DropDownActionItem)actionItem[5]).SelectedItem.ToString().Split('-')[0];
            if (index == "")
                return;
            AutomationContext.GetView<ScanQueryView>().Refresh(index);
        }
    }
}
