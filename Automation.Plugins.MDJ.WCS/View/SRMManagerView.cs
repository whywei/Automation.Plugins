using System;
using Automation.Core;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel.Composition;
using Automation.Plugins.MDJ.WCS.Properties;
using Automation.Plugins.MDJ.WCS.View.Controls;
using Automation.Plugins.MDJ.WCS;
using Automation.Plugins.MDJ.WCS.Device;

namespace Automation.MainPlugin.View
{
    public class SRMManagerView : AbstractView, IPartImportsSatisfiedNotification
    {
        private const string memoryServiceName = "MemoryPermanentSingleDataService";

        public override void Initialize()
        {
            this.DefaultSortOrder = 102;
        }

        public override void Activate()
        {
            this.Key = "kSRM";
            this.Caption = "堆垛机";
            this.InnerControl = new SRMManagerPanel();
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
            var srm = AutomationContext.Read(memoryServiceName, "SRM01") as SRM;
            ((SRMManagerPanel)this.InnerControl).srmControl1.SRM = srm;

            srm = AutomationContext.Read(memoryServiceName, "SRM02") as SRM;
            ((SRMManagerPanel)this.InnerControl).srmControl2.SRM = srm;

            srm = AutomationContext.Read(memoryServiceName, "SRM03") as SRM;
            ((SRMManagerPanel)this.InnerControl).srmControl3.SRM = srm;

            srm = AutomationContext.Read(memoryServiceName, "SRM04") as SRM;
            ((SRMManagerPanel)this.InnerControl).srmControl4.SRM = srm;
        }
    }
}
