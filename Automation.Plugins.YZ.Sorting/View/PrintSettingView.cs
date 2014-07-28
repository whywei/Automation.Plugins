using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DevExpress.XtraPrinting;
using System.Windows.Forms;

namespace Automation.Plugins.YZ.Sorting.View
{
    public class PrintSettingView
    {
        protected PrintingSystem ps;
        protected PrintableComponentLink link;
        private DevExpress.XtraBars.Bar bar;
        private DevExpress.XtraBars.BarSubItem barSetting;
        private DevExpress.XtraBars.BarSubItem barLandScape;
        private DevExpress.XtraBars.BarCheckItem barLandScape_Horizontal;
        private DevExpress.XtraBars.BarCheckItem barLandScape_Vertical;

        string _PrintHeader = null;
        /// <summary>
        /// 打印时的标题
        /// </summary>
        public string PrintHeader
        {
            set
            {
                _PrintHeader = value;
            }
        }

        string _PrintFooter = null;
        /// <summary>
        /// 打印时页脚
        /// </summary>
        public string PrintFooter
        {
            set
            {
                _PrintFooter = value;
            }
        }

        System.Drawing.Printing.PaperKind _paperKind;
        /// <summary>
        /// 纸型
        /// </summary>
        public System.Drawing.Printing.PaperKind PaperKind
        {
            set { _paperKind = value; }
        } 

        public PrintSettingView(IPrintable control)
        {
            if (control == null) 
                return;
            Control c = (Control)control;
            InitializeComponent();
            link = new DevExpress.XtraPrinting.PrintableComponentLink(ps);
            LoadPageSetting();
            link.Component = control;
        }

        private void InitializeComponent()
        {
            this.ps = new DevExpress.XtraPrinting.PrintingSystem();
            this.bar = ps.PreviewFormEx.PrintBarManager.Bars[2];
            this.barSetting = new DevExpress.XtraBars.BarSubItem(ps.PreviewFormEx.PrintBarManager, "设置");
            this.barLandScape = new DevExpress.XtraBars.BarSubItem();
            this.barLandScape_Horizontal = new DevExpress.XtraBars.BarCheckItem();
            this.barLandScape_Vertical = new DevExpress.XtraBars.BarCheckItem();
            bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            // 
            // barSetting
            // 
            this.barSetting.Id = 4;
            this.barSetting.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(this.barLandScape) });
            this.barSetting.Name = "barSetting";
            this.bar.AddItem(barSetting);
            // 
            // barLandScape
            // 
            this.barLandScape.Caption = "页面方向";
            this.barLandScape.Id = 1;
            this.barLandScape.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barLandScape_Horizontal),
            new DevExpress.XtraBars.LinkPersistInfo(this.barLandScape_Vertical)});
            this.barLandScape.Name = "barLandScape";
            this.barSetting.AddItem(barLandScape);
            // 
            // barLandScape_Horizontal
            // 
            this.barLandScape_Horizontal.Caption = "横向";
            this.barLandScape_Horizontal.Id = 2;
            this.barLandScape_Horizontal.Name = "barLandScape_Horizontal";
            this.barLandScape.AddItem(barLandScape_Horizontal);
            this.barLandScape_Horizontal.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLandScape_Horizontal_ItemClick);
            // 
            // barLandScape_Vertical
            // 
            this.barLandScape_Vertical.Caption = "纵向";
            this.barLandScape_Vertical.Checked = true;
            this.barLandScape_Vertical.Id = 3;
            this.barLandScape_Vertical.Name = "barLandScape_Vertical";
            this.barLandScape.AddItem(barLandScape_Vertical);
            this.barLandScape_Vertical.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLandScape_Vertical_ItemClick);
        }

        private void barLandScape_Vertical_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChangeStatus(true);
            bool result = Ops.Write(Global.memoryServiceName_PSD, "PrintLandScape", "Vertical");
            if (result)
            {
                Logger.Info("打印页面方向设置成功！");
            }
            else
            {
                Logger.Error("打印页面方向设置失败！");
            }
        }

        private void ChangeStatus(bool verticalIsCheck)
        {
            barLandScape_Vertical.Checked = verticalIsCheck;
            barLandScape_Horizontal.Checked = !verticalIsCheck;
        }

        private void barLandScape_Horizontal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChangeStatus(false);
            bool result = Ops.Write(Global.memoryServiceName_PSD, "PrintLandScape", "Horizontal");
            if (result)
            {
                Logger.Info("打印页面方向设置成功！");
            }
            else
            {
                Logger.Error("打印页面方向设置失败！");
            }
        }

        //获取页面设置信息
        public void LoadPageSetting()
        {
            string landScape = Ops.ReadSingle<string>(Global.memoryServiceName_PSD, "PrintLandScape");
            if (landScape != null && landScape != "")
            {
                if (landScape == "Horizontal")
                {
                    ps.PageSettings.Landscape = true;
                    ChangeStatus(false);
                }
                else if (landScape == "Vertical")
                {
                    ps.PageSettings.Landscape = false;
                    ChangeStatus(true);
                }
            }
            System.Drawing.Printing.Margins margins = new System.Drawing.Printing.Margins(30, 30, 30, 30);
            ps.PageSettings.Assign(margins, _paperKind, ps.PageSettings.Landscape);
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        public void Preview()
        {
            try
            {
                Cursor.Current = Cursors.AppStarting;
                if (_PrintHeader != null)
                {
                    PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;

                    //设置页眉
                    phf.Header.Content.Clear();
                    phf.Header.Content.AddRange(new string[] { "", _PrintHeader, "" });
                    phf.Header.Font = new System.Drawing.Font("宋体", 14, System.Drawing.FontStyle.Bold);
                    phf.Header.LineAlignment = BrickAlignment.Center;

                    //设置页脚
                    phf.Footer.Content.Clear();
                    phf.Footer.Content.AddRange(new string[] { "", "", _PrintFooter });
                    phf.Footer.Font = new System.Drawing.Font("宋体", 9, System.Drawing.FontStyle.Regular);
                    phf.Footer.LineAlignment = BrickAlignment.Center;

                }
                link.EnablePageDialog = false;
                link.PaperKind = ps.PageSettings.PaperKind;
                link.Margins = ps.PageSettings.Margins;
                link.Landscape = ps.PageSettings.Landscape;
                link.CreateDocument();
                ps.PreviewFormEx.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("打印预览失败！原因：{0}。{1}。", ex.Message, ex.StackTrace));
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            try
            {
                if (_PrintHeader != null)
                {
                    PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;

                    //设置页眉
                    phf.Header.Content.Clear();
                    phf.Header.Content.AddRange(new string[] { "", _PrintHeader, "" });
                    phf.Header.Font = new System.Drawing.Font("宋体", 14, System.Drawing.FontStyle.Bold);
                    phf.Header.LineAlignment = BrickAlignment.Center;

                    //设置页脚
                    phf.Footer.Content.Clear();
                    phf.Footer.Content.AddRange(new string[] { "", "", _PrintFooter });
                    phf.Footer.Font = new System.Drawing.Font("宋体", 9, System.Drawing.FontStyle.Regular);
                    phf.Footer.LineAlignment = BrickAlignment.Center;

                }
                link.PaperKind = ps.PageSettings.PaperKind;
                link.Margins = ps.PageSettings.Margins;
                link.Landscape = ps.PageSettings.Landscape;
                link.CreateDocument();
                ps.Print();
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("打印失败！原因：{0}。{1}。", ex.Message, ex.StackTrace));
            }
        }
    }
}
