﻿using System;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.Share.Sorting.View;
using Automation.Plugins.Share.Sorting.Properties;
using Automation.Plugins.Share.Sorting.Dal;
using Automation.Plugins.Share.Sorting.Bll;

namespace Automation.Plugins.Share.Sorting.Action
{
    public class ChannelAction : AbstractAction
    {
        private const string rootKey = "kChannelQuery";
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
            this.Add(new SimpleActionItem(rootKey, "刷新", ChannelQueryRefresh_Click) { ToolTipText = "刷新烟道信息", LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "交换烟道", ChannelExchange_Click) { ToolTipText = "烟道交换", LargeImage = Resources.SortChannelSwap_32 });
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { ToolTipText = "打印烟道信息", LargeImage = Resources.Print_32 });
            base.Activate();
        }

        private void ChannelQueryRefresh_Click(object sender, EventArgs e)
        {
            (View as ChannelQueryView).Refresh();
        }

        public void ChannelExchange_Click(object sender, EventArgs e)
        {
            object obj = Ops.Read(Global.MemoryTemporarilySingleDataService, Global.MemoryItemNameSortState);
            bool isSort = obj == null ? false : Convert.ToBoolean(obj);
            if (isSort == false)
            {
                (View as ChannelQueryView).gridChannelQuery_DoubleClick(sender, e);
            }
        }

        public void Print_Click(object sender, EventArgs e)
        {
            (View as ChannelQueryView).Print();
        }
    }
}
