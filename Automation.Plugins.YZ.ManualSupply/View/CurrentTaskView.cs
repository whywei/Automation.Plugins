using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Automation.Core;
using Automation.Plugins.YZ.ManualSupply.View.Controls;
using DotSpatial.Controls.Docking;
using Automation.Plugins.YZ.ManualSupply.Dal;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Automation.Plugins.YZ.ManualSupply.View
{
    public class CurrentTaskView : AbstractView
    {
        HandSupplyDal handSupplyDal = new HandSupplyDal();
        DataTable handSupplyTable = null;
        int supplyBatch = 0;
        int dataCount = 0;

        GridControl gridControl = null;
        GridView gridView = null;

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

            this.App.DockManager.PanelClosed += new EventHandler<DockablePanelEventArgs>(DockManager_PanelClosed);
            this.App.DockManager.ActivePanelChanged += new EventHandler<DockablePanelEventArgs>(DockManager_ActivePanelChanged);

            gridControl = ((CurrentTaskControl)this.InnerControl).gridControl1;
            gridView = ((CurrentTaskControl)this.InnerControl).gridView1;
            this.Refresh();
        }

        public void Refresh()
        {
            string message = null;
            int iSupplyBatch = handSupplyDal.GetCurrentSupplyBatch(out message);
            supplyBatch = iSupplyBatch;

            handSupplyTable = handSupplyDal.GetHandSupplyBySupplyBatch(supplyBatch);
            dataCount = handSupplyDal.GetHandSupplyCountBySupplyBatch(supplyBatch);
            gridControl.DataSource = handSupplyTable;
            //this.LoadColor(gridControl);
        }

        private void LoadColor()
        { 
            
        }

        private void DockManager_ActivePanelChanged(object sender, DockablePanelEventArgs e)
        {
            if (e.ActivePanelKey == this.Key)
            {
                this.Focus = true;
            }
        }

        private void DockManager_PanelClosed(object sender, DockablePanelEventArgs e)
        {
            if (e.ActivePanelKey == this.Key)
            {
                this.Focus = false;
            }
        }
    }
}
