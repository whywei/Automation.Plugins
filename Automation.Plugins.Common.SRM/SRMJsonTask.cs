
namespace Automation.Plugins.Common.SRM
{
    public class SRMJsonTask
    {
        public int ID { get; set; }
        public string TaskType { get; set; }

        public string OrderID { get; set; }
        public string OrderType { get; set; }
        public int AllotID { get; set; }

        public string ProductName { get; set; }
        public string OriginCellName { get; set; }
        public string TargetCellName { get; set; }
        public int PiecesQutity { get; set; }
        public int BarQutity { get; set; }

        public string OriginCellCode { get; set; }
        public string TargetCellCode { get; set; }
        public string OriginStorageCode { get; set; }
        public string TargetStorageCode { get; set; }

        public int Quantity { get; set; }
        public int TaskQuantity { get; set; }

        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int TravelPos1 { get; set; }
        public int LiftPos1 { get; set; }
        public int TravelPos2 { get; set; }
        public int LiftPos2 { get; set; }
        public int RealLiftPos2 { get; set; }

        public string CurrentPositionName { get; set; }
        public string CurrentPositionType { get; set; }
        public int CurrentPositionExtension { get; set; }

        public string NextPositionName { get; set; }
        public string NextPositionType { get; set; }
        public int NextPositionExtension { get; set; }

        public string NextTwoPositionName { get; set; }

        public string EndPositionName { get; set; }
        public string EndPositionType { get; set; }

        public bool HasGetRequest { get; set; }
        public bool HasPutRequest { get; set; }
        public bool GetFinish { get; set; }
        public bool PutFinish { get; set; }

        public string Barcode { get; set; }
        public bool IsSent { get; set; }

        public override string ToString()
        {
            return string.Format("任务号:{0} 位置1[{1}]:[{2},{3},{4}] 位置2[{5}]:[{6},{7},{8},{9}] 取货完成:[{10}] 放货完成:[{11}]", ID, CurrentPositionName, TravelPos1, LiftPos1, CurrentPositionExtension + 1, NextPositionName, TravelPos2, LiftPos2, RealLiftPos2, NextPositionExtension + 2, GetFinish, PutFinish);
        }

        public SRMTask ToSRMTask()
        {
            return new SRMTask()
            { 
                ID = this.ID,
                TaskType = this.TaskType,

                OrderID = this.OrderID,
                OrderType = this.OrderType,
                AllotID = this.AllotID,

                ProductName = this.ProductName,
                OriginCellName = this.OriginCellName,
                TargetCellName = this.TargetCellName,
                PiecesQutity = this.PiecesQutity,
                BarQutity = this.BarQutity,

                OriginCellCode = this.OriginCellCode,
                TargetCellCode = this.TargetCellCode,
                OriginStorageCode = this.OriginStorageCode,
                TargetStorageCode = this.TargetStorageCode,

                Quantity = this.Quantity,
                TaskQuantity = this.TaskQuantity,

                Length = this.Length,
                Width = this.Width,
                Height = this.Height,

                TravelPos1 = this.TravelPos1,
                LiftPos1 = this.LiftPos1,
                TravelPos2 = this.TravelPos2,
                LiftPos2 = this.LiftPos2,
                RealLiftPos2 = this.RealLiftPos2,

                CurrentPositionName = this.CurrentPositionName,
                CurrentPositionType = this.CurrentPositionType,
                CurrentPositionExtension = this.CurrentPositionExtension,

                NextPositionName = this.NextPositionName,
                NextPositionType = this.NextPositionType,
                NextPositionExtension = this.NextPositionExtension,

                NextTwoPositionName = this.NextTwoPositionName,

                EndPositionName = this.EndPositionName,
                EndPositionType = this.EndPositionType,

                HasGetRequest = this.HasGetRequest,
                HasPutRequest = this.HasPutRequest,
                GetFinish = this.GetFinish,
                PutFinish = this.PutFinish,

                Barcode = this.Barcode,
                IsSent = this.IsSent
            };
        }
    }
}
