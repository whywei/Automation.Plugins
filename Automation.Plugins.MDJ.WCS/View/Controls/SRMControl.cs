using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Plugins.MDJ.WCS.Device;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;

namespace Automation.Plugins.MDJ.WCS.View.Controls
{
    public partial class SRMControl : XtraUserControl
    {
        private SRM srm = null;
        public SRM SRM
        {
            get
            { 
                return srm;
            }
            set
            {
                srm = value;
                if (srm != null && this.propertyGridControl1.SelectedObject == null)
                {
                    this.propertyGridControl1.SelectedObject = srm;
                }
                this.propertyGridControl1.Refresh();
            }        
        }

        public SRMControl()
        {
            InitializeComponent();
        }
    }
}
