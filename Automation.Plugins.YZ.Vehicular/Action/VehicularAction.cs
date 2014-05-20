using System;
using Automation.Core;
using DotSpatial.Controls.Header;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Threading;
using Automation.Plugins.YZ.Vehicular.Properties;

namespace Automation.Plugins.YZ.Vehicular.Action
{
    public class VehicularAction : AbstractAction
    {
        private const string rootKey = "kVehicular";

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
        }

        public override void Activate()
        {
            IHeaderControl header = App.HeaderControl;
            header.Add(new SimpleActionItem(rootKey, "开始作业", (sender, e) => { }) { SmallImage = Resources.cmd_test_16x16, LargeImage = Resources.cmd_test_32x32 });
            header.Add(new SimpleActionItem(rootKey, "停止作业", (sender, e) => { }) { SmallImage = Resources.cmd_test_16x16, LargeImage = Resources.cmd_test_32x32 });
        }
    }
}
