using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Sorting.View;
using Automation.Plugins.YZ.Sorting.Properties;

namespace Automation.Plugins.YZ.Sorting.Action
{
    public class CacheOrderAction : AbstractAction
    {
        private const string rootKey = "kCacheOrderQuery";

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "缓存订单") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "A-前", A_FrontCacheRefresh_Click) { ToolTipText = "A线小皮带缓存订单查询", GroupCaption = "缓存订单查询", LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "A-后", A_LaterCacheRefresh_Click) { ToolTipText = "A线多沟带缓存订单查询", GroupCaption = "缓存订单查询", LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "B-前", B_FrontCacheRefresh_Click) { ToolTipText = "B线小皮带缓存订单查询", GroupCaption = "缓存订单查询", LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "B-后", B_LaterCacheRefresh_Click) { ToolTipText = "A线多沟带缓存订单查询", GroupCaption = "缓存订单查询", LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "打码订单", BarcodePrintingCacheRefresh_Click) { ToolTipText = "打码订单查询", GroupCaption = "打码订单查询", LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "摆动订单", SwingCacheRefresh_Click) { ToolTipText = "摆动订单查询", GroupCaption = "摆动订单查询", LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { ToolTipText = "打印烟道信息", GroupCaption = "打印", LargeImage = Resources.Print_32 });
            base.Activate();
        }

        private void A_FrontCacheRefresh_Click(object sender, EventArgs e)
        {
            (View as CacheOrderQueryView).Refresh("A","F");
        }

        private void A_LaterCacheRefresh_Click(object sender, EventArgs e)
        {
            (View as CacheOrderQueryView).Refresh("A","L");
        }

        private void B_FrontCacheRefresh_Click(object sender, EventArgs e)
        {
            (View as CacheOrderQueryView).Refresh("B", "F");
        }

        private void B_LaterCacheRefresh_Click(object sender, EventArgs e)
        {
            (View as CacheOrderQueryView).Refresh("B", "L");
        }

        private void BarcodePrintingCacheRefresh_Click(object sender, EventArgs e)
        {
            (View as CacheOrderQueryView).Refresh("P");
        }

        private void SwingCacheRefresh_Click(object sender, EventArgs e)
        {
            (View as CacheOrderQueryView).Refresh("S");
        }

        public void Print_Click(object sender, EventArgs e)
        {
            (View as CacheOrderQueryView).Print();
        }
    }
}