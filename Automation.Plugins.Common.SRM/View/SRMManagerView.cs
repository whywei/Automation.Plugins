﻿using System;
using Automation.Core;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using Automation.Plugins.Common.SRM.Properties;
using Automation.Plugins.Common.SRM.View.Controls;

namespace Automation.Plugins.Common.SRM.View
{
    public class SRMManagerView : AbstractView, IPartImportsSatisfiedNotification
    {
        [Import]
        public SRMManager SRMManager { get; set; }

        private SRMControl srmControl = null;

        public override void Initialize()
        {
            this.DefaultSortOrder = 102;
        }

        public override void Activate()
        {
            this.Key = "kSRM";
            this.Caption = "堆垛机";
            srmControl = new SRMControl();
            this.InnerControl = srmControl; 
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
            lock (this)
            {
                srmControl.SRM = SRMManager.ActiveSRM;
            }
        }
    }
}
