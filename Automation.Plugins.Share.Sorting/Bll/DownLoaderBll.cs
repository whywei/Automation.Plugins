﻿using System;
using System.Data;
using Automation.Plugins.Share.Sorting.Dal;
using Automation.Core;
using DevExpress.XtraEditors;
using Automation.Plugins.Share.Sorting.View;

namespace Automation.Plugins.Share.Sorting.Bll
{
    public delegate void DownloadProgress(int total, string title);        

    public class DownLoaderBll
    {
        public event DownloadProgress OnDownLoadProgress;

        private ServerDal serverDal = new ServerDal();
        private OrderDal orderDal = new OrderDal();
        private ChannelDal channelDal = new ChannelDal();
        private SortingDal sortingDal = new SortingDal();

        public void Start(string batchId)
        {
            try
            {
                //给plc写重新分拣标志
                if (!Ops.Write(Global.PLC_SERVICE_NAME, "Restart_Sign", 1))
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
                orderDal.DeleteTable("channel_allot");

                //下载烟道表                          
                var table = serverDal.FindChannel(batchId);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (table.Rows[i]["piece_barcode"].ToString().Length > 6)
                    {
                        table.Rows[i]["piece_barcode"] = table.Rows[i]["piece_barcode"].ToString().Substring(0, 6);
                    }
                    channelDal.InsertChannel(table.Rows[i]);
                    OnDownLoadProgress(table.Rows.Count, "下载烟道信息");
                }

                //更新没有条码的卷烟
                table = channelDal.FindLessBarCodeChannel();
                for (int i = 0; i < table.Rows.Count;i++ )
                {
                    string pieceBarCode = (i.ToString() + table.Rows[i]["product_code"].ToString()).Substring(0, 6);
                    channelDal.UpdatePieceBarCode(table.Rows[i]["product_code"].ToString(), pieceBarCode);
                }

                //下载订单主表
                table = serverDal.FindOrderMaster(batchId);                
                int total = table.Rows.Count;
                int temp = total / 100 + 1;

                for (int i = 0; i < total; i++)
                {
                    orderDal.InsertMaster(table.Rows[i]);
                    if (i % temp == 0)
                        OnDownLoadProgress(total / temp, "下载主单信息");
                }

                //下载订单明细表                          
                table = serverDal.FindOrderDetail(batchId);
                total = table.Rows.Count;
                temp = total / 100 + 1;

                for (int i = 0; i < total; i++)
                {
                    orderDal.InsertOrderDetail(table.Rows[i]);
                    if (i % temp == 0)
                        OnDownLoadProgress(total / temp, "下载细单信息");
                }

                //下载手工补货订单明细表
                table = serverDal.FindHandleSupply(batchId);
                total = table.Rows.Count;
                temp = total / 100 + 1;

                for (int i = 0; i < total; i++)
                {
                    orderDal.InsertHandleSupply(table.Rows[i]);
                    if (i % temp == 0)
                        OnDownLoadProgress(total / temp, "下载手工补货信息");
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
                            int remainquantity = orderDal.FindRemainquantity(Convert.ToInt32(packNo), row["channel_code"].ToString());
                            int sortNo = sortingDal.FindMaxSortNo();
                            sortingDal.InsertIntoSorting(sortNo + 1, remainquantity, row);
                        }
                        OnDownLoadProgress(40, "生成下单数据");
                    }
                }

                //更新批次状态（下载完成）
                serverDal.UpdateBatchStatus(batchId);


                DataTable batchInfo = serverDal.FindBatchInfoById(batchId);
                int sumQuantity = orderDal.FindSumQuantityFromMaster();
                if (batchInfo.Rows.Count > 0)
                {
                    Logger.Info(string.Format("订单下载完成。订单日期：{0}，批次：{1}，总量：{2}。", batchInfo.Rows[0]["order_date"], batchInfo.Rows[0]["batch_no"], sumQuantity));
                }

                //生成包装机数据
                PackDataView packDataView = new PackDataView();
                packDataView.ExportData();
            }
            catch (Exception ex)
            {
                string msg = string.Format("下载失败！原因：{0}。", ex.Message);
                XtraMessageBox.Show(msg);
                Logger.Error(msg + ex.StackTrace);
            }
        }
    }
}
