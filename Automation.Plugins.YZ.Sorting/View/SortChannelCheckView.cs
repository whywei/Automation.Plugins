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

namespace Automation.Plugins.YZ.Sorting.View
{
   public class SortChannelCheckView :AbstractView
    {
        private GridControl gridMasterControl = null;
        private GridView gridMasterView = null;
        private ChannelAllotDal channelallotDal = new ChannelAllotDal();
        public override void Initialize()
        {
            this.DefaultSortOrder = 102;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "yzchannelallotQuery";
            this.Caption = "烟道盘点";
            this.InnerControl = new ChannelAllotQueryControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.refresh_32x32;

            gridMasterControl = ((ChannelAllotQueryControl)this.InnerControl).gridControl1;
            gridMasterView = ((ChannelAllotQueryControl)this.InnerControl).gridView1;
        }
       

        public void Refresh()
        {
            gridMasterControl.DataSource = channelallotDal.FindMaster();                       
        }
    }
}
