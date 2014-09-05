using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core.Option;
using Automation.Plugins.Share.Sorting.Properties;
using Automation.Plugins.Share.Sorting.Options.Controls;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Automation.Plugins.Share.Sorting.Options
{
    public class SystemParameterOption:AbstractOption
    {
        private Control control = null;
        private TextEdit txtPackDataPath = null;
        private TextEdit txtSortingLineCode = null;
        private TextEdit txtSupplyPosition = null;
        private TextEdit txtHttpUrl = null;
        public override void Initialize()
        {
            base.Initialize();
            this.NodeName = "YZSystemParameterOption";
            this.Caption = "运用程序参数";
            this.Order = 3;
            this.ParentNodeName = "YZSortParameterOption";
            this.NodeImage = Resources.ParameterOption_16;
            this.InnerControl = new SystemParameterPanel();
            this.control = this.InnerControl;
            txtPackDataPath = ((SystemParameterPanel)this.control).txtPackDataPath;
            txtPackDataPath.EditValueChanged += new EventHandler(txtPackDataPath_EditValueChanged);
            txtSortingLineCode = ((SystemParameterPanel)this.control).txtSortingLineCode;
            txtSortingLineCode.EditValueChanged += new EventHandler(txtSortingLineCode_EditValueChanged);
            txtSupplyPosition = ((SystemParameterPanel)this.control).txtSupplyPosition;
            txtSupplyPosition.EditValueChanged+=new EventHandler(txtSupplyPosition_EditValueChanged);
            txtHttpUrl = ((SystemParameterPanel)this.control).txtHttpUrl;
            txtHttpUrl.EditValueChanged+=new EventHandler(txtHttpUrl_EditValueChanged);
        }

        public override void OnSelected()
        {
            txtSortingLineCode.Text = Settings.Default.Sorting_Line_Code;
            txtPackDataPath.Text = Settings.Default.PackDataPath;
            txtSupplyPosition.Text = Settings.Default.Supply_Cache_Position;
            txtHttpUrl.Text = Settings.Default.HttpUrl;
        }

        private void txtPackDataPath_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPackDataPath.Text.Trim().Length <= 0)
            {
                XtraMessageBox.Show("包装机数据地址不能为空！", "提示");
                return;
            }
            Settings.Default.PackDataPath = txtPackDataPath.Text.Trim();

        }

        private void txtSortingLineCode_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSortingLineCode.Text.Trim().Length <= 0)
            {
                XtraMessageBox.Show("分拣线编码不能为空！", "提示");
                return;
            }
            Settings.Default.Sorting_Line_Code = txtSortingLineCode.Text.Trim();
        }

        private void txtSupplyPosition_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSupplyPosition.Text.Trim().Length <= 0)
            {
                XtraMessageBox.Show("补货缓存位置编号不能为空！", "提示");
                return;
            }
            Settings.Default.Supply_Cache_Position = txtSupplyPosition.Text.Trim();
        }

        private void txtHttpUrl_EditValueChanged(object sender, EventArgs e)
        {
            if (txtHttpUrl.Text.Trim().Length <= 0)
            {
                XtraMessageBox.Show("HttpUrl不能为空！", "提示");
                return;
            }
            Settings.Default.HttpUrl = txtHttpUrl.Text.Trim();
        }
    }
}
