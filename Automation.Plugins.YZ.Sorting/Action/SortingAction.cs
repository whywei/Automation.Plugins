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
            header.Add(new SimpleActionItem(rootKey, "订单查询", OrderQuery_Click) { ToolTipText = "分拣订单查询", GroupCaption = "作业查询", LargeImage = Resources.Sorting_Query_32 });
            header.Add(new SimpleActionItem(rootKey, "客户查询", CustomerQuery_Click) { ToolTipText = "客户订单查询", GroupCaption = "作业查询", LargeImage = Resources.Customer_Query_32 });
            header.Add(new SimpleActionItem(rootKey, "缓存订单", CacheOrderQuery_Click) { ToolTipText = "缓存订单查询", GroupCaption = "作业查询", LargeImage = Resources.CacheOrderQuery_32 });
            header.Add(new SimpleActionItem(rootKey, "烟道盘点", SortChannelCheck_Click) { ToolTipText = "分拣烟道盘点", GroupCaption = "作业查询", LargeImage = Resources.SortChannelCheck_32 });
            header.Add(new SimpleActionItem(rootKey, "效率查询", btn_click) { ToolTipText = "分拣效率查询", GroupCaption = "作业查询", LargeImage = Resources.Customer_Query_32 });
            header.Add(new SimpleActionItem(rootKey, "补货作业", HandleStock_Click) { ToolTipText = "补货任务作业", SortOrder = 1, GroupCaption = "操作", LargeImage = Resources.HandleStock_32 });
            header.Add(new SimpleActionItem(rootKey, "参数设置", btn_click) { ToolTipText = "参数设置", SortOrder = 1, GroupCaption = "操作", LargeImage = Resources.Customer_Query_32 });


            btnDown[0] = new SimpleActionItem(rootKey, "数据下载", DataDownLoad_click) { GroupCaption = "分拣操作", SmallImage = Resources.Customer_Query_32, LargeImage = Resources.Customer_Query_32 };
            header.Add(btnDown[0]);
            btnStart[1] = new SimpleActionItem(rootKey, "开始分拣", StartSort_Click) { GroupCaption = "分拣操作", SmallImage = Resources.Customer_Query_32, LargeImage = Resources.Customer_Query_32 };
            header.Add(btnStart[1]);
            btnStop[2] = new SimpleActionItem(rootKey, "停止分拣", StopSort_click) { GroupCaption = "分拣操作", SmallImage = Resources.Customer_Query_32, LargeImage = Resources.Customer_Query_32 };
            header.Add(btnStop[2]);

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
