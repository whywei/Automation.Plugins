using System;
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

namespace Automation.Plugins.YZ.Sorting.View
{
   public class ChannelQueryView :AbstractView
    {
       private GridControl gridControl = null;
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
        }

        public void Refresh()
        {
            ChannelDal channelDal = new ChannelDal();
            gridControl.DataSource = channelDal.FindSortChannel();                       
        }
    }
}
