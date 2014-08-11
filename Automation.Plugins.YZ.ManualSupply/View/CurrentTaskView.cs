using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Automation.Core;
using Automation.Plugins.YZ.ManualSupply.View.Controls;
using Automation.Plugins.YZ.ManualSupply.Dal;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DotSpatial.Controls.Docking;
using System.Drawing;

namespace Automation.Plugins.YZ.ManualSupply.View
{
    public class CurrentTaskView : AbstractView
    {
        HandSupplyDal handSupplyDal = new HandSupplyDal();
        DataTable handSupplyTable = null;
        int supplyBatch = 0;

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

            gridView.RowCellClick += new RowCellClickEventHandler(GridView_RowCellClick);
        }

        public void Refresh()
        {
            int iSupplyBatch = handSupplyDal.GetCurrentSupplyBatch();
            supplyBatch = iSupplyBatch;
            handSupplyTable = handSupplyDal.GetHandSupplyBySupplyBatch(supplyBatch);
            gridControl.DataSource = handSupplyTable;
        }

        private void GridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                string supplyIdValue = gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns["supply_id"]).ToString();
                string statusValue = gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns["status"]).ToString();

                if (statusValue == "True")
                {
                    gridView.SetRowCellValue(gridView.GetSelectedRows()[0], "status", "True");
                }
                else
                {
                    for (int i = 0; i < gridView.FocusedRowHandle; i++)
                    {
                        if (gridView.FocusedRowHandle > 0)
                        {
                            if (gridView.GetRowCellValue(gridView.FocusedRowHandle - 1, gridView.Columns["status"]).ToString() == "False")
                            {
                                XtraMessageBox.Show("前面还有卷烟未进行补货，请先补前面未补货的卷烟！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    handSupplyDal.FinishSupply(supplyIdValue);
                    gridView.SetRowCellValue(gridView.GetSelectedRows()[0], "status", "True");
                    
                    int hasData = handSupplyDal.GetCurrentSupplyBatch();
                    if (supplyBatch != hasData)
                    {
                        this.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
