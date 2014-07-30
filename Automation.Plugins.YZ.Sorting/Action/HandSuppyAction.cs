using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Sorting.Properties;
using Automation.Plugins.YZ.Sorting.View;
using DevExpress.XtraEditors;
using Automation.Plugins.YZ.Sorting.Dal;

namespace Automation.Plugins.YZ.Sorting.Action
{
    public class HandSuppyAction : AbstractAction
    {
        private const string rootKey = "kHandSuppyQuery";

        DropDownActionItem dropItem = null;
        ChannelDal channelDal = new ChannelDal();
        HandSupplyDal handSupplyDal = new HandSupplyDal();

        public override void Initialize()
        {
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "手工补货") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", HandSuppyRefresh_Click) { ToolTipText = "手工补货查询", GroupCaption = "手工补货", LargeImage = Resources.refresh_32x32 });

            dropItem = new DropDownActionItem { RootKey = rootKey, GroupCaption = "烟道名称", Width = 100 };
            dropItem.Items.AddRange(channelDal.GetChannel());
            dropItem.SelectedValueChanged += new EventHandler<SelectedValueChangedEventArgs>(dropItem_SelectedValueChanged);
            this.Add(dropItem);
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { ToolTipText = "打印烟道信息", GroupCaption = "打印", LargeImage = Resources.Print_32 });
            base.Activate();
        }

        private void HandSuppyRefresh_Click(object sender, EventArgs e)
        {
            (View as HandSuppyView).Refresh(null);
        }

        private void dropItem_SelectedValueChanged(object sender, SelectedValueChangedEventArgs e)
        {
            (View as HandSuppyView).Refresh(e.SelectedItem.ToString());
        }

        public void Print_Click(object sender, EventArgs e)
        {
            (View as HandSuppyView).Print();
        }
    }
}
