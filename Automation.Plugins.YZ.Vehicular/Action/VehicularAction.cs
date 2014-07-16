﻿using System;
using Automation.Core;
using DotSpatial.Controls.Header;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Threading;
using Automation.Plugins.YZ.Vehicular.Properties;

namespace Automation.Plugins.YZ.Vehicular.Action
{
    public class VehicularAction : AbstractAction
    {
        private const string rootKey = "kVehicular";

        private SimpleActionItem btnAuto = null;
        private SimpleActionItem btnHand = null;
        private DropDownActionItem dropItem = null;

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
        }

        public override void Activate()
        {
            IHeaderControl header = App.HeaderControl;
            header.Add(new SimpleActionItem(rootKey, "自动", (sender, e) => { }) { SmallImage = Resources.run_right_16x16, LargeImage = Resources.run_right_32x32 });
            header.Add(new SimpleActionItem(rootKey, "手动", (sender, e) => { }) { SmallImage = Resources.hand_16x16, LargeImage = Resources.hand_32x32 });
            header.Add(new SimpleActionItem(rootKey, "申请", (sender, e) => { }) { SmallImage = Resources.apply_16x16, LargeImage = Resources.apply_32x32 });
            header.Add(new SimpleActionItem(rootKey, "取消", (sender, e) => { }) { SmallImage = Resources.cannel_16x16, LargeImage = Resources.cannel_32x32 });
            header.Add(new SimpleActionItem(rootKey, "完成", (sender, e) => { }) { SmallImage = Resources.ok_16x16, LargeImage = Resources.ok_32x32 });
            header.Add(new SimpleActionItem(rootKey, "批量", (sender, e) => { }) { SmallImage = Resources.batch_16x16, LargeImage = Resources.batch_32x32 });

            dropItem = new DropDownActionItem() { RootKey = rootKey, GroupCaption = "选择作业类型", Width = 170 , MultiSelect = true};


            this.Add(dropItem);
            dropItem.SelectedValueChanged += new EventHandler<SelectedValueChangedEventArgs>(dropItem_SelectedValueChanged);
            dropItem.DisplayText = "请选择作业类型";
        }

        private void dropItem_SelectedValueChanged(object sender, SelectedValueChangedEventArgs e)
        {

        }
    }
}
