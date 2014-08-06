using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.ManualSupply.Properties;
using Automation.Plugins.YZ.ManualSupply.View;

namespace Automation.Plugins.YZ.ManualSupply.Action
{
    public class AllTaskAction : AbstractAction
    {
        private const string rootKey = "kAllTask";

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "全部作业") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", AllTaskRefresh_Click) { ToolTipText = "刷新烟道信息", LargeImage = Resource.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "上页", BackPage_Click) { ToolTipText = "刷新烟道信息", LargeImage = Resource.Back });
            this.Add(new SimpleActionItem(rootKey, "下页", NextPage_Click) { ToolTipText = "刷新烟道信息", LargeImage = Resource.Next });
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { ToolTipText = "打印烟道信息", LargeImage = Resource.Print_32 });
            base.Activate();
        }

        private void AllTaskRefresh_Click(object sender, EventArgs e)
        {
            (View as AllTaskView).Refresh();
        }

        private void BackPage_Click(object sender, EventArgs e)
        {
            (View as AllTaskView).BackPage();
        }

        private void NextPage_Click(object sender, EventArgs e)
        {
            (View as AllTaskView).NextPage();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            (View as AllTaskView).Print();
        }
    }
}
