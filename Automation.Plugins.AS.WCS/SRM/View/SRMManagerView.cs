using System;
using Automation.Core;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using Automation.Plugins.AS.WCS.Properties;
using Automation.Plugins.AS.WCS.SRM.View.Controls;
using Automation.Common.SRM;

namespace Automation.Plugins.AS.WCS.SRM.View
{
    public class SRMManagerView : AbstractView, IPartImportsSatisfiedNotification
    {
        private const string memoryServiceName = "MemoryPermanentSingleDataService";

        private ISRM srm = null;
        public ISRM SRM
        {
            get
            {
                return srm;
            }
            set
            {
                srm = value;
                var control = this.InnerControl as SRMControl;
                if (control != null)
                {
                    control.SRM = value;
                }
            }
        }

        public override void Initialize()
        {
            this.DefaultSortOrder = 102;
        }

        public override void Activate()
        {
            this.Key = "kSRM";
            this.Caption = "堆垛机";
            this.InnerControl = new SRMControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.info_rhombus_32x32;
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
