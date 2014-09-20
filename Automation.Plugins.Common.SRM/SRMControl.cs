using DevExpress.XtraEditors;

namespace Automation.Plugins.Common.SRM
{
    public partial class SRMControl : XtraUserControl
    {
        private ISRM srm = null;
        public ISRM SRM
        {
            get
            {
                return srm;
            }
            set
            {
                srm = value;
                this.propertyGridControl1.SelectedObject = srm;
                this.propertyGridControl1.Refresh();
            }
        }

        public SRMControl()
        {
            InitializeComponent();
        }
    }
}
