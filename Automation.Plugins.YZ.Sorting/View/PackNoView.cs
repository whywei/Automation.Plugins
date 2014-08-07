using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DevExpress.XtraGrid;
using Automation.Plugins.YZ.Sorting.View.Controls;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.Properties;
using DevExpress.XtraGrid.Views.Grid;
using Automation.Plugins.YZ.Sorting.Dal;
using DevExpress.XtraEditors;
using Automation.Plugins.YZ.Sorting.Process;
using System.Data;
using DevExpress.XtraSplashScreen;
using System.Threading.Tasks;
using Automation.Plugins.MainPlugin.View.Forms;

namespace Automation.Plugins.YZ.Sorting.View
{
    public class PackNoView:AbstractView
    {
        private GridControl gridControl = null;
        private GridView gridMasterView = null;
        private GridControl gridDetailControl = null;
        private PackNoDal packNoDal = new PackNoDal();

        public override void Initialize()
        {
            this.DefaultSortOrder = 104;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kPackNoQuery";
            this.Caption = "烟包查询";
            this.InnerControl = new PackNoControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.refresh_32x32;

            gridControl = ((PackNoControl)this.InnerControl).gridMaster;
            gridMasterView = ((PackNoControl)this.InnerControl).viewMaster;
            gridDetailControl = ((PackNoControl)this.InnerControl).gridDetail;
            gridMasterView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(GridMasterView_RowClick);
        }

        public void Refresh()
        {
            gridControl.DataSource = packNoDal.FindMaster();
            gridDetailControl.DataSource = null;          
        }
        private void GridMasterView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridDetailControl.DataSource = packNoDal.FindDetail(gridMasterView.GetRowCellValue(gridMasterView.GetSelectedRows()[0], "pack_no").ToString());
        }

        public void Print()
        {
            PrintSettingView controller = new PrintSettingView(this.gridDetailControl);
            controller.PrintHeader = "烟包信息";
            controller.Preview();
        }

        public void CheckPackNo()
        {
            if (gridMasterView.GetSelectedRows().Count() > 0)
            {
                string packNo = gridMasterView.GetRowCellValue(gridMasterView.GetSelectedRows()[0], "pack_no").ToString();
                bool isStart = Ops.ReadSingle<bool>(Global.memoryServiceName_TemporarilySingleData, Global.memoryItemName_SortingState);
                if (!isStart)
                {
                    if (XtraMessageBox.Show(string.Format("您确定要将下单记录校正到第 {0} 包吗？\n小于此包号的数据将标记为已下单。(慎用)", packNo), "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SplashScreenManager.ShowForm((Form)Shell, typeof(frmWaitForm), false, true);
                        OrderDal orderDal = new OrderDal();
                        SortingDal sortingDal = new SortingDal();
                        //更新主表状态
                        orderDal.UpdateStatus(packNo);
                        //清空下单表
                        orderDal.DeleteTable("sorting");
                        //生成下单数据
                        InsertIntoSorting(1, packNo);
                        InsertIntoSorting(2, packNo);
                        Logger.Info(string.Format("订单校正成功！烟包号：{0}。", packNo));
                        Refresh();
                        SplashScreenManager.CloseForm();
                    }
                }
                else
                {
                    Logger.Error("请先停止分拣！");
                    XtraMessageBox.Show("请先停止分拣！", "提示");
                }
            }
            else
            {
                XtraMessageBox.Show("请选中相应的数据！", "提示");
            }
        }

        public void InsertIntoSorting(int groupNo, string packNo)
        {
            SortingDal sortingDal = new SortingDal();
            OrderDal orderDal = new OrderDal();
            int packNo2 = Convert.ToInt32(packNo) - 1;
            for (int i = 1; i <= 20; i++)
            {
                DataTable table = orderDal.FindOrderDetailByPackNo(packNo2, groupNo);
                foreach (DataRow row in table.Rows)
                {
                    int sortNo = sortingDal.FindMaxSortNo();
                    sortingDal.InsertIntoSorting(sortNo + 1, row);
                }
                packNo2 = sortingDal.FindMaxPackNo(groupNo);
            }
        }
    }
}
