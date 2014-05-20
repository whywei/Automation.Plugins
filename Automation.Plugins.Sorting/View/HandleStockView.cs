using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.Sorting.View.Controls;
using Automation.Plugins.Sorting.Dal;
using System.Data;
using DevExpress.XtraGrid;

namespace Automation.Plugins.Sorting.View
{
    public class HandleStockView:AbstractView
    {
        private ChannelDal channelDal = new ChannelDal();
        private GridControl gridControl = null;

        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kHandleStock";
            this.Caption = "补货作业";
            this.Dock = DockStyle.Fill;
            this.InnerControl = new HandleStockControl();
            gridControl = ((HandleStockControl)this.InnerControl).gridHandleStock;
        }

        public void Refresh(string channelCode)
        {
            OrderDal orderDal = new OrderDal();
            string condition = "";
            if (channelCode != "")
            {
                condition=string.Format("WHERE A.CHANNELCODE='{0}'", channelCode);
            }
            gridControl.DataSource = orderDal.FindHandSupply(condition);
        }

        public List<string> FindMixChannelToList()
        {
            return channelDal.FindMixChannelToList();
        }
    }
}
