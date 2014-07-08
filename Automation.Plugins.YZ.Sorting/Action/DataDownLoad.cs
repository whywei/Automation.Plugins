using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;
using Automation.Plugins.YZ.Sorting.Dal;
using Automation.Core;
using System.Windows.Forms;

namespace Automation.Plugins.YZ.Sorting.Action
{
    class DataDownLoad
    {
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

                    DataTable table = serverDal.FindBatch();
                    if (table.Rows.Count != 0)
                    {
                        string batchsortid = table.Rows[0]["batch_no"].ToString();
                        orderDal.DeleteExportData();//删除贴标机数据(未实现删除哪些表)

                       
                        //AutomationContext.Write(plcServiceName, O_StockIn_Task_Info, data);
                        //下载烟道表                          
                        table = serverDal.FindChannel(batchsortid);
                        channelDal.InsertChannel(table);
                        System.Threading.Thread.Sleep(100);
                        //下载订单主表                         
                        table = serverDal.FindOrderMaster(batchsortid);
                        orderDal.InsertMaster(table);
                        System.Threading.Thread.Sleep(100);
                        //下载订单明细表                          
                        table = serverDal.FindOrderDetail(batchsortid);
                        orderDal.InsertOrderDetail(table);


                        //下载手工补货订单明细表
                        table = serverDal.FindHandleSupply(batchsortid);
                        orderDal.InsertHandleSupply(table);


                        //更新批次状态（下载完成）
                        serverDal.UpdateBatchStatus(batchsortid);
                        MessageBox.Show("数据下载完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                      
                        //Context.ProcessDispatcher.WriteToProcess("LEDProcess", "NewData", null);
                        //Context.ProcessDispatcher.WriteToProcess("CreatePackAndPrintDataProcess", "NewData", null);
                        //Context.ProcessDispatcher.WriteToProcess("CurrentOrderProcess", "CurrentOrderA", new int[] { -1 });
                        //Context.ProcessDispatcher.WriteToProcess("monitorView", "ProgressState", new ProgressState());
                    }
                    else
                        MessageBox.Show("没有需要分拣的订单数据。", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception e)
            {
                Logger.Error("下载数据失败！原因：" + e.Message);
            }
        }

    }
}
