using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Core;
using Automation.Plugins.Share.ManualSupply;
using Automation.Plugins.Share.ManualSupply.Dal;
using Automation.Plugins.Share.ManualSupply.Properties;
using Automation.Plugins.Share.ManualSupply.View.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Automation.Plugins.Share.ManualSupply.View
{
    public class ProductCheckView : AbstractView
    {
        private GridControl gridControl = null;
        private GridView gridView = null;

        private ProductCheckDal productCheckDal = new ProductCheckDal();

        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kProductCheck";
            this.Caption = "卷烟查询";
            this.InnerControl = new ProductCheckControl();
            this.Dock = DockStyle.Fill;

            gridControl = ((ProductCheckControl)this.InnerControl).gridControl1;
            gridView = ((ProductCheckControl)this.InnerControl).gridView1;
        }

        public void Refresh()
        {
            gridControl.DataSource = productCheckDal.GetProductCheck(); 
        }

        public void Print()
        {
            PrintUtil controller = new PrintUtil(this.gridControl);
            controller.PrintHeader = "卷烟查询";
            controller.Preview();
        }
    }
}
