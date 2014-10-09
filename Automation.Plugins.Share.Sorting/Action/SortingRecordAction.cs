using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.Share.Sorting.Properties;
using Automation.Plugins.Share.Sorting.View;

using DevExpress.XtraEditors;

namespace Automation.Plugins.Share.Sorting.Action
{
    public class SortingRecordAction : AbstractAction
    {
        private const string rootKey = "kSortingRecordQuery";

        private TextEntryActionItem packno = new TextEntryActionItem();


        public override void Initialize()
        {
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            IHeaderControl header = App.HeaderControl;
            this.Add(new RootItem(rootKey, "下单记录") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", SortingRecordRefresh_Click) { ToolTipText = "下单记录查询", LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { ToolTipText = "打印烟道信息", LargeImage = Resources.Print_32 });

            base.Activate();
        }

        private void SortingRecordRefresh_Click(object sender, EventArgs e)
        {
            (View as SortingRecordView).Refresh();
        }

        public void Print_Click(object sender, EventArgs e)
        {
            (View as SortingRecordView).Print();
        }

         public int PackNo
        {
            get
            {
                int i = 0;
                if (!int.TryParse(packno.Text, out i))
                {
                    packno.Text = "";
                    DevExpress.XtraEditors.XtraMessageBox.Show("请输入数字!");
                }
                return i;
            }
        }

    }
}
