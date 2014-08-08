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
            
            gridView.CellValueChanging += new CellValueChangedEventHandler(GridView_CellValueChanged);
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
            //this.LoadColor(gridView);
        }

        private void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                string sourceStatus = gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns["status"]).ToString();
                string sourceSupplyId = gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns["supply_id"]).ToString();
                handSupplyDal.FinishSupply(sourceSupplyId);
                
                //this.Refresh();

                //if (sourceStatus == "False")
                //{
                //    LoadColor(gridView);
                //    gridView.Appearance.FocusedRow.BackColor = Color.Red;
                //    XtraMessageBox.Show("前面还有卷烟未进行补货,请先补前面未补货的卷烟!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                //    gridView.Appearance.FocusedRow.BackColor = Color.White;
                //    return;
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadColor(GridView gv)
        {
            for (int i = 0; i < gv.RowCount; i++)
            {
                string sourceStatus = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["status"]).ToString();
                if (sourceStatus == "True")
                {
                    gv.Appearance.FocusedRow.BackColor = Color.FromArgb(192, 255, 192);
                    gv.Columns["status"].OptionsColumn.AllowEdit = false;
                }
                else if (sourceStatus == "False")
                {
                    if (i >= 1 && gv.FocusedRowHandle > 0)
                    {
                        if (gv.GetRowCellValue(gv.FocusedRowHandle -1 , gv.Columns["status"]).ToString() == "True")
                        {
                            gv.Appearance.FocusedRow.BackColor = Color.Red;
                        }
                        else
                        {
                            gv.Appearance.FocusedRow.BackColor = Color.Blue;
                        }
                    }
                    else
                    {
                        if (sourceStatus == "False")
                        {
                            gv.Appearance.FocusedRow.BackColor = Color.Red;
                        }
                    }
                }
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
