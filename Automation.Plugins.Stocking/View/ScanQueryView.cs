using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.Stocking.View.Controls;
using Automation.Plugins.Stocking.Properties;
using System.Windows.Forms;
using Automation.Plugins.Stocking.Dal;
using System.Data;
using DevExpress.XtraGrid;

namespace Automation.Plugins.Stocking.View
{
    public class ScanQueryView:AbstractView
    {
        private GridControl gridControl = null;

        public override void Initialize()
        {
            DefaultSortOrder = 300;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kScanQuery";
            this.InnerControl = new ScanQueryControl();
            this.SmallImage = Resources.ScanQuery_16;
            this.Dock = DockStyle.Fill;
            this.Caption = "扫码状态";
            gridControl = ((ScanQueryControl)this.InnerControl).gridScanQuery;
        }

        public void Refresh(string index)
        {
            StateManagerDal stateManagerDal = new StateManagerDal();
            DataRow rowIndex = stateManagerDal.FindScannerIndexNoByStateCode(index);
            gridControl.DataSource = stateManagerDal.FindScannerStateByIndexNo(rowIndex["ROW_INDEX"].ToString(), rowIndex["VIEWNAME"].ToString());
        }

        public List<string> FindScannerListTable()
        {
            StateManagerDal stateManagerDal = new StateManagerDal();
            return stateManagerDal.FindScannerListTable();
        }
    }
}
