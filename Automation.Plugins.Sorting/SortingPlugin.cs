using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotSpatial.Controls;
using DotSpatial.Controls.Header;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using Automation.Core;
using DotSpatial.Controls.Docking;
using Automation.Plugins.Sorting.Action;

namespace Automation.Plugins.Sorting
{
    public class SortingPlugin : Extension
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
            AutomationContext.DeactivateView();
            App.HeaderControl.RemoveAll();
            base.Deactivate();
        }

        private void AddHeaderRootItems()
        {
            IHeaderControl header = App.HeaderControl;
            header.Add(new RootItem("kSorting", "分拣管理") { SortOrder = 501 });
        }
    }
}
