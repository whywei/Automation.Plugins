using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Sorting.Properties;
using Automation.Plugins.YZ.Sorting.View;


namespace Automation.Plugins.YZ.Sorting.Action
{
    public class SortingAction : AbstractAction
    {
        private const string rootKey = "yzSorting";

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
        }

        public override void Activate()
        {
            IHeaderControl header = App.HeaderControl;
            header.Add(new SimpleActionItem(rootKey, "订单查询1", OrderQuery_Click) { ToolTipText = "分拣订单查询", GroupCaption = "作业查询", LargeImage = Resources.Sorting_Query_32 });
            header.Add(new SimpleActionItem(rootKey, "LED", LedQuery_Click) { ToolTipText = "led查询", GroupCaption = "查询", LargeImage = Resources.Customer_Query_32 });
            header.Add(new SimpleActionItem(rootKey, "客户查询1", CustomerQuery_Click) { ToolTipText = "客户订单查询", GroupCaption = "作业查询", LargeImage = Resources.Customer_Query_32 });
            header.Add(new SimpleActionItem(rootKey, "缓存订单1", CacheOrderQuery_Click) { ToolTipText = "缓存订单查询", GroupCaption = "作业查询", LargeImage = Resources.CacheOrderQuery_32 });
            header.Add(new SimpleActionItem(rootKey, "烟道盘点1", SortChannelCheck_Click) { ToolTipText = "分拣烟道盘点", GroupCaption = "作业查询", LargeImage = Resources.SortChannelCheck_32 });
            header.Add(new SimpleActionItem(rootKey, "效率查询1", btn_click) { ToolTipText = "分拣效率查询", GroupCaption = "作业查询", LargeImage = Resources.Customer_Query_32 });
            header.Add(new SimpleActionItem(rootKey, "补货作业1", HandleStock_Click) { ToolTipText = "补货任务作业", SortOrder = 1, GroupCaption = "操作", LargeImage = Resources.HandleStock_32 });
            header.Add(new SimpleActionItem(rootKey, "参数设置1", btn_click) { ToolTipText = "参数设置", SortOrder = 1, GroupCaption = "操作", LargeImage = Resources.Customer_Query_32 });
        }

        private void CustomerQuery_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<CustomerQueryView>();
        }


        private void LedQuery_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<LedQueryView>();
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
    }
}
