using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.Share.Sorting.Properties;
using Automation.Plugins.Share.Sorting.View.Controls;
using Automation.Plugins.Share.Sorting.Dal;
using System.Data;

namespace Automation.Plugins.Share.Sorting.View
{
    public class CacheOrderQueryView : AbstractView
    {
        private GridControl gridControl = null;
        public override void Initialize()
        {
            this.DefaultSortOrder = 101;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kCacheOrderQuery";
            this.Caption = "缓存查询";
            this.InnerControl = new OrderQueryControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.refresh_32x32;

            gridControl = ((OrderQueryControl)this.InnerControl).gridSorting;
        }

        public void Refresh(string groupNo,string position)
        {
            SortingDal sortingDal = new SortingDal();
            string sortCacheOrderInformation="Sort_Cache_Order_Information_"+groupNo;
            object obj = AutomationContext.Read(Global.PLC_SERVICE_NAME, sortCacheOrderInformation);
            Array array = (Array)obj;
            if (array.Length == 3)
            {
                int sortNo = Convert.ToInt32(array.GetValue(0));
                int sumQuantity = Convert.ToInt32(array.GetValue(1));
                int frountQuantity = Convert.ToInt32(array.GetValue(2));
                DataTable cacheTable = new DataTable();
                switch (position)
                {
                    case "F":
                        cacheTable = sortingDal.FindSortingForCacheQuery(sortNo, groupNo == "A" ? 1 : 2, frountQuantity);
                        break;
                    case "L":
                        cacheTable = sortingDal.FindSortingForCacheQuery(sortNo+frountQuantity, groupNo == "A" ? 1 : 2, sumQuantity-frountQuantity);
                        break;
                }
                this.gridControl.DataSource = cacheTable;
            }
        }

        public void Refresh(string position)
        {
            SortingDal sortingDal = new SortingDal();
            string packNo="0";
            Array array = null;
            switch (position)
            {
                case "P":
                    object obj = AutomationContext.Read(Global.PLC_SERVICE_NAME, "Barcode_Printing_Order_Information");
                    array = (Array)obj;
                    if (array.Length == 2)
                    {
                        string sortNo = array.GetValue(0).ToString();
                        packNo = sortingDal.FindPackNoBySortNo(sortNo);
                    }
                    break;
                case "S":
                    obj = AutomationContext.Read(Global.PLC_SERVICE_NAME, "Swing_Order_Information");
                    array = (Array)obj;
                    if (array.Length == 2)
                    {
                        string sortNo = array.GetValue(0).ToString();
                        packNo = sortingDal.FindPackNoBySortNo(sortNo);
                    }
                    break;
            }
            this.gridControl.DataSource = sortingDal.FindSortingForCacheQuery(packNo);
        }

        public void Print()
        {
            PrintSettingView controller = new PrintSettingView(this.gridControl);
            controller.PrintHeader = "缓存订单信息";
            controller.Preview();
        }
    }
}