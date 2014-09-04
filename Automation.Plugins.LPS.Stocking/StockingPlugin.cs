using DotSpatial.Controls;
using Automation.Core;
using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace Automation.Plugins.LPS.Stocking
{
    public class StockingPlugin : Extension
    {
        [Import]
        public AutomationContext AutomationContext { get; set; }        

        [Import("Shell", typeof(ContainerControl))]
        public ContainerControl Shell { get; set; }

        public override void Activate()
        {
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
    }
}
