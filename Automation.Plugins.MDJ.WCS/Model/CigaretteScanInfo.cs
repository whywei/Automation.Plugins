using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;

namespace Automation.Plugins.MDJ.WCS.Dal
{
    [Serializable]
    public class CigaretteScanInfo
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }

        public int ProductNo { get; set; }
        public int SizeNo { get; set; }
        public int AreaNo { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int Quantity { get; set; }
        public int ScanQuantity { get; set; }
        public int Index { get; set; }
        public string State { get; set; } //0:未扫码；1：暂停扫码；2：等待扫码；3：正在扫码；4：完成扫码
        public string ZNState
        { 
            get
            {
                switch (State)
                {
                    case "0":
                        return "未扫码";
                        break;
                    case "1":
                        return "暂停扫码";
                        break;
                    case "2":
                        return "等待扫码";
                        break;
                    case "3":
                        return "正在扫码";
                        break;
                    case "4":
                        return "完成扫码";
                        break;
                    default:
                        return "状态不存在";
                        break;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("｛{0},{1},{2}｝", ProductName, Quantity, ScanQuantity);
        }
    }

    public class CigaretteScanInfoToString : AbstractConverter
    {
        public override string Name
        {
            get
            {
                return (new Dictionary<string, CigaretteScanInfo>()).GetType().Name;
            }
        }

        public override string ToString<T>(T obj)
        {
            return ((IDictionary<string, CigaretteScanInfo>)obj).ConvertToString();
        }
    }
}
