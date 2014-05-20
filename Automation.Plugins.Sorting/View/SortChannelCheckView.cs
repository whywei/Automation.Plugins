using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.Sorting.View.Controls;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using Automation.Plugins.Sorting.Dal;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using Automation.Plugins.Sorting.View.Dialog;
using System.Drawing;
using System.Reflection;

namespace Automation.Plugins.Sorting.View
{
    public class SortChannelCheckView: AbstractView
    {
        private GridControl gridControl = null;
        private ChannelDal channelDal = new ChannelDal();
        private OrderDal orderDal = new OrderDal();
        private GridView gridView = null;

        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kSortChannelCheck";
            this.Caption = "烟道盘点";
            this.InnerControl = new SortChannelCheckControl();
            this.Dock = DockStyle.Fill;
            gridControl = ((SortChannelCheckControl)this.InnerControl).gridSortChannelCheck;
            gridView = ((SortChannelCheckControl)this.InnerControl).viewSortChannelCheck;
        }

        public void Refresh(int sortNo)
        {
            if (sortNo != -1)
            {
                gridControl.DataSource = channelDal.FindChannelQuantity(sortNo);
            }
            else
            {
                OrderDal orderDal = new OrderDal();
                string sortNo_A = orderDal.FindMaxSortedMaster("A");
                string sortNo_B = orderDal.FindMaxSortedMaster("B");
                DataTable channel = channelDal.FindAllChannelQuantity(sortNo_A, sortNo_B);
                short[] quantity = new short[140];
                object state_A = Ops.Read(Global.ServiceName_SortingOPC,"A_Led_Process_Check");
                if (state_A is Array)
                {
                    Array arrayA = (Array)state_A;
                    if (arrayA.Length == 70)
                    {
                        arrayA.CopyTo(quantity, 0);
                    }
                }
                object state_B = Ops.Read(Global.ServiceName_SortingOPC, "B_Led_Process_Check");
                if (state_B is Array)
                {
                    Array arrayB = (Array)state_B;
                    if (arrayB.Length == 70)
                    {
                        arrayB.CopyTo(quantity, 70);
                    }
                }
                for (int i = 0; i < channel.Rows.Count; i++)
                {
                    if (i < 70)
                    {
                        channel.Rows[i]["SORTQUANTITY"] = Convert.ToInt32(channel.Rows[i]["SORTQUANTITY"]) - quantity[Convert.ToInt32(channel.Rows[i]["CHANNELADDRESS"]) - 1];
                        channel.Rows[i]["REMAINQUANTITY"] = Convert.ToInt32(channel.Rows[i]["REMAINQUANTITY"]) + quantity[Convert.ToInt32(channel.Rows[i]["CHANNELADDRESS"]) - 1];
                        channel.Rows[i]["BOXQUANTITY"] = Convert.ToInt32(channel.Rows[i]["REMAINQUANTITY"]) / 50;
                        channel.Rows[i]["ITEMQUANTITY"] = Convert.ToInt32(channel.Rows[i]["REMAINQUANTITY"]) % 50;
                    }
                    if (i >= 70)
                    {
                        channel.Rows[i]["SORTQUANTITY"] = Convert.ToInt32(channel.Rows[i]["SORTQUANTITY"]) - quantity[Convert.ToInt32(channel.Rows[i]["CHANNELADDRESS"]) + 69];
                        channel.Rows[i]["REMAINQUANTITY"] = Convert.ToInt32(channel.Rows[i]["REMAINQUANTITY"]) + quantity[Convert.ToInt32(channel.Rows[i]["CHANNELADDRESS"]) + 69];
                        channel.Rows[i]["BOXQUANTITY"] = Convert.ToInt32(channel.Rows[i]["REMAINQUANTITY"]) / 50;
                        channel.Rows[i]["ITEMQUANTITY"] = Convert.ToInt32(channel.Rows[i]["REMAINQUANTITY"]) % 50;
                    }
                }
                gridControl.DataSource = channel;
                //todo:刷新LED
                //Global.Context.Processes["LEDProcess"].Resume();
                //Global.Context.ProcessDispatcher.WriteToProcess("LEDProcess", "Check", null);
            }
        }

        public void SortChannelSwap()
        {
            if (gridView.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("请选择要交换的烟道！", "提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
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
            swapDialog.Icon=((Form)Shell).Icon ?? Icon.ExtractAssociatedIcon(assembly.Location);
            swapDialog.txtStartPosition.Text = lineCode + "-" + channelGroup + "-" + channelType + "-" + gridView.GetRowCellValue(handle, "CHANNELNAME").ToString();
            swapDialog.cmbTargetPosition.Properties.DataSource = table;
            swapDialog.cmbTargetPosition.Properties.ValueMember = "CODE";
            swapDialog.cmbTargetPosition.Properties.DisplayMember = "CHANNEL";
            if (swapDialog.ShowDialog() == DialogResult.OK)
            {
                if (swapDialog.cmbTargetPosition.EditValue == null)
                    return;
                string tagetChannelCode=swapDialog.cmbTargetPosition.EditValue.ToString();
                string[] data = new string[3];
                orderDal.UpdateOrderDetailByChannelCode(channelCode, "000000");
                orderDal.UpdateOrderDetailByChannelCode(tagetChannelCode, channelCode);
                orderDal.UpdateOrderDetailByChannelCode("000000",tagetChannelCode);
                DataRow row1=channelDal.FindSortChannelByCode(tagetChannelCode);
                DataRow row2 = channelDal.FindSortChannelByCode(channelCode);
                channelDal.UpdateSortChannelByChannelCode(channelCode, row1["CIGARETTECODE"].ToString(), row1["CIGARETTENAME"].ToString(), 
                    row1["QUANTITY"].ToString(), row1["SORTNO"].ToString(), row1["STATUS"].ToString());
                data[0] = row1["CHANNELADDRESS"].ToString();
                channelDal.UpdateSortChannelByChannelCode(tagetChannelCode, row2["CIGARETTECODE"].ToString(), row2["CIGARETTENAME"].ToString(),
                    row2["QUANTITY"].ToString(), row2["SORTNO"].ToString(), row2["STATUS"].ToString());
                data[1] = row2["CHANNELADDRESS"].ToString();
                data[2] = "1";
                if (channelGroup == "A线")
                    Ops.Write(Global.ServiceName_SortingOPC, "A_Channel_Change", data);
                else
                    Ops.Write(Global.ServiceName_SortingOPC, "B_Channel_Change", data);
                Logger.Info(string.Format("{0}{1}号烟道与{2}号烟道交换成功！", channelGroup, data[0], data[1]));
                Refresh(-1);
            }
        }
    }
}
