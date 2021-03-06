﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Core;
using Automation.Plugins.Share.ManualSupply.Properties;
using Automation.Plugins.Share.ManualSupply.View;
using DevExpress.XtraEditors;
using DotSpatial.Controls.Header;

namespace Automation.Plugins.Share.ManualSupply.Action
{
    public class AllTaskAction : AbstractAction
    {
        private const string rootKey = "kAllTask";
        private TextEntryActionItem txtBatchNo = new TextEntryActionItem();

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "全部作业") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", AllTaskRefresh_Click) { ToolTipText = "刷新烟道信息", LargeImage = Resource.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "上页", BackPage_Click) { ToolTipText = "刷新烟道信息", LargeImage = Resource.Back });
            this.Add(new SimpleActionItem(rootKey, "下页", NextPage_Click) { ToolTipText = "刷新烟道信息", LargeImage = Resource.Next });
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { ToolTipText = "打印烟道信息", LargeImage = Resource.Print_32 });
            
            txtBatchNo.GroupCaption = "查询";
            txtBatchNo.RootKey = rootKey;
            txtBatchNo.Caption = "批次：";
            txtBatchNo.Width = 80;
            this.Add(txtBatchNo);
            this.Add(new SimpleActionItem(rootKey, "查询", Search_Click) { GroupCaption = "查询", ToolTipText = "批次查询", LargeImage = Resource.Sorting_Query_32 });
            base.Activate();
        }

        private void AllTaskRefresh_Click(object sender, EventArgs e)
        {
            (View as AllTaskView).Refresh();
        }

        private void BackPage_Click(object sender, EventArgs e)
        {
            (View as AllTaskView).BackPage();
        }

        private void NextPage_Click(object sender, EventArgs e)
        {
            (View as AllTaskView).NextPage();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            (View as AllTaskView).Print();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            int batchNo;
            try
            {
                batchNo = int.Parse(txtBatchNo.Text != null ? txtBatchNo.Text : "1");
            }
            catch (Exception)
            {
                batchNo = 1;
            }
            try
            {
                (View as AllTaskView).Search(batchNo);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("数据库连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
