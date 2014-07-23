﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Automation.Plugins.YZ.Sorting.Dal;
using Automation.Plugins.YZ.Sorting.View.Controls;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.Properties;
using System.Data;
using Automation.Plugins.YZ.Sorting.View.Dialog;

namespace Automation.Plugins.YZ.Sorting.View
{
   public class ChannelQueryView :AbstractView
    {
       private GridControl gridControl = null;
       GridView gridView = null;

       ChannelDal channelDal = new ChannelDal();
       OrderDal orderDal = new OrderDal();
       const string plcServiceName = "VerticalPicking";

        public override void Initialize()
        {
            this.DefaultSortOrder = 102;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kChannelQuery";
            this.Caption = "烟道查询";
            this.InnerControl = new ChannelQueryControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.refresh_32x32;

            gridControl = ((ChannelQueryControl)this.InnerControl).gridChannelQuery;
            gridView = ((ChannelQueryControl)this.InnerControl).viewChannelQuery;
            gridView.DoubleClick += new EventHandler(gridChannelQuery_DoubleClick);
        }

        public void Refresh()
        {
            ChannelDal channelDal = new ChannelDal();
            gridControl.DataSource = channelDal.FindChannel();                       
        }

        public void gridChannelQuery_DoubleClick(object sender, EventArgs e)
        {
            ChannelQueryControl cqc = new ChannelQueryControl();
            string sourceChannelCode = gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns["channel_code"]).ToString();
            DataTable channeltable = channelDal.FindChannelCode(sourceChannelCode);
            if (channeltable.Rows[0]["channel_type"].ToString() == "5") //混合烟道
            {
                return;
            }
            DataTable table = channelDal.FindChannel(sourceChannelCode, channeltable.Rows[0]["channel_type"].ToString(), Convert.ToInt32(channeltable.Rows[0]["group_no"].ToString()));
            if (table.Rows.Count != 0)
            {
                ChannelExchangeDialog channelExchangeDialog = new ChannelExchangeDialog(table);
                if (channelExchangeDialog.ShowDialog() == DialogResult.OK)
                {
                    string lookUpEditValue = channelExchangeDialog.lookUpEdit1.EditValue.ToString();
                    DataRow channelRow = channelDal.FindChannelInfo().Select(string.Format("channel_code='{0}'", lookUpEditValue))[0];
                    string targetChannelCode = lookUpEditValue;
                    orderDal.UpdateOrderDetailByChannelCode(sourceChannelCode, "000000");
                    orderDal.UpdateOrderDetailByChannelCode(targetChannelCode, sourceChannelCode);
                    orderDal.UpdateOrderDetailByChannelCode("000000", targetChannelCode);
                    channelDal.UpdateChannelByChannelCode(sourceChannelCode,
                                                      channelRow["product_code"].ToString(),
                                                      channelRow["product_name"].ToString(),
                                                      channelRow["quantity"].ToString()); //更新源数据
                    channelDal.UpdateChannelByChannelCode(lookUpEditValue,
                        gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns["product_code"]).ToString(),
                        gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns["product_name"]).ToString(),
                        gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns["quantity"]).ToString());//更新目标数据
                    int[] data = new int[3];
                    data[0] = channelDal.FindChannelAddressByChannelCode(sourceChannelCode);
                    data[1] = channelDal.FindChannelAddressByChannelCode(targetChannelCode);
                    data[2] = 1;
                    if (Convert.ToInt32(channeltable.Rows[0]["group_no"].ToString()) == 1)
                    {
                        Ops.Write(plcServiceName, "Channel_Interchange_Information_A", data);
                    }
                    else
                    {
                        Ops.Write(plcServiceName, "Channel_Interchange_Information_B", data);
                    }
                    //THOK.MCP.Logger.Info(string.Format("{0}号烟道与{1}号烟道交换！", data[0], data[1]));
                    MessageBox.Show(string.Format("{0}号烟道与{1}号烟道交换！", data[0], data[1]));
                }
            }
        }
    }
}
