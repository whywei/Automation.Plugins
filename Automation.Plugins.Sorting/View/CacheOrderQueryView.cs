using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.Sorting.View.Controls;
using System.Windows.Forms;
using System.Data;
using Automation.Plugins.Sorting.Dal;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace Automation.Plugins.Sorting.View
{
    public class CacheOrderQueryView:AbstractView
    {
        private GridControl gridControl = null;
        private GridView gridView = null;

        public override void Initialize()
        {
            DefaultSortOrder = 203;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kCacheOrderQuery";
            this.Caption = "缓存订单";
            this.InnerControl = new CacheOrderQueryControl();
            this.Dock = DockStyle.Fill;
            gridControl = ((CacheOrderQueryControl)this.InnerControl).gridCacheOrder;
            gridView = ((CacheOrderQueryControl)this.InnerControl).viewCacheOrder;
        }

        public void Refresh(string channelGroup, string position, string itemName)
        {
            object cacheObj = Ops.Read(Global.ServiceName_SortingOPC, itemName);
            int sortNoStart, frontQuantity, laterQuantity, sumQuantity;
            DataTable table = null;
            if (cacheObj is Array)
            {
                Array arraycache = (Array)cacheObj;
                if (arraycache.Length == 3)
                {
                    sortNoStart =Convert.ToInt32( arraycache.GetValue(0));
                    frontQuantity = Convert.ToInt32(arraycache.GetValue(2));
                    laterQuantity = Convert.ToInt32(arraycache.GetValue(1));
                    sumQuantity = frontQuantity + laterQuantity;
                    OrderDal orderDal = new OrderDal();
                    DataTable orderTable = orderDal.FindDetailForCacheOrderQuery(channelGroup, sortNoStart);
                    table = orderTable.Clone();
                    if (position == "front")
                    {
                        if (orderTable.Rows.Count != 0)
                        {
                            int tempQuantity = 0;
                            foreach (DataRow orderDetailRow in orderTable.Rows)
                            {
                                int orderQuantity = Convert.ToInt32(orderDetailRow["QUANTITY"]);
                                tempQuantity = tempQuantity + orderQuantity;

                                if (tempQuantity >= frontQuantity)
                                {
                                    orderDetailRow["QUANTITY"] = orderQuantity + frontQuantity - tempQuantity;
                                    table.ImportRow(orderDetailRow);
                                    break;
                                }
                                else
                                {
                                    table.ImportRow(orderDetailRow);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (orderTable.Rows.Count != 0)
                        {
                            int tempQuantity = 0;
                            foreach (DataRow orderDetailRow in orderTable.Rows)
                            {
                                int orderQuantity = Convert.ToInt32(orderDetailRow["QUANTITY"]);
                                if(tempQuantity+orderQuantity<=frontQuantity)
                                {
                                    tempQuantity+=orderQuantity;
                                }
                                else if(tempQuantity<=frontQuantity)
                                {
                                    if(tempQuantity+orderQuantity<=sumQuantity)
                                    {
                                        orderDetailRow["QUANTITY"] = tempQuantity + orderQuantity - frontQuantity;
                                        table.ImportRow(orderDetailRow);
                                        tempQuantity+=orderQuantity;
                                    }
                                    else
                                    {
                                        orderDetailRow["QUANTITY"]=laterQuantity;
                                        table.ImportRow(orderDetailRow);
                                        break;
                                    }
                                }
                                else if (tempQuantity > frontQuantity && tempQuantity<sumQuantity)
                                {
                                    if (tempQuantity+orderQuantity<=sumQuantity)
                                    {
                                        table.ImportRow(orderDetailRow);
                                        tempQuantity+=orderQuantity;
                                    }
                                    else
                                    {
                                        orderDetailRow["QUANTITY"] = sumQuantity-tempQuantity;
                                        table.ImportRow(orderDetailRow);
                                        break;
                                    }
                                }
                                else if (tempQuantity >= sumQuantity)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            gridControl.DataSource = table;
        }
    }
}
