using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Core;
using Automation.Plugins.Share.ManualSupply.View;
using DotSpatial.Controls.Header;
using Automation.Plugins.Share.ManualSupply.Properties;

namespace Automation.Plugins.Share.ManualSupply.Action
{
    public class CurrentTaskAction : AbstractAction
    {
        private const string rootKey = "kCurrentTask";

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "当前任务") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", CurrentTask_Click) { ToolTipText = "刷新当前任务信息", LargeImage = Resource.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { ToolTipText = "打印当前任务信息", LargeImage = Resource.Print_32 });
            base.Activate();
        }

        private void CurrentTask_Click(object sender, EventArgs e)
        {
            (View as CurrentTaskView).Refresh();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            (View as CurrentTaskView).Print();
        }
    }
}
