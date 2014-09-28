using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.Share.Sorting.View.Controls;
using DevExpress.XtraGrid;
using Automation.Plugins.Share.Sorting.Dal;
using System.Data;
using Automation.Plugins.Share.Sorting.View.Dialog;
using System.Reflection;
using System.Drawing;
using DevExpress.XtraEditors;
using System.IO;

namespace Automation.Plugins.Share.Sorting.View
{
    public class PackDataView : AbstractView
    {
        private GridControl gridControl = null;

        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kPackDataQuery";
            this.Caption = "包装数据";
            this.InnerControl = new PackDataControl();
            this.gridControl = ((PackDataControl)this.InnerControl).gridPackData;
            this.Dock = DockStyle.Fill;
        }

        public void Refresh()
        {
            ExportPackDal exportPackDal = new ExportPackDal();
            this.gridControl.DataSource = exportPackDal.FindExportPack();
        }

        public void GeneratePackData()
        {
            OrderDal orderDal = new OrderDal();
            ExportPackDal exportPackDal = new ExportPackDal();
            DataTable exportNos = orderDal.FindExporNoFromMaster();
            GeneratePackDataDialog dialog = new GeneratePackDataDialog(exportNos);
            Assembly assembly = Assembly.GetEntryAssembly();
            dialog.Icon = Icon.ExtractAssociatedIcon(assembly.Location);
            if (dialog.ShowDialog() == DialogResult.OK)
            { 
                string condition=dialog.Condition;
                if(condition=="")
                {
                    XtraMessageBox.Show("请输入相应的条件！","提示");
                    return ;
                }
                DataTable packData = orderDal.FindPackData(condition);
                foreach (DataRow row in packData.Rows)
                {
                    exportPackDal.InsertIntoExportPack(row);
                }
                Refresh();
                Logger.Info("手动生成包装机数据成功！");
            }
        }

        public void ExportData()
        {
            OrderDal orderDal = new OrderDal();
            ExportPackDal exportPackDal = new ExportPackDal();
            //查找所有的包装机
            DataTable exportNos = orderDal.FindExporNoFromMaster();
            foreach (DataRow exportNo in exportNos.Rows)
            {
                string condition = string.Format("WHERE export_no='{0}'", exportNo["export_no"]);
                DataTable packData = orderDal.FindPackData(condition);
                string path = Properties.Settings.Default.PackDataPath;
                string fileName = exportNo["order_date"] + " [" + exportNo["batch_no"]+"-" + (exportNo["export_no"].ToString() == "0" ? "All" : (exportNo["export_no"].ToString() == "1" ? "ONE" : "TWO")) + "].txt";
                //判断文件路径是否存在，不存在则创建
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);
                FileStream file = new FileStream(path + fileName, FileMode.Create);
                StreamWriter writer = new StreamWriter(file, Encoding.Default);
                string str = "";
                foreach (DataRow row in packData.Rows)
                {
                    str = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}"
                        , row["id"], row["pack_no"], row["customer_deliver_order"], row["customer_code"], row["customer_name"], row["address"], row["product_code"]
                        , row["product_name"], row["quantity"], row["bag_quantity"], row["total_quantity"], row["deliver_line_code"], row["deliver_line_name"]
                        , row["order_date"], row["line_code"]);
                    writer.WriteLine(str);
                    writer.Flush();
                }
            }
            Logger.Info("包装机数据导出成功！");
        }

        public void Print()
        {
            PrintSettingView controller = new PrintSettingView(this.gridControl);
            controller.PrintHeader = "包装机数据信息";
            controller.Preview();
        }
    }
}
