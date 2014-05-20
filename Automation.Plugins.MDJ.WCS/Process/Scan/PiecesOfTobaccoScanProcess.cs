using System;
using System.Collections.Generic;
using System.Linq;
using Automation.Core;
using Automation.Plugins.MDJ.WCS.Dal;
using Automation.MainPlugin.View;

namespace Automation.Plugins.MDJ.WCS.Process.Scan
{
    public class PiecesOfTobaccoScanProcess : AbstractProcess
    {
        private const string memoryServiceName = "MemoryPermanentSingleDataService";
        private const string memoryItemName = "CigaretteScanInfoStack";

        private const string scanServiceName = "Scanner01";
        private const string scanItemName = "01";

        private const string plcServiceName = "THOKPLC";
        private const string O_Stockin_Scan_Alarm = "O_Stockin_Scan_Alarm";

        public IDictionary<string, CigaretteScanInfo> CigaretteScanInfoStack
        {
            get
            {
                return ScanManagerView.cigaretteScanInfoStack;
            }
            set
            {
                ScanManagerView.cigaretteScanInfoStack = value;
            }
        }

        public override void Initialize()
        {
            Description = "件烟扫码";
            base.Initialize();
        }

        public override void Execute()
        {
            try
            {
                if (!ScanManagerView.InitCigaretteScanInfoStack()) return;

                object state = AutomationContext.Read(scanServiceName, scanItemName);
                if (state == null) return;

                string barcode = state.ToString();

                if (barcode == "NOREAD")
                {
                    string text = scanItemName + "号条码扫描器处理失败！详情：NOREAD！";
                    Logger.Error(text);
                    AutomationContext.Write(plcServiceName, O_Stockin_Scan_Alarm, 1);
                    return;
                }

                if (barcode.Length == 32)
                {
                    barcode = barcode.Substring(2, 6);
                }

                if (barcode.Length != 6)
                {
                    string text = scanItemName + "号条码扫描器处理失败！详情：条码格式不正确！【" + barcode + "】";
                    Logger.Error(text);
                    AutomationContext.Write(plcServiceName, O_Stockin_Scan_Alarm, 1);
                    return;
                }

                Logger.Info(barcode);

                var info = CigaretteScanInfoStack.Values.Where(c => c.State == "3");

                if (info.Count() == 0)
                {
                    info = CigaretteScanInfoStack.Values.Where(c => c.State == "2")
                                                                                        .OrderBy(c => c.Index);
                    var item = info.FirstOrDefault();
                    if (item != null && item.Quantity - item.ScanQuantity >= 1 && item.Barcode == barcode)
                    {
                        item.ScanQuantity++;
                        item.State = "3";
                        if (item.Quantity == item.ScanQuantity)
                        {
                            item.Index = 0;
                            item.State = "4";
                            lock (CigaretteScanInfoStack)
                            {
                                CigaretteScanInfoStack.Remove(item.ProductCode);
                            }                            
                        }
                        AutomationContext.Write(memoryServiceName, memoryItemName, CigaretteScanInfoStack);
                        AutomationContext.Write(plcServiceName, O_Stockin_Scan_Alarm, 0);
                    }
                    else
                    {
                        string text = scanItemName + "号条码扫描器处理失败！详情：当前品牌扫码任务不存在或未轮到当前品牌扫码！";
                        Logger.Error(text);
                        AutomationContext.Write(plcServiceName, O_Stockin_Scan_Alarm, 1);
                        return;
                    }
                }
                else if (info.Count() == 1)
                {
                    var item = info.Single();
                    if (item.Quantity - item.ScanQuantity >= 1
                        && item.Barcode == barcode)
                    {
                        item.ScanQuantity++;
                        item.State = "3";
                        if (item.Quantity == item.ScanQuantity)
                        {
                            item.Index = 0;
                            item.State = "4";
                            lock (CigaretteScanInfoStack)
                            {
                                CigaretteScanInfoStack.Remove(item.ProductCode);
                            }   
                        }
                        AutomationContext.Write(memoryServiceName, memoryItemName, CigaretteScanInfoStack);
                        AutomationContext.Write(plcServiceName, O_Stockin_Scan_Alarm, 0);
                    }
                    else
                    {
                        string text = scanItemName + "号条码扫描器处理失败！详情：当前品牌扫码任务不存在或未轮到当前品牌扫码！";
                        Logger.Error(text);
                        AutomationContext.Write(plcServiceName, O_Stockin_Scan_Alarm, 1);
                        return;
                    }
                }
                else if (info.Count() > 1)
                {
                    string text = scanItemName + "号条码扫描器处理失败！详情：当前只充许一个品牌入库扫码！";
                    Logger.Error(text);
                    AutomationContext.Write(plcServiceName, O_Stockin_Scan_Alarm, 1);
                    return;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("PiecesOfTobaccoScanProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}
