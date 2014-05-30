using System;
using Automation.Core;
using DotSpatial.Controls.Header;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using System.Threading;
using Automation.Plugins.YZ.WCS.Properties;
using System.Linq;

namespace Automation.MainPlugin.Action
{
    public class ServiceManagerAction : AbstractAction
    {
        private const string rootKey = "kSRM";

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
            btnAuto = this.Add(new SimpleActionItem(rootKey, "全自动", SRM_Click) { SmallImage = Resources.auto_full_16x16, LargeImage = Resources.auto_full_32x32 });
            btnHand = this.Add(new SimpleActionItem(rootKey, "半自动", SRM_Click) { SmallImage = Resources.auto_semi_16x16, LargeImage = Resources.auto_semi_32x32 });
            this.Add(new SimpleActionItem(rootKey, "故障复位", SRM_Click) { SmallImage = Resources.error_reset_16x16, LargeImage = Resources.error_reset_32x32 });
            this.Add(new SimpleActionItem(rootKey, "重发任务", SRM_Click) { SmallImage = Resources.reset_16x16, LargeImage = Resources.reset_32x32 });
            this.Add(new SimpleActionItem(rootKey, "取消任务", SRM_Click) { SmallImage = Resources.cancel_16x16, LargeImage = Resources.cancel_32x32 });

            dropItem = new DropDownActionItem() { RootKey = rootKey, GroupCaption = "选择堆垛机", Width = 170 };
            for (int i = 1; i < Settings.Default.SRMCount; i++)
            {
                dropItem.Items.Add(string.Format("{0}号堆垛机", i));
            }

            this.Add(dropItem);
            dropItem.SelectedValueChanged += new EventHandler<SelectedValueChangedEventArgs>(dropItem_SelectedValueChanged);

            dropItem.DisplayText = "请选择堆垛机";
            dropItem.SelectedItem = string.Format("{0}号堆垛机", 1);
        }

        private void dropItem_SelectedValueChanged(object sender, SelectedValueChangedEventArgs e)
        {

        }

        private void SRM_Click(object sender, EventArgs e)
        {

        }

        public override void RefreshAction()
        {

        }

        [Export("BeforeStopping", typeof(Func<bool>))]
        public bool BeforeStopping()
        {
            Shell.BeginInvoke((MethodInvoker)(() =>
                {
                    btnAuto.Enabled = true;
                    RefreshAction();
                }));
            return true;
        }
    }
}
