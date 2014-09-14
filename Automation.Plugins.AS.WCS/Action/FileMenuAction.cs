using System;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.AS.WCS.Properties;

namespace Automation.Plugins.AS.WCS.Action
{
    public class FileMenuAction : AbstractAction
    {
        private const string FileMenuKey = HeaderControl.ApplicationMenuKey;

        public override void Initialize()
        {
            DefaultSortOrder = 1;
        }

        public override void Activate()
        {
            IHeaderControl header = App.HeaderControl;
            header.Add(new SimpleActionItem(FileMenuKey, "Warehouse Management Information System", WMS_Click) { SortOrder = 100, GroupCaption = FileMenuKey, SmallImage = Resources.warehouse_16x16, LargeImage = Resources.warehouse_32x32 });
        }

        private const string Url = "www.skyseaok.com";
        private void WMS_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Url);
        }
    }
}
