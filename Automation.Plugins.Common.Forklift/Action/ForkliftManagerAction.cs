using Automation.Core;
using DotSpatial.Controls.Header;
using System.ComponentModel.Composition;
using Automation.Plugins.Common.Forklift.View;
using Automation.Plugins.Common.Forklift.Properties;
using DevExpress.XtraEditors;

namespace Automation.Plugins.Common.Forklift.Action
{
    public class ForkliftManagerAction : AbstractAction
    {
        [Import]
        public ForkliftManager ForkliftManager { get; set; }

        private const string rootKey = "kForklift";

        private SimpleActionItem btnAuto = null;
        private SimpleActionItem btnHand = null;

        private SimpleActionItem btnGetRequest = null;
        private SimpleActionItem btnGetFinish = null;

        private SimpleActionItem btnPutRequest = null;
        private SimpleActionItem btnPutFinish = null;

        private SimpleActionItem btnCannel = null;

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
        }

        public override void Activate()
        {
            btnAuto = this.Add(new SimpleActionItem(rootKey, "自动", (sender, e) => { if (ForkliftManager.ActiveForklift != null) ForkliftManager.ActiveForklift.Auto = true; }) 
                { SmallImage = Resources.run_right_16x16, LargeImage = Resources.run_right_32x32 });
            btnHand = this.Add(new SimpleActionItem(rootKey, "手动", (sender, e) => { if (ForkliftManager.ActiveForklift != null) ForkliftManager.ActiveForklift.Auto = false; }) 
                { SmallImage = Resources.hand_16x16, LargeImage = Resources.hand_32x32 });
            btnGetRequest = this.Add(new SimpleActionItem(rootKey, "申请取货", (sender, e) => { if (ForkliftManager.ActiveForklift != null) ForkliftManager.ActiveForklift.GetRequest = true; }) 
                { SmallImage = Resources.apply_16x16, LargeImage = Resources.apply_32x32 });
            btnGetFinish = this.Add(new SimpleActionItem(rootKey, "完成取货", (sender, e) => { if (ForkliftManager.ActiveForklift != null) ForkliftManager.ActiveForklift.GetFinish = true; }) 
                { SmallImage = Resources.ok_16x16, LargeImage = Resources.ok_32x32 });
            btnPutRequest = this.Add(new SimpleActionItem(rootKey, "申请放货", (sender, e) => { if (ForkliftManager.ActiveForklift != null) ForkliftManager.ActiveForklift.PutRequest = true; }) 
                { SmallImage = Resources.apply_16x16, LargeImage = Resources.apply_32x32 });
            btnPutFinish = this.Add(new SimpleActionItem(rootKey, "完成放货", (sender, e) => {
                if (ForkliftManager.ActiveForklift != null)
                {
                    ForkliftManager.ActiveForklift.PutFinish = true;
                    ForkliftManager.ActiveForklift.TaskFinish = true;
                }
                }) 
                { SmallImage = Resources.ok_16x16, LargeImage = Resources.ok_32x32 });
            btnCannel = this.Add(new SimpleActionItem(rootKey, "取消任务", (sender, e) => {
                    string msg = string.Empty;
                    if (ForkliftManager.ActiveForklift != null)
                    {
                        ForkliftManager.ActiveForklift.Cancel(out msg);
                        XtraMessageBox.Show(msg);
                    }
                }) 
                { SmallImage = Resources.cannel_16x16, LargeImage = Resources.cannel_32x32 });

            ForkliftManager.SelectForklift(Properties.Settings.Default.ForkliftName);
            Ops.GetView<ForkliftManagerView>().Forklift = ForkliftManager.ActiveForklift;
        }

        public override void RefreshAction()
        {
            ForkliftManager.SelectForklift(Properties.Settings.Default.ForkliftName);
            if (ForkliftManager.ActiveForklift != null)
            {
                btnAuto.Enabled = !ForkliftManager.ActiveForklift.Auto;
                btnHand.Enabled = ForkliftManager.ActiveForklift.Auto;
                if (ForkliftManager.ActiveForklift.CurrentTask != null)
                {
                    btnGetRequest.Enabled = !ForkliftManager.ActiveForklift.CurrentTask.GetFinish && !ForkliftManager.ActiveForklift.GetRequest;
                    btnGetFinish.Enabled = ForkliftManager.ActiveForklift.GetPermit && !ForkliftManager.ActiveForklift.GetFinish;
                    btnPutRequest.Enabled = ForkliftManager.ActiveForklift.CurrentTask.GetFinish && !ForkliftManager.ActiveForklift.CurrentTask.PutFinish && !ForkliftManager.ActiveForklift.PutRequest;
                    btnPutFinish.Enabled = ForkliftManager.ActiveForklift.PutPermit && !ForkliftManager.ActiveForklift.PutFinish;
                }
                else
                {
                    btnGetRequest.Enabled = false;
                    btnGetFinish.Enabled = false;
                    btnPutRequest.Enabled = false;
                    btnPutFinish.Enabled = false;
                    btnCannel.Enabled = false;
                }
            }
            else
            {
                btnAuto.Enabled = false;
                btnHand.Enabled = false;
                btnGetRequest.Enabled = false;
                btnGetFinish.Enabled = false;
                btnPutRequest.Enabled = false;
                btnPutFinish.Enabled = false;
                btnCannel.Enabled = false;
            }
            Ops.GetView<ForkliftManagerView>().Forklift = ForkliftManager.ActiveForklift;
        }
    }
}
