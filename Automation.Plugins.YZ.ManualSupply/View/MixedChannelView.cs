using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Core;
using Automation.Plugins.YZ.ManualSupply.View.Controls;
using Automation.Plugins.YZ.ManualSupply;
using Automation.Plugins.YZ.ManualSupply.Dal;
using Automation.Plugins.YZ.ManualSupply.Properties;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Automation.Plugins.YZ.ManualSupply.View.Dialogs;
using System.Reflection;
using System.Drawing;

namespace Automation.Plugins.YZ.ManualSupply.View
{
    public class MixedChannelView : AbstractView
    {
        private GridControl gridControl = null;
        private GridView gridView = null;

        private MixedChannelDal mixedChannelDal = new MixedChannelDal();
        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kMixedChannel";
            this.Caption = "混合烟道";
            this.InnerControl = new MixedChannelControl();
            this.Dock = DockStyle.Fill;

            gridControl = ((MixedChannelControl)this.InnerControl).gridControl1;
            gridView = ((MixedChannelControl)this.InnerControl).gridView1;
        }

        public void Refresh()
        {
            gridControl.DataSource = null;
            MixedChannelDal mixedChannel = new MixedChannelDal();
            var table = mixedChannel.FindMixedChannel();
            if (table.Rows.Count > 0)
            {
                MixedChannelDialog mixedChannelDialog = new MixedChannelDialog(table);
                Assembly assembly = Assembly.GetEntryAssembly();
                mixedChannelDialog.Icon = Icon.ExtractAssociatedIcon(assembly.Location);
                if (mixedChannelDialog.ShowDialog() == DialogResult.OK)
                {
                    if (mixedChannelDialog.SelectedChannelCode =="null")
                    {
                        MixedChannelDal channel = new MixedChannelDal();
                        gridControl.DataSource = mixedChannelDal.GetAllMixedChannel(); 
                    }
                    else
                    {
                        MixedChannelDal channel = new MixedChannelDal();
                        gridControl.DataSource = mixedChannelDal.GetMixedChannel(mixedChannelDialog.SelectedChannelCode);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("当前没有可查询的烟道！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Print()
        {
            PrintUtil controller = new PrintUtil(this.gridControl);
            controller.PrintHeader = "混合烟道";
            controller.Preview();
        }
    }
}
