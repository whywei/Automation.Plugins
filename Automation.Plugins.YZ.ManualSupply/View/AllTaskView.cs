using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Automation.Core;
using Automation.Plugins.YZ.ManualSupply.Dal;
using Automation.Plugins.YZ.ManualSupply.View.Controls;

namespace Automation.Plugins.YZ.ManualSupply.View
{
    public class AllTaskView : AbstractView
    {
        int supplyBatch = 0;
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
        { }

        public void NextPage()
        { }

        public void Print()
        { }
    }
}
