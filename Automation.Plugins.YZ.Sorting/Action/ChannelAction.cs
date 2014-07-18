using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Sorting.View;
using Automation.Plugins.YZ.Sorting.Properties;
using Automation.Plugins.YZ.Sorting.Dal;

namespace Automation.Plugins.YZ.Sorting.Action
{
    public class ChannelAction : AbstractAction
    {
        private const string rootKey = "kChannelQuery";

        DropDownActionItem dropItem1 = null;
        DropDownActionItem dropItem2 = null;
        ChannelDal channelDal = new ChannelDal();

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "烟道查询") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", ChannelQueryRefresh_Click) { ToolTipText = "刷新烟道查询", GroupCaption = "烟道查询", LargeImage = Resources.refresh_32x32 });

            dropItem1 = new DropDownActionItem { RootKey = rootKey, GroupCaption = "交换烟道", Width = 100 };
            dropItem1.Items.AddRange(channelDal.GetChannel());
            dropItem1.SelectedValueChanged += new EventHandler<SelectedValueChangedEventArgs>(dropItem1_SelectedValueChanged);
            this.Add(dropItem1);

            dropItem2 = new DropDownActionItem { RootKey = rootKey, GroupCaption = "交换烟道", Width = 100 };

            //System.Windows.Forms.MessageBox.Show("1:" + dropItem1.SelectedItem.ToString());
            //System.Windows.Forms.MessageBox.Show("2:" + dropItem1.Items.ToArray());
            //foreach (var item in dropItem1.Items)
            //{
                
            //}
            //dropItem2.Items.AddRange(channelDal.GetChannel(dropItem1.SelectedItem.ToString()));
            this.Add(dropItem2);

            this.Add(new SimpleActionItem(rootKey, "交换", ChannelExchange_Click) { ToolTipText = "烟道互换", GroupCaption = "交换烟道", LargeImage = Resources.SortChannelSwap_32 });
            
            base.Activate();
        }

        private void ChannelQueryRefresh_Click(object sender, EventArgs e)
        {
            (View as ChannelQueryView).Refresh();
        }

        private void dropItem1_SelectedValueChanged(object sender, SelectedValueChangedEventArgs e)
        {
            dropItem2.Items.AddRange(channelDal.GetChannel(e.SelectedItem.ToString()));
        }

        private void ChannelExchange_Click(object sender, EventArgs e)
        {
            
        }
    }
}