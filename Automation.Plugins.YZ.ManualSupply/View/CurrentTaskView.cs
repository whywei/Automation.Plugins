using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.YZ.ManualSupply.View.Controls;
using System.Windows.Forms;

namespace Automation.Plugins.YZ.ManualSupply.View
{
    public class CurrentTaskView : AbstractView
    {
        public override void Initialize()
        {
            DefaultSortOrder = 201;
            IsPreload = true;
        }

        public override void Activate()
        {
            this.Key = "kManualSupply";
            this.Caption = "补货作业";
            this.InnerControl = new CurrentTaskControl();
            this.Dock = DockStyle.Fill;

            this.App.DockManager.PanelClosed += new EventHandler<DotSpatial.Controls.Docking.DockablePanelEventArgs>(DockManager_PanelClosed);
            this.App.DockManager.ActivePanelChanged += new EventHandler<DotSpatial.Controls.Docking.DockablePanelEventArgs>(DockManager_ActivePanelChanged);
        }

        private void DockManager_ActivePanelChanged(object sender, DotSpatial.Controls.Docking.DockablePanelEventArgs e)
        {
            if (e.ActivePanelKey == this.Key)
            {
                this.Focus = true;
            }
        }

        private void DockManager_PanelClosed(object sender, DotSpatial.Controls.Docking.DockablePanelEventArgs e)
        {
            if (e.ActivePanelKey == this.Key)
            {
                this.Focus = false;
            }
        }
    }
}
