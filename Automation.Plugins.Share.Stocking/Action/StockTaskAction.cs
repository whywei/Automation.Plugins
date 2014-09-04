using System;
using System.Collections.Generic;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.Share.Stocking.Properties;
using Automation.Plugins.Share.Stocking.View;
using System.Linq;

namespace Automation.Plugins.Share.Stocking.Action
{
    public class StockTaskAction:AbstractAction
    {
        private const string rootKey = "kStockTask";
        private int activeLedNo = 0;
        private Dictionary<int, string> ledSqls = new Dictionary<int, string>();

        public override void Initialize()
        {
            RootKey = rootKey;
            IsPreload = false;
            LoadLedConfig();
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "补货任务") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", Refresh_Click) { SortOrder=1, LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { SortOrder = 2, LargeImage = Resources.Print_32 });
            
            var dropDownActionItem = new DropDownActionItem() { RootKey = rootKey, GroupCaption = "请选择LED屏", Width = 70 };
            dropDownActionItem.SelectedValueChanged += new EventHandler<SelectedValueChangedEventArgs>(dropDownActionItem_SelectedValueChanged);
            ledSqls.Keys.AsParallel().ForAll(k => dropDownActionItem.Items.Add(k));
            this.Add(dropDownActionItem);
            base.Activate();
        }

        private void dropDownActionItem_SelectedValueChanged(object sender, SelectedValueChangedEventArgs e)
        {
            this.activeLedNo = Convert.ToInt32(e.SelectedItem);
            if (ledSqls.ContainsKey(activeLedNo))
            {
                (View as StockTaskView).Refresh(activeLedNo, ledSqls[activeLedNo]);
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            if (ledSqls.ContainsKey(activeLedNo))
            {
                (View as StockTaskView).Refresh(activeLedNo, ledSqls[activeLedNo]);
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            (View as StockTaskView).Print();
        }

        private void LoadLedConfig()
        {
            ledSqls = Settings.Default.LedSqls.AsEnumerable().ToDictionary(l => Convert.ToInt32(l.Split(':')[0]), l => l.Split(':')[1]);
        }
    }
}
