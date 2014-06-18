using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Sorting.Properties;
using Automation.Plugins.YZ.Sorting.View;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Automation.Plugins.YZ.Sorting.Action
{
    public class LedQueryAction : AbstractAction
    {

        private const string rootKey = "yzledQuery";

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "LED查询") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", SRM_Click) { ToolTipText = "LED查询", GroupCaption = "LED查询", LargeImage = Resources.refresh_32x32 });
            base.Activate();         
        }
        private void SRM_Click(object sender, EventArgs e)
        {
            (View as LedQueryView).Refresh();
        }
    }
}
