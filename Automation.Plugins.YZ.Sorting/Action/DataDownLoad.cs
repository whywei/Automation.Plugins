using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;
using Automation.Plugins.YZ.Sorting.Dal;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.View.Dialog;
using DevExpress.XtraEditors;

namespace Automation.Plugins.YZ.Sorting.Action
{
    public class DataDownLoad
    {
        //委托
        public delegate void dDownloadProgress(int total, string title);
        //事件
        public event dDownloadProgress onDownLoadProgress;

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
                using (TransactionScopeManager TM = new TransactionScopeManager())
                {

                    OrderDal orderDal = new OrderDal();
                    orderDal.TransactionScopeManager = TM;

                    if (orderDal.FindUnsortCount() == true)
                        if (DialogResult.Cancel == MessageBox.Show("还有未分拣的数据，您确定要重新下载数据吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                            return;

                    ChannelDal channelDal = new ChannelDal();
                    ServerDal serverDal = new ServerDal();
                    var lineCode = Properties.Settings.Default.Sorting_Line_Code;
                    if (lineCode == null || lineCode == "")
                    {
                        XtraMessageBox.Show("未找到分拣线配置！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataTable table = serverDal.FindBatch(lineCode);
                    if (table.Rows.Count > 0)
                    {
                        //给plc写重新分拣标志
                        bool result = Ops.Write(Global.plcServiceName, "Restart_Sign", 1);
                        if (!result)
                            return;
                        dialog = new DownLoadDataDialog(table);
                        dialog.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("没有需要分拣的订单数据。", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception e)
            {
                Logger.Error("下载数据失败！原因：" + e.Message);
            }
        }

        public void Start(string batchId)
        {
            ServerDal serverDal = new ServerDal();
            OrderDal orderDal = new OrderDal();
            DataTable table = new DataTable();
            ChannelDal channelDal = new ChannelDal();
            SortingDal sortingDal = new SortingDal();
            int total =0;
            //清空数据
            orderDal.DeleteTable("sorting");
            orderDal.DeleteTable("export_pack");
            orderDal.DeleteTable("handle_supply");
            orderDal.DeleteTable("sort_order_allot_detail");
            orderDal.DeleteTable("sort_order_allot_master");
            orderDal.DeleteTable("Channel_Allot");
            //下载烟道表                          
            table = serverDal.FindChannel(batchId);
            total=table.Rows.Count;
            for (int i = 0; i < total; i++)
            {
                channelDal.InsertChannel(table.Rows[i]);
                onDownLoadProgress(total, "下载烟道信息");
            }
            //下载订单主表
            table = serverDal.FindOrderMaster(batchId);
            total = table.Rows.Count;
            for (int i = 0; i < total; i++)
            {
                orderDal.InsertMaster(table.Rows[i]);
                if (i % 200 == 0) 
                    onDownLoadProgress(total/200+1, "下载主单信息");
            }
            //下载订单明细表                          
            table = serverDal.FindOrderDetail(batchId);
            total = table.Rows.Count;
            for (int i = 0; i < total; i++)
            {
                orderDal.InsertOrderDetail(table.Rows[i]);
                if (i % 1000 == 0)
                    onDownLoadProgress(total/1000+1, "下载细单信息");
            }
            //下载手工补货订单明细表
            table = serverDal.FindHandleSupply(batchId);
            total = table.Rows.Count;
            for (int i = 0; i < total; i++)
            {
                orderDal.InsertHandleSupply(table.Rows[i]);
                onDownLoadProgress(total, "下载手工补货信息");
            }
            //生成下单数据
            for (int i = 1; i <= 10; i++)
            {
                table = orderDal.FindOrderDetailByPackNo(i);
                foreach (DataRow row in table.Rows)
                {
                    int sortNo = sortingDal.FindMaxSortNo();
                    sortingDal.InsertIntoSorting(sortNo + 1, row);
                }
                onDownLoadProgress(10, "生成下单数据");
            }
            //更新批次状态（下载完成）
            serverDal.UpdateBatchStatus(batchId);
            DataTable batchInfo = serverDal.FindBatchInfoById(batchId);
            int sumQuantity = orderDal.FindSumQuantityFromMaster();
            if (batchInfo.Rows.Count > 0)
                Logger.Info(string.Format("订单下载完成。订单日期：{0}，批次：{1}，总量：{2}。", batchInfo.Rows[0]["order_date"], batchInfo.Rows[0]["batch_no"], sumQuantity));
        }
    }
}
