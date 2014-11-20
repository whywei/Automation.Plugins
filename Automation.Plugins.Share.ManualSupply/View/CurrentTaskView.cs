using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Automation.Core;
using Automation.Plugins.Share.ManualSupply.View.Controls;
using Automation.Plugins.Share.ManualSupply.Dal;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils;
using DotSpatial.Controls.Docking;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Automation.Plugins.Share.ManualSupply.View
{
    public class CurrentTaskView : AbstractView
    {
        HandSupplyDal handSupplyDal = new HandSupplyDal();
        DataTable handSupplyTable = null;
        int supplyBatch = 0;

        GridControl gridControl = null;
        GridView gridView = null;

        static Color backColor1 = Color.LimeGreen;
        static Color backColor2 = Color.GreenYellow;
        AppearanceDefault appNotPass1 = new AppearanceDefault(Color.Black, backColor1, Color.Empty, backColor2, LinearGradientMode.Horizontal);
        AppearanceDefault appNotPass2 = new AppearanceDefault(Color.Black, Color.Transparent, Color.Empty, Color.SeaShell, LinearGradientMode.Horizontal);

        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kCurrentTask";
            this.Caption = "当前任务";
            this.InnerControl = new CurrentTaskControl();
            this.Dock = DockStyle.Fill;
            
            gridControl = ((CurrentTaskControl)this.InnerControl).gridControl1;
            gridView = ((CurrentTaskControl)this.InnerControl).gridView1;

            gridView.RowCellClick += new RowCellClickEventHandler(GridView_RowCellClick);
            gridView.RowStyle += new RowStyleEventHandler(GridView_RowStyle);
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

        public void Print()
        {
            PrintUtil controller = new PrintUtil(this.gridControl);
            controller.PrintHeader = "当前任务";
            controller.Preview();
        }

        private void GridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "status")
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
                if (gridView.FocusedRowHandle != 0)
                {
                    gridView.Appearance.FocusedRow.BackColor = backColor2;
                    gridView.Appearance.FocusedRow.BackColor2 = backColor1;
                    gridView.Appearance.FocusedRow.ForeColor = Color.DarkRed;
                }
                if (dr["status"].ToString() == "True")
                    AppearanceHelper.Apply(e.Appearance, appNotPass1);
                else if (dr["status"].ToString() == "False")
                    AppearanceHelper.Apply(e.Appearance, appNotPass2);
            }
        }

        private void GridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            AppearanceDefault appNotPass1 = new AppearanceDefault(Color.Black, Color.FromArgb(192, 255, 192), Color.Blue, Color.Green);
            AppearanceDefault appNotPass2 = new AppearanceDefault(Color.Black, Color.Transparent, Color.Empty, Color.SeaShell);

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

        private void GridView_RowCellCustomDraw(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == gridView.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Red;
            }
        }
    }
}
