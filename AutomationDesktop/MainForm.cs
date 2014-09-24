using DevExpress.XtraBars;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using DotSpatial.Controls.Docking;
using System;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors;
using System.Reflection;
using DotSpatial.Controls;
using Automation.Base;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace AutomationDesktop
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        [Export("Shell", typeof(ContainerControl))]
        private static ContainerControl Shell;

        public MainForm()
        {
            try
            {
                this.InitializeComponent();

                LoadCustomBranding(Properties.Settings.Default);

                this.Height = Screen.PrimaryScreen.Bounds.Height;
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.WindowState = FormWindowState.Maximized;
                appName = Process.GetCurrentProcess().ProcessName;
                if (Process.GetProcessesByName(appName).Length == 1)
                {
                    Shell = this;
                    AppManager.UseBaseDirectoryForExtensionsDirectory = true;
                    this.appManager.ExtensionsActivating += (object sender, EventArgs e) =>
                    {
                        this.appManager.CompositionAutomationExtension();
                    };

                    this.appManager.LoadExtensions();
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("MainForm 构造方法执行出错，原因详情：{0}{1}", ex.Message, ex.StackTrace);
                Logger.Error(msg);
                XtraMessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomBranding(Properties.Settings settings)
        {
            if (!String.IsNullOrWhiteSpace(settings.CustomAppIconPath) &&
                System.IO.File.Exists(settings.CustomAppIconPath))
            {
                System.Drawing.Icon ico = new System.Drawing.Icon(settings.CustomAppIconPath);
                this.Icon = ico;
            }

            if (!String.IsNullOrWhiteSpace(settings.CustomMainFormTitle))
            {
                this.Text = settings.CustomMainFormTitle;
            }
        }

        #region  程序运行控制只允许一个进程运行。

        [DllImport("user32")]
        public static extern long ShowWindow(long hwnd, long nCmdShow);
        [DllImport("user32")]
        public static extern long SetForegroundWindow(long hwnd);
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd,uint Msg,uint wParam,uint lParam);

        private string appName = "AutomationDesktop";

        private void MainForm_Load(object sender, EventArgs e)
        {
            appName = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcessesByName(appName).Length > 1)
            {
                foreach (Process process in Process.GetProcessesByName(appName))
                {                    
                    if (this.Handle != ReadHandle())
                    {
                        SendMessage(ReadHandle(), WindowConstParam.WM_SYSCOMMAND, WindowConstParam.SC_MAXIMIZE, 0);
                        SetForegroundWindow((long)ReadHandle());
                    }
                }
                System.Windows.Forms.Application.Exit();
                return;
            }
            else
            {
                WriteHandle();
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void WriteHandle()
        {
            RegistryKey appKey = Registry.CurrentUser.CreateSubKey(appName);
            using (RegistryKey mainFormKey = appKey.CreateSubKey("MainForm"))
            {
                mainFormKey.SetValue("Handle", this.Handle);
            }
        }

        private IntPtr ReadHandle()
        {
            RegistryKey appKey = Registry.CurrentUser.OpenSubKey(appName);
            using (RegistryKey mainFormKey = appKey.OpenSubKey("MainForm"))
            {
                return (IntPtr)Convert.ToInt32(mainFormKey.GetValue("Handle").ToString());
            }
        }

        #endregion
    }
}