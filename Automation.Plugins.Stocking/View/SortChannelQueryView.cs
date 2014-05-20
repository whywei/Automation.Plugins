using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.Stocking.View.Controls;
using DevExpress.XtraGrid;
using Automation.Plugins.Stocking.Dal;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using DevExpress.XtraEditors;
using System.Reflection;
using Automation.Plugins.Sorting.View.Dialog;
using System.Drawing;

namespace Automation.Plugins.Stocking.View
{
    public class SortChannelQueryView:AbstractView
    {
        private GridControl gridControl = null;
        private GridView gridView = null;
        private ChannelDal channelDal = new ChannelDal();
        private DataTable channelTable = null;

        public override void Initialize()
        {
            DefaultSortOrder = 302;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kSortChannelQuery";
            this.Dock = DockStyle.Fill;
            this.InnerControl = new SortChannelQueryControl();
            this.Caption = "分拣烟道";
            gridControl = ((SortChannelQueryControl)this.InnerControl).gridSortChannel;
            gridView = ((SortChannelQueryControl)this.InnerControl).viewSortChannel;
        }

        public void Refresh()
        {
            ChannelDal channelDal = new ChannelDal();
            gridControl.DataSource = channelDal.FindAllSortChannel();
        }

        public List<string> FindSortChannelList()
        {
            channelTable = channelDal.FindSortChannelList();
            return DataTableToList(channelTable.Select());
        }

        public List<string> FindSortChannelListBySelectedValue(string channelItem)
        {
            return DataTableToList(channelTable.Select(string.Format("CHANNELITEM='{0}'", channelItem), "CHANNELITEM"));
        }

        private List<string> DataTableToList(DataRow[] rows)
        {
            List<string> list = new List<string>();
            foreach (DataRow row in rows)
            {
                list.Add(row[0].ToString());
            }
            return list;
        }

        public void SortChannelSwap()
        {
            if (gridView.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("请选择要交换的烟道！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Assembly assembly = Assembly.GetEntryAssembly();
            int handle = gridView.GetSelectedRows()[0];
            string lineCode = gridView.GetRowCellValue(handle, "LINECODE").ToString();
            string channelGroup = gridView.GetRowCellValue(handle, "CHANNELGROUP").ToString();
            string channelCode = gridView.GetRowCellValue(handle, "CHANNELCODE").ToString();
            string channelType = gridView.GetRowCellValue(handle, "CHANNELTYPE").ToString();
            DataTable table = channelDal.FindSortChannel(lineCode, channelType, channelGroup, channelCode);
            SortChannelSwapDialog swapDialog = new SortChannelSwapDialog();
            swapDialog.Icon = ((Form)Shell).Icon ?? Icon.ExtractAssociatedIcon(assembly.Location);
            swapDialog.txtStartPosition.Text = lineCode + "-" + channelGroup + "-" + channelType + "-" + gridView.GetRowCellValue(handle, "CHANNELNAME").ToString();
            swapDialog.cmbTargetPosition.Properties.DataSource = table;
            swapDialog.cmbTargetPosition.Properties.ValueMember = "CODE";
            swapDialog.cmbTargetPosition.Properties.DisplayMember = "CHANNEL";
            if (swapDialog.ShowDialog() == DialogResult.OK)
            {
                if (swapDialog.cmbTargetPosition.EditValue == null)
                    return;
                string tagetChannelCode = swapDialog.cmbTargetPosition.EditValue.ToString();
                DataRow sourceChannelRow = channelDal.FindSortChannelUSED(lineCode, channelCode);
                DataRow targetChannelRow = channelDal.FindSortChannelUSED(lineCode, tagetChannelCode);
                channelDal.UpdateSortChannelUSED(lineCode, tagetChannelCode,
                            sourceChannelRow["CIGARETTECODE"].ToString(),
                            sourceChannelRow["CIGARETTENAME"].ToString(),
                            sourceChannelRow["QUANTITY"].ToString(),
                            sourceChannelRow["SORTNO"].ToString());

                channelDal.UpdateSortChannelUSED(lineCode, channelCode,
                     targetChannelRow["CIGARETTECODE"].ToString(),
                     targetChannelRow["CIGARETTENAME"].ToString(),
                     targetChannelRow["QUANTITY"].ToString(),
                     targetChannelRow["SORTNO"].ToString());
                StockingDal stockingDal = new StockingDal();
                stockingDal.UpdateSortChannelUSED(lineCode, channelCode, "000000", targetChannelRow["GROUPNO"].ToString());
                stockingDal.UpdateSortChannelUSED(lineCode, tagetChannelCode, channelCode, sourceChannelRow["GROUPNO"].ToString());
                stockingDal.UpdateSortChannelUSED(lineCode, "000000", tagetChannelCode, targetChannelRow["GROUPNO"].ToString());

                Logger.Info(string.Format("{0}{1}号烟道与{2}号烟道交换成功！", channelGroup, channelCode, tagetChannelCode));
                Refresh();
            }
        }
    }
}
