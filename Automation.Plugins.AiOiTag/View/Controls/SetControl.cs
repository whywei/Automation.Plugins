using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Automation.Plugins.AiOiTag.View.Controls
{
    public partial class SetControl : DevExpress.XtraEditors.XtraUserControl
    {
        public SetControl()
        {
            InitializeComponent();
        }

        public char SelectResult
        {
            get
            {
                char str = Convert.ToChar(64 + (check11.Checked ? 0 : check12.Checked ? 16 : 48) + (check21.Checked ? 4 : check22.Checked ? 0 : 12) + (check31.Checked ? 1 : check32.Checked ? 0 : 3));
                return str;
            }
        }
    }
}
