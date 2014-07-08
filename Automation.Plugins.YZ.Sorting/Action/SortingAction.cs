using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Sorting.Properties;
using Automation.Plugins.YZ.Sorting.View;
using Automation.Plugins.YZ.Sorting.Action;


namespace Automation.Plugins.YZ.Sorting.Action
{
    public class SortingAction : AbstractAction
    {
        private const string rootKey = "yzSorting";

        private SimpleActionItem[] btnDown = new SimpleActionItem[4];
        private SimpleActionItem[] btnStart = new SimpleActionItem[4];
        private SimpleActionItem[] btnStop = new SimpleActionItem[4];

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

            header.Add(new SimpleActionItem(rootKey, "烟道查询", SortChannelCheck_Click) { ToolTipText = "分拣烟道盘点", GroupCaption = "查询", SortOrder = 1, LargeImage = Resources.SortChannelCheck_32 });
            header.Add(new SimpleActionItem(rootKey, "烟包查询", OrderQuery_Click) { ToolTipText = "分拣订单查询", GroupCaption = "查询", SortOrder = 2, LargeImage = Resources.Sorting_Query_32 });
            header.Add(new SimpleActionItem(rootKey, "客户查询", CustomerQuery_Click) { ToolTipText = "客户订单查询", GroupCaption = "查询", SortOrder = 3, LargeImage = Resources.Customer_Query_32 });
            header.Add(new SimpleActionItem(rootKey, "缓存订单", CacheOrderQuery_Click) { ToolTipText = "缓存订单查询", GroupCaption = "查询", SortOrder = 4, LargeImage = Resources.CacheOrderQuery_32 });            
        }

        private void CustomerQuery_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<CustomerQueryView>();
        }

        private void OrderQuery_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<OrderQueryView>();
        }

        private void SortChannelCheck_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<SortChannelCheckView>();
        }

        private void CacheOrderQuery_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<CacheOrderQueryView>();
        }

        private void HandleStock_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<HandleStockView>();
        }

        private void btn_click(object sender, EventArgs e)
        {

        }
        private void DataDownLoad_click(object sender, EventArgs e)
        {
            download.Data();           
        }
        private void StartSort_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<CustomerQueryView>();
        }
        private void StopSort_click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<CustomerQueryView>();
        }
    }
}
