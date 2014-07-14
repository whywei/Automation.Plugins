using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.Sorting.Properties;
using Automation.Plugins.Sorting.View;
using DotSpatial.Controls.Docking;

namespace Automation.Plugins.Sorting.Action
{
    public class SortingAction:AbstractAction
    {
        private const string rootKey = "kSorting";

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
        }

        public override void Activate()
        {
            IHeaderControl header = App.HeaderControl;
            header.Add(new SimpleActionItem(rootKey, "订单查询", OrderQuery_Click) { ToolTipText = "分拣订单查询", GroupCaption = "作业查询", LargeImage = Resources.Sorting_Query_32 });
            header.Add(new SimpleActionItem(rootKey, "客户查询", CustomerQuery_Click) { ToolTipText = "客户订单查询", GroupCaption = "作业查询", LargeImage = Resources.customer_32x32 });
            header.Add(new SimpleActionItem(rootKey, "缓存订单", CacheOrderQuery_Click) { ToolTipText = "缓存订单查询", GroupCaption = "作业查询", LargeImage = Resources.CacheOrderQuery_32 });
            header.Add(new SimpleActionItem(rootKey, "烟道盘点", SortChannelCheck_Click) { ToolTipText = "分拣烟道盘点", GroupCaption = "作业查询", LargeImage = Resources.yandao_32x32 });
            header.Add(new SimpleActionItem(rootKey, "效率查询", btn_click) { ToolTipText = "分拣效率查询", GroupCaption = "作业查询", LargeImage = Resources.Efficiency_32x32 });
            header.Add(new SimpleActionItem(rootKey, "补货作业", HandleStock_Click) { ToolTipText = "补货任务作业", SortOrder = 1, GroupCaption = "操作", LargeImage = Resources.Replenishment_32x32 });
            header.Add(new SimpleActionItem(rootKey, "参数设置", btn_click) { ToolTipText = "参数设置", SortOrder = 1, GroupCaption = "操作", LargeImage = Resources.set_address_32x32 });
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
    }
}
