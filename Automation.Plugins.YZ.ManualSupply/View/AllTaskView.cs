using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Automation.Core;
using Automation.Plugins.YZ.ManualSupply.Dal;
using Automation.Plugins.YZ.ManualSupply.View.Controls;
using System;
using DotSpatial.Controls.Docking;

namespace Automation.Plugins.YZ.ManualSupply.View
{
    public class AllTaskView : AbstractView
    {
        int supplyBatch = 0;
        int lastPage = 0;

        DataTable handSupplyTable = null;
        HandSupplyDal handSupplyDal = new HandSupplyDal();

        GridControl gridControl = null;
        GridView gridView = null;

        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kAllTask";
            this.Caption = "全部作业";
            this.InnerControl = new AllTaskControl();
            this.Dock = DockStyle.Fill;

            gridControl = ((AllTaskControl)this.InnerControl).gridControl1;
            gridView = ((AllTaskControl)this.InnerControl).gridView1;
            this.App.DockManager.ActivePanelChanged += new EventHandler<DockablePanelEventArgs>(DockManager_ActivePanelChanged);
        }

        public void Refresh()
        {
            supplyBatch = 1;
            handSupplyTable = handSupplyDal.GetHandSupplyBySupplyBatch(supplyBatch);
            if (handSupplyTable.Rows.Count == 0)
            {
                XtraMessageBox.Show("没有数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                gridControl.DataSource = handSupplyTable;
            }
        }

        public void BackPage()
        {
            if (supplyBatch > 1)
            {
                handSupplyTable = handSupplyDal.GetHandSupplyBySupplyBatch(--supplyBatch);
                gridControl.DataSource = handSupplyTable;
            }
        }

        public void NextPage()
        {
            if (supplyBatch < lastPage)
            {
                handSupplyTable = handSupplyDal.GetHandSupplyBySupplyBatch(++supplyBatch);
                gridControl.DataSource = handSupplyTable;
            }
        }

        public void Print()
        {
            PrintUtil controller = new PrintUtil(this.gridControl);
            controller.PrintHeader = "全部作业";
            controller.Preview();
        }

        public void Search(int batchNo)
        {
            int lastBatch = handSupplyDal.GetLastSupplyBatchNo();
            if (batchNo > lastBatch)
            {
                batchNo = lastBatch;
                XtraMessageBox.Show("最大批次是 " + lastBatch, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            supplyBatch = batchNo;
            DataTable batchTaskTable = handSupplyDal.GetHandSupplyBySupplyBatch(supplyBatch);
            gridControl.DataSource = batchTaskTable;
        }

        private void DockManager_ActivePanelChanged(object sender, DockablePanelEventArgs e)
        {
            if (e.ActivePanelKey == this.Key)
            {
                try
                {
                    lastPage = handSupplyDal.GetLastSupplyBatchNo();
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("全部作业查询初始化失败！原因：{0}。", ex.Message));
                }
            }
        }
    }
}
