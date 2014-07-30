using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Automation.Plugins.YZ.Sorting.Dal;
using Automation.Plugins.YZ.Sorting.Action;
using System.ComponentModel.Composition;

namespace Automation.Plugins.YZ.Sorting.View.Dialog
{
    public partial class DownLoadDataDialog : DevExpress.XtraEditors.XtraForm
    {
        [Import("Shell", typeof(ContainerControl))]
        public ContainerControl Shell { get; set; }

        private DataTable table = null;
        private System.Threading.Thread thread;

        public DownLoadDataDialog(DataTable table)
        {
            InitializeComponent();
            this.table = table;
            this.Shell = this;
            List<string> listOrderDate = new List<string>();
            string item = "";
            foreach (DataRow row in table.Rows)
            {
                if (row["order_date"].ToString() != item)
                {
                    listOrderDate.Add(row["order_date"].ToString());
                    item = row["order_date"].ToString();
                }
            }
            cmbOrderDate.Properties.DataSource = listOrderDate;
        }

        private void btnDaowmLoad_Click(object sender, EventArgs e)
        {
            if (cmbOrderDate.Text == "" || cmbBatchNo.Text == "")
            {
                XtraMessageBox.Show("请选择订单日期和批次！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cmbBatchNo.Enabled = false;
            cmbOrderDate.Enabled = false;
            btnDaowmLoad.Enabled = false;
            thread= new System.Threading.Thread(new System.Threading.ThreadStart(StartDownload));
            thread.Start();
        }

        //开始下载
        public void StartDownload()
        {
            DataDownLoad downloader = new DataDownLoad();
            downloader.onDownLoadProgress += new DataDownLoad.dDownloadProgress(downloader_onDownLoadProgress);
            downloader.Start(cmbBatchNo.EditValue.ToString());
            Shell.BeginInvoke(( MethodInvoker)this.Close);
        }

        //同步更新UI
        void downloader_onDownLoadProgress(int total, string title)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DataDownLoad.dDownloadProgress(downloader_onDownLoadProgress), new object[] { total, title });
            }
            else
            {
                if (this.lblProgress.Text != title)
                {
                    this.lblProgress.Text = title;
                    this.progressBar.Position = 0;
                }
                this.progressBar.Properties.Maximum = total;
                this.progressBar.PerformStep();
                this.progressBar.Update();
            }
        }

        private void cmbOrderDate_EditValueChanged(object sender, EventArgs e)
        {
            string orderDate = ((LookUpEdit)sender).Text;
            DataRow[] rows = table.Select(string.Format("order_date='{0}'", orderDate), "batch_no");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataRow item in rows)
            {
                dic[item["id"].ToString()] = item["batch_no"].ToString();
            }
            cmbBatchNo.EditValue = "Key";
            cmbBatchNo.Properties.ValueMember = "Key";
            cmbBatchNo.Properties.DisplayMember = "Value";
            cmbBatchNo.Properties.DataSource = dic;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (thread != null)
            {
                thread.Abort();
            }
            this.Close();
        }
    }
}