
namespace Automation.Plugins.Common.Forklift.View.Controls
{
    public partial class ForkliftPanel : DevExpress.XtraEditors.XtraUserControl
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
                this.propertyGridControl1.SelectedObject = forklift.CurrentTask;
                this.propertyGridControl1.Refresh();

                forkliftControl1.propertyGridControl1.SelectedObject = forklift;
                forkliftControl1.propertyGridControl1.Refresh();
            }
        }

        public ForkliftPanel()
        {
            InitializeComponent();
        }
    }
}
