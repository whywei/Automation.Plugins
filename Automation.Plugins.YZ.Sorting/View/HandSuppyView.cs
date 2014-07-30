using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.View.Controls;
using DevExpress.XtraGrid;
using Automation.Plugins.YZ.Sorting.Dal;
using Automation.Plugins.YZ.Sorting.Properties;
using DevExpress.XtraGrid.Views.Grid;

namespace Automation.Plugins.YZ.Sorting.View
{
    public class HandSuppyView : AbstractView
    {
        private GridControl gridControl = null;
        private GridView gridView = null;

        private HandSupplyDal handSupplyDal = new HandSupplyDal();

        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kHandSuppyQuery";
            this.Caption = "手工补货";
            this.InnerControl = new HandSuppyControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.refresh_32x32;

            gridControl = ((HandSuppyControl)this.InnerControl).gridControl1;
            gridView = ((HandSuppyControl)this.InnerControl).gridView1;
            
        }

        public void Refresh(string channelName)
        {
            gridControl.DataSource = handSupplyDal.GetHandSupply(channelName);
        }

        public void Print()
        {
            PrintSettingView controller = new PrintSettingView(this.gridControl);
            controller.PrintHeader = "手工补货信息";
            controller.Preview();
        }
    }
}
