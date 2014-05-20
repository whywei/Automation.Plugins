using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Automation.Plugins.Sorting.Dal;

namespace Automation.Plugins.Sorting.View.Controls
{
    public partial class OrderQueryControl : DevExpress.XtraEditors.XtraUserControl
    {
        private OrderDal orderDal = new OrderDal();

        public OrderQueryControl()
        {
            InitializeComponent();
        }
    }
}
