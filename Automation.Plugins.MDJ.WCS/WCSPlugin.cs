using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotSpatial.Controls;
using Automation.Core;
using System.ComponentModel.Composition;
using DotSpatial.Controls.Header;
using System.Windows.Forms;
using Automation.Plugins.MDJ.WCS.Properties;
using DotSpatial.Controls.Docking;
using Automation.Plugins.MDJ.WCS.View;
using Automation.Plugins.MDJ.WCS.Dal;
using Automation.Plugins.MDJ.WCS.View.Dialogs;
using System.Threading;
using System.Data;
using DevExpress.XtraEditors;

namespace Automation.Plugins.MDJ.WCS
{
    public class WCSPlugin : Extension
    {
        
        private const string FileMenuKey = HeaderControl.ApplicationMenuKey;
        private const string HomeMenuKey = HeaderControl.HomeRootItemKey;
        private const string HelpMenuKey = HeaderControl.HeaderHelpItemKey;

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
            header.Add(new RootItem("kScan", "扫码") { SortOrder = 101 });
            header.Add(new RootItem("kSRM", "堆垛机") { SortOrder = 102 });
        }
    }
}
