using DotSpatial.Controls;
using Automation.Core;
using System.ComponentModel.Composition;
using DotSpatial.Controls.Header;
using System.Windows.Forms;

namespace Automation.Plugins.AS.Forklift
{
    public class ForkliftPlugin : Extension
    {
        [Import]
        public AutomationContext AutomationContext { get; set; }

        [Import("Shell", typeof(ContainerControl))]
        public ContainerControl Shell { get; set; }

        public override void Activate()
        {
            AddHeaderRootItems();
            AutomationContext.ActivateAction();
            AutomationContext.ActivateView();     
            base.Activate();            
        }

        public override void Deactivate()
        {
            AutomationContext.DeactivateAction();
            AutomationContext.DeactivateView();
            App.HeaderControl.RemoveAll();
            base.Deactivate();
        }

        private void AddHeaderRootItems()
        {
            IHeaderControl header = App.HeaderControl;            
            header.Add(new RootItem("kForklift", "叉车") { SortOrder = 101 });
        }
    }
}
