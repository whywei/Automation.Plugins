using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.View.Controls;
using DevExpress.XtraGrid;
using Automation.Plugins.YZ.Sorting.Dal;

namespace Automation.Plugins.YZ.Sorting.View
{
    public class PackDataView : AbstractView
    {
        private GridControl gridControl = null;

        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kPackDataQuery";
            this.Caption = "包装机数据";
            this.InnerControl = new PackDataControl();
            this.gridControl = ((PackDataControl)this.InnerControl).gridPackData;
            this.Dock = DockStyle.Fill;
        }

        public void Refresh()
        {
            ExportPackDal exportPackDal = new ExportPackDal();
            this.gridControl.DataSource = exportPackDal.FindExportPack();
        }
    }
}
