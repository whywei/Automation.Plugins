using DotSpatial.Controls;
using Automation.Core;
using System.ComponentModel.Composition;
using DotSpatial.Controls.Header;
using System.Windows.Forms;
using System;
using Automation.Plugins.YZ.ManualSupply.View;
using Automation.Plugins.YZ.ManualSupply.Properties;

namespace Automation.Plugins.YZ.WCS
{
    public class ManualSupplyPlugin : Extension
    {
        [Import]
        public AutomationContext AutomationContext { get; set; }

        [Import("Shell", typeof(ContainerControl))]
        public ContainerControl Shell { get; set; }

        private const string rootKey = "kManualSupply";

        public override void Activate()
        {
            AddHeaderRootItems();
            AutomationContext.ActivateAction();
            AutomationContext.ActivateView();     
            base.Activate();            
        }

        public override void Deactivate()
        {
            AutomationContext.DeactivateView();
            App.HeaderControl.RemoveAll();
            base.Deactivate();
        }

        private void AddHeaderRootItems()
        {
            IHeaderControl header = App.HeaderControl;
            header.Add(new RootItem(rootKey, "手工补货") { SortOrder = 106 });
            header.Add(new SimpleActionItem(rootKey, "卷烟查询", ProductCheck_Click) { ToolTipText = "手工补货卷烟查询", GroupCaption = "查询", SortOrder = 1, LargeImage = Resource.Product_32 });
            header.Add(new SimpleActionItem(rootKey, "作业查询", AllTask_Click) { ToolTipText = "全部作业查询", GroupCaption = "查询", SortOrder = 2, LargeImage = Resource.Task_32 });
            header.Add(new SimpleActionItem(rootKey, "混合烟道", MixedChannel_Click) { ToolTipText = "混合烟道卷烟查询", GroupCaption = "查询", SortOrder = 3, LargeImage = Resource.yandao_32x32 });
        }

        private void ProductCheck_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<ProductCheckView>();
        }

        private void AllTask_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<AllTaskView>();
        }

        private void MixedChannel_Click(object sender, EventArgs e)
        {
            AutomationContext.ActivateView<MixedChannelView>();
        }
    }
}
