using System;
using Automation.Core;
using DotSpatial.Controls.Header;
using System.ComponentModel.Composition;
using DevExpress.XtraEditors;
using System.Linq;
using Automation.Plugins.Common.SRM.Properties;
using Automation.Plugins.Common.SRM.View;

namespace Automation.Plugins.Common.SRM.Action
{
    public class ServiceManagerAction : AbstractAction
    {
        [Import]
        public SRMManager SRMManager { get; set; }

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
            try
            {
                btnAuto = this.Add(new SimpleActionItem(rootKey, "全自动", btnAuto_Click) { SmallImage = Resources.auto_full_16x16, LargeImage = Resources.auto_full_32x32 });
                btnHand = this.Add(new SimpleActionItem(rootKey, "半自动", btnHand_Click) { SmallImage = Resources.auto_semi_16x16, LargeImage = Resources.auto_semi_32x32 });
                this.Add(new SimpleActionItem(rootKey, "故障复位", btReset_Click) { SmallImage = Resources.error_reset_16x16, LargeImage = Resources.error_reset_32x32 });
                this.Add(new SimpleActionItem(rootKey, "重发任务", btResent_Click) { SmallImage = Resources.reset_16x16, LargeImage = Resources.reset_32x32 });
                this.Add(new SimpleActionItem(rootKey, "取消任务", btCancel_Click) { SmallImage = Resources.cancel_16x16, LargeImage = Resources.cancel_32x32 });

                dropItem = new DropDownActionItem() { RootKey = rootKey, GroupCaption = "选择堆垛机", Width = 170 };
                foreach (var srm in SRMManager.SRMs)
                {
                    dropItem.Items.Add(srm.Name);
                }

                this.Add(dropItem);
                dropItem.SelectedValueChanged += new EventHandler<SelectedValueChangedEventArgs>(dropItem_SelectedValueChanged);
                dropItem.DisplayText = "请选择堆垛机";
                SRMManager.ActiveSRM = SRMManager.SRMs.FirstOrDefault();
                if (SRMManager.ActiveSRM != null)
                {
                    dropItem.SelectedItem = SRMManager.ActiveSRM.Name;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void dropItem_SelectedValueChanged(object sender, SelectedValueChangedEventArgs e)
        {
            SRMManager.SelectSRM(e.SelectedItem.ToString());
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (SRMManager.ActiveSRM != null)
            {
                SRMManager.ActiveSRM.SetAuto(true);
            }     
        }

        private void btnHand_Click(object sender, EventArgs e)
        {
            if (SRMManager.ActiveSRM != null)
            {
                SRMManager.ActiveSRM.SetAuto(false);
            }     
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            if (SRMManager.ActiveSRM != null)
            {
                SRMManager.ActiveSRM.Reset();
            }     
        }

        private void btResent_Click(object sender, EventArgs e)
        {
            if (SRMManager.ActiveSRM != null)
            {
                string msg = string.Empty;
                SRMManager.ActiveSRM.Resend(out msg);
                XtraMessageBox.Show(msg);
            }     
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (SRMManager.ActiveSRM != null)
            {
                string msg = string.Empty;
                SRMManager.ActiveSRM.Cancel(out msg);
                XtraMessageBox.Show(msg);
            }     
        }

        public override void RefreshAction()
        {
            if (SRMManager.ActiveSRM != null)
            {
                btnAuto.Enabled = !SRMManager.ActiveSRM.Auto;
                btnHand.Enabled = SRMManager.ActiveSRM.Auto;
            }
        }

        [Export("BeforeStopping", typeof(Func<bool>))]
        public bool BeforeStopping()
        {
            try
            {
                SRMManager.SRMs.AsParallel().ForAll(s => s.SetAuto(false));
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.StackTrace);
                return false;
            }
        }
    }
}
