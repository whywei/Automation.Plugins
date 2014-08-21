using System;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.MDJ.WCS.Properties;
using Automation.Plugins.MDJ.WCS;
using Automation.Plugins.MDJ.WCS.Device;
using System.Collections;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Threading;

namespace Automation.MainPlugin.Action
{
    public class ServiceManagerAction : AbstractAction
    {
        private const string rootKey = "kSRM";
        private const string memoryServiceName = "MemoryPermanentSingleDataService";

        private SimpleActionItem[] _btnAuto = new SimpleActionItem[4];
        private SimpleActionItem[] _btnHand = new SimpleActionItem[4];
        private IDictionary<string, SRM> SRMS = new Dictionary<string, SRM>();

        public override void Initialize()
        {
            DefaultSortOrder = 2;
            RootKey = rootKey;
        }

        public override void Activate()
        {
            IHeaderControl header = App.HeaderControl;
            //header.Add(new SimpleActionItem(rootKey, "初始化", SRM_Click) { GroupCaption = "一号堆垛机", SmallImage = Resources.init_16x16, LargeImage = Resources.init_32x32 });
            _btnAuto[0] = new SimpleActionItem(rootKey, "全自动", SRM_Click) { GroupCaption = "一号堆垛机", SmallImage = Resources.auto_full_16x16, LargeImage = Resources.auto_full_32x32 };
            header.Add(_btnAuto[0]);
            _btnHand[0] = new SimpleActionItem(rootKey, "半自动", SRM_Click) { GroupCaption = "一号堆垛机", SmallImage = Resources.auto_semi_16x16, LargeImage = Resources.auto_semi_32x32 };
            header.Add(_btnHand[0]);
            header.Add(new SimpleActionItem(rootKey, "故障复位", SRM_Click) { GroupCaption = "一号堆垛机", SmallImage = Resources.error_reset_16x16, LargeImage = Resources.error_reset_32x32 });
            header.Add(new SimpleActionItem(rootKey, "重发任务", SRM_Click) { GroupCaption = "一号堆垛机", SmallImage = Resources.reset_16x16, LargeImage = Resources.reset_32x32 });
            header.Add(new SimpleActionItem(rootKey, "取消任务", SRM_Click) { GroupCaption = "一号堆垛机", SmallImage = Resources.cancel_16x16, LargeImage = Resources.cancel_32x32 });

            //header.Add(new SimpleActionItem(rootKey, "初始化", SRM_Click) { GroupCaption = "二号堆垛机", SmallImage = Resources.init_16x16, LargeImage = Resources.init_32x32 });
            _btnAuto[1] = new SimpleActionItem(rootKey, "全自动", SRM_Click) { GroupCaption = "二号堆垛机", SmallImage = Resources.auto_full_16x16, LargeImage = Resources.auto_full_32x32 };
            header.Add(_btnAuto[1]);
            _btnHand[1] = new SimpleActionItem(rootKey, "半自动", SRM_Click) { GroupCaption = "二号堆垛机", SmallImage = Resources.auto_semi_16x16, LargeImage = Resources.auto_semi_32x32 };
            header.Add(_btnHand[1]);
            header.Add(new SimpleActionItem(rootKey, "故障复位", SRM_Click) { GroupCaption = "二号堆垛机", SmallImage = Resources.error_reset_16x16, LargeImage = Resources.error_reset_32x32 });
            header.Add(new SimpleActionItem(rootKey, "重发任务", SRM_Click) { GroupCaption = "二号堆垛机", SmallImage = Resources.reset_16x16, LargeImage = Resources.reset_32x32 });
            header.Add(new SimpleActionItem(rootKey, "取消任务", SRM_Click) { GroupCaption = "二号堆垛机", SmallImage = Resources.cancel_16x16, LargeImage = Resources.cancel_32x32 });

            //header.Add(new SimpleActionItem(rootKey, "初始化", SRM_Click) { GroupCaption = "三号堆垛机", SmallImage = Resources.init_16x16, LargeImage = Resources.init_32x32 });
            _btnAuto[2] = new SimpleActionItem(rootKey, "全自动", SRM_Click) { GroupCaption = "三号堆垛机", SmallImage = Resources.auto_full_16x16, LargeImage = Resources.auto_full_32x32 };
            header.Add(_btnAuto[2]);
            _btnHand[2] = new SimpleActionItem(rootKey, "半自动", SRM_Click) { GroupCaption = "三号堆垛机", SmallImage = Resources.auto_semi_16x16, LargeImage = Resources.auto_semi_32x32 };
            header.Add(_btnHand[2]);
            header.Add(new SimpleActionItem(rootKey, "故障复位", SRM_Click) { GroupCaption = "三号堆垛机", SmallImage = Resources.error_reset_16x16, LargeImage = Resources.error_reset_32x32 });
            header.Add(new SimpleActionItem(rootKey, "重发任务", SRM_Click) { GroupCaption = "三号堆垛机", SmallImage = Resources.reset_16x16, LargeImage = Resources.reset_32x32 });
            header.Add(new SimpleActionItem(rootKey, "取消任务", SRM_Click) { GroupCaption = "三号堆垛机", SmallImage = Resources.cancel_16x16, LargeImage = Resources.cancel_32x32 });

            //header.Add(new SimpleActionItem(rootKey, "初始化", SRM_Click) { GroupCaption = "四号堆垛机", SmallImage = Resources.init_16x16, LargeImage = Resources.init_32x32 });
            _btnAuto[3] = new SimpleActionItem(rootKey, "全自动", SRM_Click) { GroupCaption = "四号堆垛机", SmallImage = Resources.auto_full_16x16, LargeImage = Resources.auto_full_32x32 };
            header.Add(_btnAuto[3]);
            _btnHand[3] = new SimpleActionItem(rootKey, "半自动", SRM_Click) { GroupCaption = "四号堆垛机", SmallImage = Resources.auto_semi_16x16, LargeImage = Resources.auto_semi_32x32 };
            header.Add(_btnHand[3]);
            header.Add(new SimpleActionItem(rootKey, "故障复位", SRM_Click) { GroupCaption = "四号堆垛机", SmallImage = Resources.error_reset_16x16, LargeImage = Resources.error_reset_32x32 });
            header.Add(new SimpleActionItem(rootKey, "重发任务", SRM_Click) { GroupCaption = "四号堆垛机", SmallImage = Resources.reset_16x16, LargeImage = Resources.reset_32x32 });
            header.Add(new SimpleActionItem(rootKey, "取消任务", SRM_Click) { GroupCaption = "四号堆垛机", SmallImage = Resources.cancel_16x16, LargeImage = Resources.cancel_32x32 });
        }

        public override void RefreshAction()
        {
            RefreshAction("SRM01", "一号堆垛机");
            RefreshAction("SRM02", "二号堆垛机");
            RefreshAction("SRM03", "三号堆垛机");
            RefreshAction("SRM04", "四号堆垛机");
        }

        private void SRM_Click(object sender, EventArgs e)
        {
            SimpleActionItem simpleAction = (SimpleActionItem)sender;
            string captionStr = simpleAction.Caption.ToString();
            string groupCaptionStr = simpleAction.GroupCaption.ToString();
            string srmName = groupCaptionStr == "一号堆垛机" ? "SRM01" : (groupCaptionStr == "二号堆垛机" ? "SRM02" : (groupCaptionStr == "三号堆垛机" ? "SRM03" : (groupCaptionStr == "四号堆垛机" ? "SRM04" : "")));
            if (!InitSRMS(srmName))
            {
                XtraMessageBox.Show("当前堆垛机未连接无法进行操作！", "提示", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            if (XtraMessageBox.Show(string.Format("确定要{0} [{1}]吗？",groupCaptionStr,captionStr), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                switch (captionStr)
                {
                    case "初始化":
                        SRMS[srmName].Initialize();
                        break;
                    case "全自动":
                        SRMS[srmName].SetAuto(true);
                        _btnAuto.Single(b => b.GroupCaption == groupCaptionStr).Enabled = false;
                        _btnHand.Single(b => b.GroupCaption == groupCaptionStr).Enabled = true;
                        break;
                    case "半自动":
                        SRMS[srmName].SetAuto(false);
                        _btnAuto.Single(b => b.GroupCaption == groupCaptionStr).Enabled = true;
                        _btnHand.Single(b => b.GroupCaption == groupCaptionStr).Enabled = false;
                        break;
                    case "故障复位":
                        SRMS[srmName].Reset();
                        break;
                    case "重发任务":
                        SRMS[srmName].ReSendTask();
                        break;
                    case "取消任务":
                        SRMS[srmName].CancelTask();
                        break;
                    default:
                        break;
                }
            }
        }

        private void RefreshAction(string srmName, string groupCaption)
        {
            try
            {
                if (InitSRMS(srmName))
                {
                    if (_btnAuto.Single(b => b.GroupCaption == groupCaption).Enabled == false)
                    {
                        Task.Factory.StartNew(() => SRMS[srmName].SetAuto(true));
                        _btnAuto.Single(b => b.GroupCaption == groupCaption).Enabled = false;
                        _btnHand.Single(b => b.GroupCaption == groupCaption).Enabled = true;
                    }
                    else
                    {
                        Task.Factory.StartNew(() => SRMS[srmName].SetAuto(false));
                        _btnAuto.Single(b => b.GroupCaption == groupCaption).Enabled = true;
                        _btnHand.Single(b => b.GroupCaption == groupCaption).Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.StackTrace);
            }
        }

        private bool InitSRMS(string srmName)
        {
            if (!SRMS.ContainsKey(srmName))
            {
                var srm = AutomationContext.Read(memoryServiceName, srmName) as SRM;

                if (srm != null)
                {
                    SRMS.Add(srmName, srm);
                    return true;
                }
                return false;
            }
            return true;
        }

        [Export("BeforeStopping", typeof(Func<bool>))]
        public bool BeforeStopping()
        {
            Shell.BeginInvoke((MethodInvoker)(() =>
                {
                    if (_btnAuto.All(a =>
                        {
                            a.Enabled = true;
                            return true;
                        }))
                    {
                        RefreshAction();
                    }
                }));
            return true;
        }
    }
}
