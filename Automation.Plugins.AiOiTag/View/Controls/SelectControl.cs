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
    public partial class SelectControl : DevExpress.XtraEditors.XtraUserControl
    {
        public SelectControl()
        {
            InitializeComponent();
        }

        public string SelectResult
        {
            get
            {
                string str = Convert.ToChar(check11.Checked ? 1 : check12.Checked ? 2 : check13.Checked ? 3 : check14.Checked ? 4 : 15 + 48).ToString();
                str = str + Convert.ToChar((check21.Checked ? 1 : check22.Checked ? 2 : check23.Checked ? 3 : check24.Checked ? 4 : 15) + (check31.Checked ? 16 : check32.Checked ? 32 : check33.Checked ? 48 : check34.Checked ? 64 : 240));
                str = str + Convert.ToChar((check41.Checked ? 1 : check42.Checked ? 2 : check43.Checked ? 3 : check44.Checked ? 4 : 15) + (check51.Checked ? 16 : check52.Checked ? 32 : check53.Checked ? 48 : check54.Checked ? 64 : 240));
                return str;
            }
        }
    }
}
