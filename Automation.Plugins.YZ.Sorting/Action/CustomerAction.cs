using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Sorting.Properties;
using Automation.Plugins.YZ.Sorting.View;
using DevExpress.XtraEditors;
using Automation.Plugins.YZ.Sorting.Dal;
using System.Windows.Forms;

namespace Automation.Plugins.YZ.Sorting.Action
{
    public class CustomerAction : AbstractAction
    {
        private const string rootKey = "kCustomerQuery";
        private TextEntryActionItem _txtQuantity = new TextEntryActionItem();
        private DropDownActionItem dropItem = null;
        CustomerDal customerDal = new CustomerDal();

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            IHeaderControl header = App.HeaderControl;

            this.Add(new RootItem(rootKey, "订单查询") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", CustomerQueryRefresh_Click) { ToolTipText = "刷新订单查询", GroupCaption = "订单查询", LargeImage = Resources.refresh_32x32 });

            dropItem = new DropDownActionItem { RootKey = rootKey, GroupCaption = "查询", Width = 170 };
            dropItem.Caption = "卷烟名称：";
            dropItem.Items.AddRange(customerDal.GetProduct());
            dropItem.SelectedValueChanged += new EventHandler<SelectedValueChangedEventArgs>(dropItem_SelectedValueChanged);
            this.Add(dropItem);
            dropItem.DisplayText = "请选择卷烟名称";

            _txtQuantity.Width = 170;
            _txtQuantity.GroupCaption = "查询";
            _txtQuantity.RootKey = rootKey;
            _txtQuantity.Caption = "  数  量：";
            _txtQuantity.Enabled = true;
            this.Add(_txtQuantity);
            _txtQuantity.Text = "";

            this.Add(new SimpleActionItem(rootKey, "查询", Select_Click) { GroupCaption = "查询", SmallImage = Resources.Sorting_Query_16, LargeImage = Resources.Sorting_Query_16 });
            base.Activate();
        }

        private void CustomerQueryRefresh_Click(object sender, EventArgs e)
        {
            (View as CustomerQueryView).Refresh(null);
        }

        private void Select_Click(object sender, EventArgs e)
        {
            if (this.dropItem.SelectedItem==null)
            {
                XtraMessageBox.Show("请选择要查询的卷烟名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);//弹出提示框
                //(View as CustomerQueryView).Refresh(null);//刷新
            } 
            else
            {
                string product_name = dropItem.SelectedItem.ToString();
                string quantity = _txtQuantity.Text;
                bool judge = false;
                for (int i = 0; i < quantity.Length; i++)
                {
                    if (Char.IsDigit(quantity[i]))
                        judge = true;
                }
                if(judge)
                    (View as CustomerQueryView).Select(product_name, quantity);
                else if(quantity=="")
                    (View as CustomerQueryView).Select(product_name, quantity);
                else
                    XtraMessageBox.Show("请输入正确的卷烟数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);//弹出提示框
            }
        }

        private void dropItem_SelectedValueChanged(object sender, SelectedValueChangedEventArgs e)
        {
            //(View as CustomerQueryView).Refresh(e.SelectedItem.ToString());
        }
    }
}