using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.YZ.Sorting.View;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Sorting.Properties;

namespace Automation.Plugins.YZ.Sorting.Action
{
    public class PackDataAction : AbstractAction
    {
        private const string rootKey = "kPackDataQuery";

        public override void Initialize()
        {
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "包装数据") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", PackDataRefresh_Click) { ToolTipText = "包装机数据查询", LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "生成", GeneratePackData_Click) { ToolTipText = "手动生成包装机数据",  LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "导出", PackDataExport_Click) { ToolTipText = "导出包装机数据", LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { ToolTipText = "打印烟道信息",LargeImage = Resources.Print_32 });
            base.Activate();
        }

        private void PackDataRefresh_Click(object sender, EventArgs e)
        {
            (View as PackDataView).Refresh();
        }

        private void GeneratePackData_Click(object sender, EventArgs e)
        {
            (View as PackDataView).GeneratePackData();
        }

        private void PackDataExport_Click(object sender, EventArgs e)
        {
            (View as PackDataView).ExportData();
        }

        public void Print_Click(object sender, EventArgs e)
        {
            (View as PackDataView).Print();
        }
    }
}
