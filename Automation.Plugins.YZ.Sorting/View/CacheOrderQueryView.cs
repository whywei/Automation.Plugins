using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.Properties;
using Automation.Plugins.YZ.Sorting.View.Controls;

namespace Automation.Plugins.YZ.Sorting.View
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
            this.Caption = "缓存订单查询";
            this.InnerControl = new OrderQueryControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.refresh_32x32;

            gridControl = ((OrderQueryControl)this.InnerControl).gridMaster;
        }

        public void Refresh()
        {
           // ChannelDal channelDal = new ChannelDal();
          //  gridControl.DataSource = channelDal.FindSortChannel();
        }
    }
}