using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Automation.Plugins.YZ.Sorting.Dal;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.View.Dialog;
using DevExpress.XtraEditors;
using System.ComponentModel.Composition;
using System.Transactions;
using System.Reflection;
using System.Drawing;

namespace Automation.Plugins.YZ.Sorting.Action
{
    public class DataDownLoad
    {
        //委托
        public delegate void dDownloadProgress(int total, string title);
        //事件
        public event dDownloadProgress onDownLoadProgress;
        private ServerDal serverDal = new ServerDal();
        private OrderDal orderDal = new OrderDal();
        private DataTable table = new DataTable();
        private ChannelDal channelDal = new ChannelDal();
        private SortingDal sortingDal = new SortingDal();

        private DownLoadDataDialog dialog = null;

        public void Data()
        {
            lock (this)
            {
                DownloadData();
            }
        }
        private void DownloadData()
        {
            try
            {
                if (orderDal.FindUnsortCount() == true)
                    if (DialogResult.Cancel == XtraMessageBox.Show("还有未分拣的数据，您确定要重新下载数据吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                        return;
                var lineCode = Properties.Settings.Default.Sorting_Line_Code;
                if (lineCode == null || lineCode == "")
                {
                    XtraMessageBox.Show("未找到分拣线配置！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable table = serverDal.FindBatch(lineCode);
                if (table.Rows.Count > 0)
                {
                    dialog = new DownLoadDataDialog(table);
                    Assembly assembly = Assembly.GetEntryAssembly();
                    dialog.Icon = Icon.ExtractAssociatedIcon(assembly.Location);
                    dialog.ShowDialog();
                }
                else
                    XtraMessageBox.Show("没有需要分拣的订单数据。", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);  
            }
            catch (Exception e)
            {
                Logger.Error("下载数据失败！原因：" + e.Message);
            }
        }

        public void Start(string batchId)
        {
            try
            {
                int total = 0;
                //给plc写重新分拣标志
                bool result = Ops.Write(Global.plcServiceName, "Restart_Sign", 1);
                if (!result)
                {
                    XtraMessageBox.Show("将数据写入OPC失败！");
                    return;
                }
                //清空数据
                orderDal.DeleteTable("sorting");
                orderDal.DeleteTable("export_pack");
                orderDal.DeleteTable("handle_supply");
                orderDal.DeleteTable("sort_order_allot_detail");
                orderDal.DeleteTable("sort_order_allot_master");
                orderDal.DeleteTable("Channel_Allot");
                //下载烟道表                          
                table = serverDal.FindChannel(batchId);
                total = table.Rows.Count;
                for (int i = 0; i < total; i++)
                {
                    channelDal.InsertChannel(table.Rows[i]);
                    onDownLoadProgress(total, "下载烟道信息");
                }
                //更新没有条码的卷烟
                table = channelDal.FindLessBarCodeChannel();
                for (int i = 0; i < table.Rows.Count;i++ )
                {
                    string pieceBarCode = (i.ToString() + table.Rows[i]["product_code"].ToString()).Substring(0, 6);
                    channelDal.UpdatePieceBarCode(table.Rows[i]["product_code"].ToString(), pieceBarCode);
                }
                //将卷烟信息写入PLC
                WriteProductInfoToPLC();
                //下载订单主表
                table = serverDal.FindOrderMaster(batchId);
                int temp;
                total = table.Rows.Count;
                if (total >= 200)
                {
                    temp = total / 100;
                }
                else
                {
                    temp = 1;
                }
                for (int i = 0; i < total; i++)
                {
                    orderDal.InsertMaster(table.Rows[i]);
                    if (i == 14253)
                    {
                        int j = 2;
                    }
                    if (i % temp == 0)
                        onDownLoadProgress(total / temp, "下载主单信息");
                }
                //下载订单明细表                          
                table = serverDal.FindOrderDetail(batchId);
                total = table.Rows.Count;
                if (total >= 200)
                {
                    temp = total / 100;
                }
                else
                {
                    temp = 1;
                }
                for (int i = 0; i < total; i++)
                {
                    orderDal.InsertOrderDetail(table.Rows[i]);
                    if (i % temp == 0)
                        onDownLoadProgress(total / temp, "下载细单信息");
                }
                //下载手工补货订单明细表
                table = serverDal.FindHandleSupply(batchId);
                total = table.Rows.Count;
                if (total >= 200)
                {
                    temp = total / 100;
                }
                else
                {
                    temp = 1;
                }
                for (int i = 0; i < total; i++)
                {
                    orderDal.InsertHandleSupply(table.Rows[i]);
                    if (i % temp == 0)
                        onDownLoadProgress(total / temp, "下载手工补货信息");
                }
                //生成下单数据
                int[] groupNoArray = new int[2] { 1, 2 };
                foreach (int groupNo in groupNoArray)
                {
                    for (int i = 1; i <= 20; i++)
                    {
                        int packNo = sortingDal.FindMaxPackNo(groupNo);
                        table = orderDal.FindOrderDetailByPackNo(packNo, groupNo);
                        foreach (DataRow row in table.Rows)
                        {
                            int sortNo = sortingDal.FindMaxSortNo();
                            sortingDal.InsertIntoSorting(sortNo + 1, row);
                        }
                        onDownLoadProgress(40, "生成下单数据");
                    }
                }
                //更新批次状态（下载完成）
                serverDal.UpdateBatchStatus(batchId);
                DataTable batchInfo = serverDal.FindBatchInfoById(batchId);
                int sumQuantity = orderDal.FindSumQuantityFromMaster();
                if (batchInfo.Rows.Count > 0)
                    Logger.Info(string.Format("订单下载完成。订单日期：{0}，批次：{1}，总量：{2}。", batchInfo.Rows[0]["order_date"], batchInfo.Rows[0]["batch_no"], sumQuantity));
            }
            catch (Exception ex)
            {
                string msg = string.Format("下载失败！原因：{0}。", ex.Message);
                XtraMessageBox.Show(msg);
                Logger.Error(msg + ex.StackTrace);
            }
        }

        public void WriteProductInfoToPLC()
        {
            DataTable table = channelDal.FindAllProduct();
            int[] barCode = new int[table.Rows.Count];
            string[] productName = new string[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                barCode[i] = Convert.ToInt32(table.Rows[i]["piece_barcode"]);
                productName[i] = table.Rows[i]["product_name"].ToString().Substring(0, 13);
            }
            Ops.Write(Global.plcServiceName, "Cigarette_Barcode_Information", barCode);
            Ops.Write(Global.plcServiceName, "Cigarette_Name_Information", productName);
        }
    }
}
