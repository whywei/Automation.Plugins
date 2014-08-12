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
using DevExpress.Utils;
using DotSpatial.Controls.Docking;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Automation.Plugins.YZ.ManualSupply.View
{
    public class CurrentTaskView : AbstractView
    {
        HandSupplyDal handSupplyDal = new HandSupplyDal();
        DataTable handSupplyTable = null;
        int supplyBatch = 0;

        GridControl gridControl = null;
        GridView gridView = null;

        AppearanceDefault appNotPass1 = new AppearanceDefault(Color.Black, Color.FromArgb(192, 255, 192), Color.Empty, Color.SeaShell, LinearGradientMode.Horizontal);
        AppearanceDefault appNotPass2 = new AppearanceDefault(Color.Black, Color.Transparent, Color.Empty, Color.SeaShell, LinearGradientMode.Horizontal);

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
            gridView.RowStyle += new RowStyleEventHandler(GridView_RowStyle);
            gridView.RowCellStyle += new RowCellStyleEventHandler(GridView_RowCellStyle);
        }

        public void Refresh()
        {
            try
            {
                int iSupplyBatch = handSupplyDal.GetCurrentSupplyBatch();
                supplyBatch = iSupplyBatch;
                handSupplyTable = handSupplyDal.GetHandSupplyBySupplyBatch(supplyBatch);
                gridControl.DataSource = handSupplyTable;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                if (e.Column.VisibleIndex == 0)
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
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            DataRow dr = gridView.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                if (dr["status"].ToString() == "True")
                    AppearanceHelper.Apply(e.Appearance, appNotPass1);
                else if (dr["status"].ToString() == "False")
                    AppearanceHelper.Apply(e.Appearance, appNotPass2);
            }
        }

        private void GridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "status")
            {
                DataRow dr = gridView.GetDataRow(e.RowHandle);
                string strTemp = dr[e.Column.FieldName].ToString().Trim();
                if (!string.IsNullOrEmpty(strTemp))
                {
                    switch (strTemp)
                    {
                        case "True":
                            AppearanceHelper.Apply(e.Appearance, appNotPass1);
                            break;
                        case "False":
                            AppearanceHelper.Apply(e.Appearance, appNotPass2);
                            break;
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
