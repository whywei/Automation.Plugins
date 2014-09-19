using DevExpress.XtraEditors;

namespace AAutomation.Plugins.Common.Forklift
{
    public partial class ForkliftControl : XtraUserControl
    {
        private IForklift forklift = null;
        public IForklift Forklift
        {
            get
            {
                return forklift;
            }
            set
            {
                forklift = value;
                this.propertyGridControl1.SelectedObject = forklift;
                this.propertyGridControl1.Refresh();
            }
        }

        public ForkliftControl()
        {
            InitializeComponent();
        }
    }
}
