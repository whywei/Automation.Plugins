using System;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using System.Reflection;
using Automation.Base;
using DotSpatial.Controls;

namespace AutomationDesktop
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Assembly.GetEntryAssembly().RegisterAssemblyResolveEvent();
            AppManager.UseBaseDirectoryForExtensionsDirectory = true;
            Application.Run(new MainForm());
        }
    }
}