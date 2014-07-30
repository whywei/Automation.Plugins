using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Sorting.Properties;
using Automation.Plugins.YZ.Sorting.View;

using DevExpress.XtraEditors;

namespace Automation.Plugins.YZ.Sorting.Action
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
            this.Add(new SimpleActionItem(rootKey, "刷新", SortingRecordRefresh_Click) { ToolTipText = "下单记录查询", GroupCaption = "下单记录", LargeImage = Resources.refresh_32x32 });

            packno.Width = 120;
            packno.GroupCaption = "包号查询";
            packno.RootKey = rootKey;
            header.Add(packno);


            this.Add(new SimpleActionItem(rootKey, "查询", SortingPackNoRefresh_Click) { ToolTipText = "包号查询", GroupCaption = "包号查询", LargeImage = Resources.Sorting_Query_32 });


            base.Activate();
        }

        private void SortingRecordRefresh_Click(object sender, EventArgs e)
        {
            (View as SortingRecordView).Refresh();
        }

        private void SortingPackNoRefresh_Click(object sender, EventArgs e)
        {
         
            (View as SortingRecordView).PackNofresh(PackNo);

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
