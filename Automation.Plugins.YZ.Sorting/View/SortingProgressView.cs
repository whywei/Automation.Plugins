using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.YZ.Sorting.View.Controls;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.Dal;
using System.Data;
using DevExpress.XtraEditors;

namespace Automation.Plugins.YZ.Sorting.View
{
    public class SortingProgressView : AbstractView
    {
        private SortingProgressControl control = null;
        public override void Initialize()
        {
            this.DefaultSortOrder = 201;
            IsPreload = true;
        }

        public override void Activate()
        {
            this.Key = "kSortingProgressQuery";
            this.Caption = "分拣进度";
            this.InnerControl = new SortingProgressControl();
            this.Dock = DockStyle.Bottom;
            this.control = (SortingProgressControl)this.InnerControl;
            this.App.DockManager.PanelClosed += new EventHandler<DotSpatial.Controls.Docking.DockablePanelEventArgs>(DockManager_PanelClosed);
            this.App.DockManager.ActivePanelChanged += new EventHandler<DotSpatial.Controls.Docking.DockablePanelEventArgs>(DockManager_ActivePanelChanged);
        }

        private void DockManager_ActivePanelChanged(object sender, DotSpatial.Controls.Docking.DockablePanelEventArgs e)
        {
            if (e.ActivePanelKey == this.Key)
            {
                this.Focus = true;
            }
        }

        private void DockManager_PanelClosed(object sender, DotSpatial.Controls.Docking.DockablePanelEventArgs e)
        {
            if (e.ActivePanelKey == this.Key)
            {
                this.Focus = false;
            }
        }

        private delegate void RefreshSortingInfo();

        public void Refresh()
        {
            if (control.InvokeRequired)
            {
                RefreshSortingInfo refreshSortingInfo = new RefreshSortingInfo(Refresh);
                control.Invoke(refreshSortingInfo);
            }
            else
            {
                OrderDal orderDal = new OrderDal();
                DataTable totalInfo = orderDal.FindOrderInfo("all");
                DataTable completeInfo = orderDal.FindOrderInfo("");
                if (totalInfo.Rows.Count > 0 && completeInfo.Rows.Count > 0)
                {
                    //当前分拣信息
                    control.lblCompleteRoute.Text = completeInfo.Rows[0]["deliver_line_num"].ToString();
                    control.lblCompleteCustomer.Text = completeInfo.Rows[0]["customer_num"].ToString();
                    control.lblCompleteQuantity.Text = completeInfo.Rows[0]["quantity"].ToString();
                    //未分拣信息
                    control.lblRoute.Text = (Convert.ToInt32(totalInfo.Rows[0]["deliver_line_num"]) - Convert.ToInt32(completeInfo.Rows[0]["deliver_line_num"])).ToString();
                    control.lblCustomer.Text = (Convert.ToInt32(totalInfo.Rows[0]["customer_num"]) - Convert.ToInt32(completeInfo.Rows[0]["customer_num"])).ToString();
                    control.lblQuantity.Text = (Convert.ToInt32(totalInfo.Rows[0]["quantity"]) - Convert.ToInt32(completeInfo.Rows[0]["quantity"])).ToString();
                    //总
                    control.lblTotalRoute.Text = totalInfo.Rows[0]["deliver_line_num"].ToString();
                    control.lblTotalCustomer.Text = totalInfo.Rows[0]["customer_num"].ToString();
                    control.lblTotalQuantity.Text = totalInfo.Rows[0]["quantity"].ToString();
                }
            }
        }
    }
}
