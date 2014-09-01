using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Stocking.Properties;
using Automation.Plugins.YZ.Stocking.View;

namespace Automation.Plugins.YZ.Stocking.Action
{
    public class StockStatusAction:AbstractAction
    {
        private const string rootKey = "kStockStatus";
        private DropDownActionItem dropDownActionItem = null;
        private Dictionary<string, string> ledSQL = new Dictionary<string, string>();
        public override void Initialize()
        {
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "补货状态") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", Refresh_Click) { ToolTipText = "将卷烟信息发送到PLC", SortOrder=2, LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { ToolTipText = "打印烟道信息", SortOrder = 3, LargeImage = Resources.Print_32 });
            base.Activate();
            dropDownActionItem = new DropDownActionItem() { RootKey = rootKey, Width = 180 };
            string[] led_sqls=Settings.Default.LED_SQL.Split(';');
            foreach(var item in led_sqls)
            {
                string[] strs = item.Split(':');
                if (strs.Length == 2)
                {
                    if (ledSQL.ContainsKey(strs[0]))
                    {
                        ledSQL[strs[0]] = strs[1];
                    }
                    else
                    {
                        ledSQL.Add(strs[0], strs[1]);
                    }
                    dropDownActionItem.Items.Add(strs[0]);
                }
            }
            this.Add(dropDownActionItem);
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            if (dropDownActionItem != null && dropDownActionItem.SelectedItem != null)
            {
                string key = dropDownActionItem.SelectedItem.ToString();
                if (ledSQL.ContainsKey(key))
                {
                    string[] ledNo = key.Split('-');
                    if (ledNo.Length > 0)
                    {
                        (View as StockStatusView).Refresh(ledNo[0], ledSQL[key]);
                    }
                }
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            (View as StockStatusView).Print();
        }
    }
}
