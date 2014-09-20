using System;
using Automation.Core;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using Automation.Plugins.Common.Forklift.View.Controls;

namespace Automation.Plugins.Common.Forklift.View
{
    public class ForkliftManagerView : AbstractView, IPartImportsSatisfiedNotification
    {
        private const string memoryServiceName = "MemoryPermanentSingleDataService";

        private IForklift forklift = null;
        public IForklift Forklift
        {
            get
            {
                return forklift;
            }
            set
            {
                forklift = value;
                var control = this.InnerControl as ForkliftControl;
                if (control != null)
                {
                    control.Forklift = value;
                }
            }
        }

        public override void Initialize()
        {
            this.DefaultSortOrder = 102;
        }

        public override void Activate()
        {
            this.Key = "kForklift";
            this.Caption = "车载";
            this.InnerControl = new ForkliftControl();
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

        public override void RefreshView()
        {
            Refresh();
        }
        
        public void OnImportsSatisfied()
        {
            App.ExtensionsActivated += new EventHandler(App_ExtensionsActivated);
        }

        private void App_ExtensionsActivated(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {

        }
    }
}
