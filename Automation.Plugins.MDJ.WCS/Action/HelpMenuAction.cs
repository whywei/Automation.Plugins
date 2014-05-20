using System;
using Automation.Core;
using DotSpatial.Controls.Header;
using System.Windows.Forms;
using System.Threading.Tasks;
using DevExpress.XtraSplashScreen;
using Automation.Plugins.MDJ.WCS.Properties;
using System.Diagnostics;

namespace Automation.MainPlugin.Action
{
    public class HelpMenuAction : AbstractAction
    {
        private const string Url = "位置分布图.dwg";

        public override void Initialize()
        {
            DefaultSortOrder = 1;
        }

        public override void Activate()
        {
            IHeaderControl header = App.HeaderControl;
            header.Add(new SimpleActionItem("kHelp", "位置分布图", PositionMap_Click) { SmallImage = Resources.position_16x16, LargeImage = Resources.position_32x32 });
        }

        private void PositionMap_Click(object sender, EventArgs e)
        {
            Process.Start(Url);
        }
    }
}
