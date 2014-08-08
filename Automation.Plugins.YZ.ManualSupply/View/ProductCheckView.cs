using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Core;
using Automation.Plugins.YZ.ManualSupply;
using Automation.Plugins.YZ.ManualSupply.Dal;
using Automation.Plugins.YZ.ManualSupply.Properties;
using Automation.Plugins.YZ.ManualSupply.View.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Automation.Plugins.YZ.ManualSupply.View
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

        public void Refresh(string product_name)
        {
            gridControl.DataSource = productCheckDal.GetProductCheck(product_name); 
        }

        public void Print()
        {
            PrintUtil controller = new PrintUtil(this.gridControl);
            controller.PrintHeader = "卷烟查询";
            controller.Preview();
        }
    }
}
