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

        private DataDownLoad download = new DataDownLoad();
        public override void Initialize()
        {

            DefaultSortOrder = 1;
            RootKey = rootKey;
    
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
            header.Add(new SimpleActionItem(rootKey, "下单记录", SortingRecordQuery_Click) { ToolTipText = "下单记录查询", GroupCaption = "查询", SortOrder = 5, LargeImage = Resources.CacheOrderQuery_32 });
            header.Add(new SimpleActionItem(rootKey, "手工补货", HandSuppyQuery_Click) { ToolTipText = "手工补货查询", GroupCaption = "查询", SortOrder = 6, LargeImage = Resources.CacheOrderQuery_32 });
            header.Add(new SimpleActionItem(rootKey, "包装机数据", PackDataQuery_Click) { ToolTipText = "包装机数据查询", GroupCaption = "查询", SortOrder = 7, LargeImage = Resources.CacheOrderQuery_32 });
            header.Add(new SimpleActionItem(rootKey, "分拣进度", SortingProgressQuery_Click) { ToolTipText = "分拣进度查询", GroupCaption = "查询", SortOrder = 8, LargeImage = Resources.CacheOrderQuery_32 });
            header.Add(new SimpleActionItem(rootKey, "分拣效率", SortingEfficiencyQuery_Click) { ToolTipText = "分拣效率查询", GroupCaption = "查询", SortOrder = 9, LargeImage = Resources.CacheOrderQuery_32 });
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
        { }

        private void HandSuppyQuery_Click(object sender, EventArgs e)
        { }

        private void PackDataQuery_Click(object sender, EventArgs e)
        { }

        private void SortingProgressQuery_Click(object sender, EventArgs e)
        { }

        private void SortingEfficiencyQuery_Click(object sender, EventArgs e)
        { }
    }
}
