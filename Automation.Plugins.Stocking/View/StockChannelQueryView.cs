using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.Stocking.View.Controls;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using Automation.Plugins.Stocking.Dal;
using DotSpatial.Controls.Docking;
using System.ComponentModel.Composition;

namespace Automation.Plugins.Stocking.View
{
    public class StockChannelQueryView : AbstractView
    {
        private GridControl gridControl = null;
        public override void Initialize()
        {
            DefaultSortOrder = 301;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kStockChannelQuery";
            this.InnerControl = new StockChannelQueryControl();
            this.Dock = DockStyle.Fill;
            this.Caption = "补货烟道";
            gridControl = ((StockChannelQueryControl)this.InnerControl).gridStockChannel;
        }

        public void Refresh()
        {
            StateManagerDal dal = new StateManagerDal();
            ChannelDal channelDal = new ChannelDal();
            string rowIndex = dal.FindScannerIndexNoByStateCode("01")["ROW_INDEX"].ToString();
            gridControl.DataSource = channelDal.FindScokChannel(rowIndex);
        }
    }
}
