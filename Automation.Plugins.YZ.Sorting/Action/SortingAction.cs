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


namespace Automation.Plugins.YZ.Sorting.Action
{
    public class SortingAction : AbstractAction
    {
        private const string rootKey = "yzSorting";

        private bool channelViewIsOpen = false;
        private ChannelQueryView ChannelQueryView = new ChannelQueryView();
        private bool customerQueryIsOpen = false;
        private bool cacheorderQueryIsOpen = false;
        private bool packnoQueryIsOpen = false;
      
        ActionItem[] actionItem = new ActionItem[4];

        private DataDownLoad download = new DataDownLoad();
        public override void Initialize()
        {

            DefaultSortOrder = 1;
    
        }

        public override void Activate()
        {
            IHeaderControl header = App.HeaderControl;

            header.Add(new SimpleActionItem(rootKey, "数据下载", DataDownLoad_click) { ToolTipText = "数据下载", GroupCaption = "操作", SortOrder = 1, LargeImage = Resources.Customer_Query_32 });
            header.Add(new SimpleActionItem(rootKey, "开始分拣", StartSort_Click) { ToolTipText = "开始分拣", GroupCaption = "操作", SortOrder = 2, LargeImage = Resources.HandleStock_32 });
            header.Add(new SimpleActionItem(rootKey, "停止分拣", StopSort_click) { ToolTipText = "停止分拣", GroupCaption = "操作", SortOrder = 3, LargeImage = Resources.Customer_Query_32 });

            header.Add(new SimpleActionItem(rootKey, "烟道查询", ChannelQuery_Click) { ToolTipText = "分拣烟道盘点", GroupCaption = "查询", SortOrder = 1, LargeImage = Resources.SortChannelCheck_32 });
            header.Add(new SimpleActionItem(rootKey, "烟包查询", PackNoQuery_Click) { ToolTipText = "分拣订单查询", GroupCaption = "查询", SortOrder = 2, LargeImage = Resources.Sorting_Query_32 });
            header.Add(new SimpleActionItem(rootKey, "客户查询", CustomerQuery_Click) { ToolTipText = "客户订单查询", GroupCaption = "查询", SortOrder = 3, LargeImage = Resources.Customer_Query_32 });
            header.Add(new SimpleActionItem(rootKey, "缓存订单", CacheOrderQuery_Click) { ToolTipText = "缓存订单查询", GroupCaption = "查询", SortOrder = 4, LargeImage = Resources.CacheOrderQuery_32 });

            actionItem[0] = new SimpleActionItem(rootKey, "刷新", ChannelRefresh_Click) { ToolTipText = "刷新烟道", GroupCaption = "烟道查询", LargeImage = Resources.refresh_32x32 };
            actionItem[1] = new SimpleActionItem(rootKey, "刷新", PackNoRefresh_Click) { ToolTipText = "刷新分烟包", GroupCaption = "烟包查询", LargeImage = Resources.refresh_32x32 };
            actionItem[2] = new SimpleActionItem(rootKey, "刷新", CustomerRefresh_Click) { ToolTipText = "刷新客户", GroupCaption = "客户查询", LargeImage = Resources.refresh_32x32 };
            actionItem[3] = new SimpleActionItem(rootKey, "刷新", CacheOrderRefresh_Click) { ToolTipText = "刷新缓存", GroupCaption = "缓存订单", LargeImage = Resources.refresh_32x32 };


            App.DockManager.PanelClosed += new EventHandler<DockablePanelEventArgs>(DockManager_PanelClosed);
            App.DockManager.ActivePanelChanged += new EventHandler<DockablePanelEventArgs>(DockManager_ActivePanelChanged);
      
        
        }

        private void DockManager_PanelClosed(object sender, DockablePanelEventArgs e)
        {
            switch (e.ActivePanelKey)
            {
                case "kChannelQuery":
                    channelViewIsOpen = false;                 
                    App.HeaderControl.Remove(actionItem[0].Key);
                    App.DockManager.Remove("kChannelQuery");
                    return;
                case "kPackNoQuery":
                    packnoQueryIsOpen = false;               
                    App.HeaderControl.Remove(actionItem[1].Key);
                    App.DockManager.Remove("kPackNoQuery");
                    return;
                case "kCustomerQuery":
                    customerQueryIsOpen = false;             
                    App.HeaderControl.Remove(actionItem[2].Key);
                    App.DockManager.Remove("kCustomerQuery");
                    return;
                case "kCacheOrderQuery":
                    cacheorderQueryIsOpen = false;
                    App.HeaderControl.Remove(actionItem[3].Key);
                    App.DockManager.Remove(AutomationContext.GetView<CacheOrderQueryView>().Key);
                    return;
            }
        }

        private void DockManager_ActivePanelChanged(object sender, DockablePanelEventArgs e)
        {
            if (e.ActivePanelKey == "kChannelQuery")
            {
                try
                {
                    App.HeaderControl.Add((SimpleActionItem)actionItem[0]);
                }
                catch { }
                App.HeaderControl.SelectRoot("yzSorting");
            }else{
                App.HeaderControl.Remove(actionItem[0].Key);
            }

            if (e.ActivePanelKey == "kPackNoQuery")
            {
                try
                {
                    App.HeaderControl.Add((SimpleActionItem)actionItem[1]);
                }
                catch
                { }
                App.HeaderControl.SelectRoot("yzSorting");
            }else{
                App.HeaderControl.Remove(actionItem[1].Key);
            }

            if (e.ActivePanelKey == "kCustomerQuery")
            {
                try
                {
                    App.HeaderControl.Add((SimpleActionItem)actionItem[2]);
                }
                catch { }
                App.HeaderControl.SelectRoot("yzSorting");
            }
            else
            {
                App.HeaderControl.Remove(actionItem[2].Key);
            }
            if (e.ActivePanelKey == "kCacheOrderQuery")
            {
                try
                {
                    App.HeaderControl.Add((SimpleActionItem)actionItem[3]);
                }
                catch
                { }
                App.HeaderControl.SelectRoot("yzSorting");
            }
            else
            {
                App.HeaderControl.Remove(actionItem[3].Key);
            }

        }
       


        private void DataDownLoad_click(object sender, EventArgs e)
        {
            download.Data();
        }
        private void StartSort_Click(object sender, EventArgs e)
        {
            //AutomationContext.ActivateView<CustomerQueryView>();
        }
        private void StopSort_click(object sender, EventArgs e)
        {
            //AutomationContext.ActivateView<CustomerQueryView>();
        }


        private void AddDockablePanel(IView view)
        {
            view.Initialize();
            view.Activate();
            App.DockManager.Add(new DockablePanel(view.Key, view.Caption, view.InnerControl, view.Dock) { SmallImage = view.SmallImage, DefaultSortOrder = view.DefaultSortOrder });
        }
        private void ChannelQuery_Click(object sender, EventArgs e)
        {
            if (!channelViewIsOpen)
            {
                AddDockablePanel(ChannelQueryView);
                channelViewIsOpen = true;
            }
            App.DockManager.SelectPanel("kChannelQuery");
        }
        private void PackNoQuery_Click(object sender, EventArgs e)
        {
            if (!packnoQueryIsOpen)
            {
                AddDockablePanel(AutomationContext.GetView<PackNoView>());
                packnoQueryIsOpen = true;
            }
            App.DockManager.SelectPanel("kPackNoQuery");
        }
        private void CustomerQuery_Click(object sender, EventArgs e)
        {
            if (!customerQueryIsOpen)
            {
                AddDockablePanel(AutomationContext.GetView<CustomerQueryView>());
                customerQueryIsOpen = true;
            }
            App.DockManager.SelectPanel("kCustomerQuery");
        }
        private void CacheOrderQuery_Click(object sender, EventArgs e)
        {
            if (!cacheorderQueryIsOpen)
            {
                AddDockablePanel(AutomationContext.GetView<CacheOrderQueryView>());
                cacheorderQueryIsOpen = true;
            }
            App.DockManager.SelectPanel("kCacheOrderQuery");
        }


        #region  刷新功能
        private void ChannelRefresh_Click(object sender, EventArgs e)
        {
            ChannelQueryView.Refresh();
        }
        private void PackNoRefresh_Click(object sender, EventArgs e)
        {
            AutomationContext.GetView<PackNoView>().Refresh();
        }
        private void CustomerRefresh_Click(object sender, EventArgs e)
        {
            AutomationContext.GetView<CustomerQueryView>().Refresh();
        }
        private void CacheOrderRefresh_Click(object sender, EventArgs e)
        {
            AutomationContext.GetView<CacheOrderQueryView>().Refresh();
        }
        #endregion
    }
}
