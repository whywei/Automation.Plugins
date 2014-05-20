using System;
using Automation.Plugins.MDJ.WCS.Model;
using DBRabbit;
using DBRabbit.Relation;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Automation.Plugins.MDJ.WCS.Rest;
using Automation.Core.Util;

namespace Automation.Plugins.MDJ.WCS.Dal
{
    [Serializable]
    class TaskDal : AbstractBaseDal
    {
        public TaskInfo GetNewTask(string proName,string srmName,int travelPos,int waitingTask,int[] waitTasks,string productCode = "")
        {
            var spa = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewSPAccesser();
            IList<SPParameter> @params = new List<SPParameter>();
            SPParameter sPParameter1 = new SPParameter("srm_name",ParameterDirection.Input, srmName);
            SPParameter sPParameter2 = new SPParameter("travelPos", ParameterDirection.Input, travelPos);
            SPParameter sPParameter3 = new SPParameter("waitingTask", ParameterDirection.Input, waitingTask);
            string strTaitingTasks = "";
            if (waitTasks != null)
            {
                strTaitingTasks = "(";
                for (int i = 0; i < waitTasks.Length; i++)
                    strTaitingTasks += string.Format("{0},0", waitTasks[i]);
                strTaitingTasks += ")";
            }
            SPParameter sPParameter4 = new SPParameter("waitingTasks", ParameterDirection.Input, strTaitingTasks);
            SPParameter sPParameter5 = new SPParameter("product_code", ParameterDirection.Input, productCode);
            @params.Add(sPParameter1);
            @params.Add(sPParameter2);
            @params.Add(sPParameter3);
            @params.Add(sPParameter4);
            @params.Add(sPParameter5);

            IDictionary<string, object> outVals = new Dictionary<string, object>();
            var set = spa.ExecuteQuery(proName, @params, out outVals);
            
            if (set.Tables.Count == 1 && set.Tables[0].Rows.Count == 1)
            {
                var row = set.Tables[0].Rows[0];
                TaskInfo taskInfo = new TaskInfo();

                taskInfo.ID = Convert.ToInt32(row["id"]);
                taskInfo.TaskType = row["task_type"].ToString();
                taskInfo.OrderID = row["order_id"].ToString();
                taskInfo.OrderType = row["order_type"].ToString();
                taskInfo.AllotID = Convert.ToInt32(row["allot_id"]);
                taskInfo.OriginCellCode = row["origin_cell_code"].ToString();
                taskInfo.TargetCellCode = row["target_cell_code"].ToString();
                taskInfo.OriginStorageCode = row["origin_storage_code"].ToString();
                taskInfo.TargetStorageCode = row["target_storage_code"].ToString();
                taskInfo.TaskQuantity = Convert.ToInt32(row["task_quantity"]);

                taskInfo.Length = Convert.ToInt32(row["length"]);
                taskInfo.Width = Convert.ToInt32(row["width"]);
                taskInfo.Height = Convert.ToInt32(row["height"]);

                taskInfo.TravelPos1 = Convert.ToInt32(row["travelPos1"]);
                taskInfo.LiftPos1 = Convert.ToInt32(row["liftPos1"]);
                taskInfo.TravelPos2 = Convert.ToInt32(row["travelPos2"]);
                taskInfo.LiftPos2 = Convert.ToInt32(row["liftPos2"]);

                taskInfo.CurrentPositionID = Convert.ToInt32(row["currentPositionID"]);
                taskInfo.CurrentPositionName = row["currentPositionName"].ToString();
                taskInfo.CurrentPositionType = row["currentPositionType"].ToString();
                taskInfo.CurrentPositionExtension = Convert.ToInt32(row["currentPositionExtension"]);
                taskInfo.CurrentPositionState = row["currentPositionState"].ToString();

                taskInfo.NextPositionID = Convert.ToInt32(row["nextPositionID"]);
                taskInfo.NextPositionName = row["nextPositionName"].ToString();
                taskInfo.NextPositionType = row["nextPositionType"].ToString();
                taskInfo.NextPositionExtension = Convert.ToInt32(row["nextPositionExtension"]);

                taskInfo.EndPositionID = Convert.ToInt32(row["endPositionID"]);
                taskInfo.EndPositionName = row["endPositionName"].ToString();
                taskInfo.EndPositionType = row["endPositionType"].ToString();

                taskInfo.State = row["state"].ToString();

                taskInfo.HasGetRequest = Convert.ToBoolean(row["has_get_request"]);
                taskInfo.HasPutRequest = Convert.ToBoolean(row["has_put_request"]);

                return taskInfo;
            }
            return null;
        }
        public TaskInfo GetNewGeneraTask(string srmName, int travelPos)
        {
            return GetNewTask("pro_get_new_task_for_general", srmName, travelPos,0,null);
        }
        public TaskInfo GetNewGeneraTask(string srmName, int travelPos, int waitingTask)
        {
            return GetNewTask("pro_get_new_task_for_general", srmName, travelPos, waitingTask,null);
        }
        public TaskInfo GetNewGeneraTask(string srmName, int travelPos, int[] waitingTasks)
        {
            return GetNewTask("pro_get_new_task_for_general", srmName, travelPos, 0, waitingTasks);
        }
        public TaskInfo GetNewSmallSpeciesTask(string srmName,string productCode)
        {
            return GetNewTask("pro_get_new_task_for_small_stock_out", srmName,0,0,null, productCode);
        }
        public TaskInfo GetNewAbnormityTask(string srmName)
        {
            return GetNewTask("pro_get_new_task_for_abnormity_stock_out",  srmName,0,0,null);
        }
        
        public void UpdateTaskStateToWaiting(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            ra.DoCommand(string.Format("update wcs_task set state = '01' where id = '{0}'", taskID));
        }
        public void UpdateTaskStateToExecuting(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            ra.DoCommand(string.Format("update wcs_task set state = '02' where id = '{0}'", taskID));
        }
        public void UpdateTaskStateToPicking(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            ra.DoCommand(string.Format("update wcs_task set state = '03' where id = {0}",taskID));
        }
        public void UpdateTaskStatePickingToWaiting()
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            ra.DoCommand(string.Format("update wcs_task set state = '01' where state = '03'"));
        }
        public void UpdateTaskStateToExecuted(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            ra.DoCommand(string.Format("update wcs_task set state = '04' where id = '{0}'", taskID));
        }

        public void UpdateTaskPosition(int taskID, int positionID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            ra.DoCommand(string.Format("update wcs_task set current_position_id = {0} where id = '{1}'", positionID, taskID));
        }
        public void UpdateTaskPositionStateToNotArrive(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            ra.DoCommand(string.Format("update wcs_task set current_position_state = '01' where id = '{0}'", taskID));
        }
        public void UpdateTaskPositionStateToArrived(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            ra.DoCommand(string.Format("update wcs_task set current_position_state = '02' where id = '{0}'", taskID));
        }

        public DataTable FindStockInProduct()
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select b.product_code,b.product_name,
                    b.piece_barcode,sum(task_quantity) as task_quantity
                from wcs_task a
                left join wms_product b 
                    on a.product_code = b.product_code
                where a.order_type = '01' and a.state ='01' 
                    and a.current_position_id = a.origin_position_id
                    and a.current_position_id = {0}
                    and a.current_position_state = '01'
                group by b.product_code,b.product_name,b.piece_barcode", Global.STOCK_IN_POSITION_ID);
            var set = ra.DoQuery(sql);
            if (set.Tables.Count == 1)
            {
                return set.Tables[0];
            }
            return null;
        }
        public int GetTask(int productID, int quantity)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select a.id from wcs_task a
                left join wcs_product_size b 
                    on a.product_code = b.product_code
                where a.order_type = '01' and a.state ='01'  
                    and a.current_position_id = a.origin_position_id
                    and a.current_position_id = {0}
                    and a.current_position_state = '01'
                    and b.product_no = '{1}' 
                    and a.task_quantity = {2}
                order by a.target_position_id"
                , Global.STOCK_IN_POSITION_ID,productID, quantity);
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r));    
        }        
        
        public TagTaskInfo[] GetTagTaskInfoFromAbnormityTask()
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select a.id,b.tag_address,a.task_quantity from wcs_task a
	                                        left join wcs_position b on a.current_position_id = b.id
                                         where b.position_type = '04'");
            var set = ra.DoQuery(sql);
            if (set.Tables.Count == 1 && set.Tables[0].Rows.Count > 0)
            {
                var table = set.Tables[0];
                IList<TagTaskInfo> tagTaskInfos = new List<TagTaskInfo>();
                foreach (DataRow row in table.Rows)
                {
                    TagTaskInfo tagTaskInfo = new TagTaskInfo();
                    tagTaskInfo.TaskID = Convert.ToInt32(row["id"]);
                    tagTaskInfo.Address = row["tag_address"].ToString();
                    tagTaskInfo.Quantity = Convert.ToInt32(row["task_quantity"]);
                    tagTaskInfos.Add(tagTaskInfo);
                }

                return tagTaskInfos.ToArray();
            }
            return null;
        }
        public TagTaskInfo GetTagTaskInfoFromSmallSpeciesTask(SupplyInfo supplyInfo)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select a.id,b.tag_address,a.task_quantity -a.operate_quantity as task_quantity from wcs_task a
	                                        left join wcs_position b on a.current_position_id = b.id
                                         where b.position_type = '03' 
                                            and a.state = '01'
                                            and a.product_code = '{0}'", supplyInfo.ProductCode);
            var set = ra.DoQuery(sql);
            if (set.Tables.Count == 1 && set.Tables[0].Rows.Count == 1)
            {
                DataRow row = set.Tables[0].Rows[0];
                TagTaskInfo tagTaskInfo = new TagTaskInfo();
                tagTaskInfo.TaskID = Convert.ToInt32(row["id"]);
                tagTaskInfo.Address = row["tag_address"].ToString();
                tagTaskInfo.Quantity = Convert.ToInt32(row["task_quantity"]);
                if (supplyInfo.Quantity < tagTaskInfo.Quantity)
                {
                    tagTaskInfo.Quantity = supplyInfo.Quantity;
                }
                else
                {
                    supplyInfo.Quantity = tagTaskInfo.Quantity;
                }
                return tagTaskInfo;                
            }
            return null;
        }
        public bool CheckTaskComplete(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select id from wcs_task 
                                         where id = {0} and task_quantity = operate_quantity", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r)) == taskID;     
        }
        public bool CheckTaskCompleteWithOutRemain(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select id from wcs_task 
                                         where id = {0} and task_quantity = operate_quantity
                                            and quantity = task_quantity", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r)) == taskID; 
        }
        public void UpdateOperateQuantity(int taskID, int operateQuantity)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            ra.DoCommand(string.Format("update wcs_task set operate_quantity = operate_quantity + {0} where id = '{1}'", operateQuantity, taskID));
        }
        
        public string GetTaskNextPosition(int taskID)
        {
            //改写下个位置获取方法；
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select top 1 position_name from (
	                                        select b.id, b.position_name ,0 as path_node_order from wcs_task a
	                                        left join wcs_position b on a.origin_position_id = b.id
	                                        where a.id = {0}
	                                        union
	                                        select c.id, c.position_name ,b.path_node_order  from wcs_task a
	                                        left join wcs_path_node b on a.path_id = b.path_id
	                                        left join wcs_position c on b.position_id = c.id
	                                        where a.id= {0}
	                                        union
	                                        select b.id,b.position_name ,10000 as path_node_order from wcs_task a
	                                        left join wcs_position b on a.target_position_id = b.id
	                                        where a.id = {0}
                                        ) t
                                        where t.path_node_order > (select isnull(b.path_node_order,0) from wcs_task a
	                                        left join wcs_path_node b on a.path_id = b.path_id and a.current_position_id = b.position_id
	                                        where a.id= {0})
                                        order by path_node_order", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToString(DBNullUtil.Convert(r));
        }
        public string GetTaskNextTwoPosition(int taskID)
        {
            //改写下个位置获取方法；
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select top 1 position_name from (
	                                        select b.id, b.position_name ,0 as path_node_order from wcs_task a
	                                        left join wcs_position b on a.origin_position_id = b.id
	                                        where a.id = {0}
	                                        union
	                                        select c.id, c.position_name ,b.path_node_order  from wcs_task a
	                                        left join wcs_path_node b on a.path_id = b.path_id
	                                        left join wcs_position c on b.position_id = c.id
	                                        where a.id= {0}
	                                        union
	                                        select b.id,b.position_name ,10000 as path_node_order from wcs_task a
	                                        left join wcs_position b on a.target_position_id = b.id
	                                        where a.id = {0}
                                        ) t
                                        where t.path_node_order > (select isnull(b.path_node_order,0) + 1 from wcs_task a
	                                        left join wcs_path_node b on a.path_id = b.path_id and a.current_position_id = b.position_id
	                                        where a.id= {0})
                                        order by path_node_order", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToString(DBNullUtil.Convert(r));
        }      
        public int GetCurrentPositionID(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select current_position_id from wcs_task 
                                         where id = {0} ", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r));
        }
        public int GetNextPositionID(int taskID)
        {
            //改写下个位置获取方法；
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select top 1 id from (
	                                        select b.id, b.position_name ,0 as path_node_order from wcs_task a
	                                        left join wcs_position b on a.origin_position_id = b.id
	                                        where a.id = {0}
	                                        union
	                                        select c.id, c.position_name ,b.path_node_order  from wcs_task a
	                                        left join wcs_path_node b on a.path_id = b.path_id
	                                        left join wcs_position c on b.position_id = c.id
	                                        where a.id= {0}
	                                        union
	                                        select b.id,b.position_name ,10000 as path_node_order from wcs_task a
	                                        left join wcs_position b on a.target_position_id = b.id
	                                        where a.id = {0}
                                        ) t
                                        where t.path_node_order > (select isnull(b.path_node_order,0) from wcs_task a
	                                        left join wcs_path_node b on a.path_id = b.path_id and a.current_position_id = b.position_id
	                                        where a.id= {0})
                                        order by path_node_order", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r));
        }
        public int GetEndPositionID(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select target_position_id from wcs_task 
                                         where id = {0} ", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r));   
        }

        public string GetOrderType(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select order_type from wcs_task 
                                         where id = {0} ", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToString(DBNullUtil.Convert(r));   
        }
        public string GetOrderID(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select order_id from wcs_task 
                                         where id = {0} ", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToString(DBNullUtil.Convert(r));   
        }
        public int GetAllotID(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select allot_id from wcs_task 
                                         where id = {0} ", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r));   
        }
        public string GetOriginCellCode(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select origin_cell_code from wcs_task 
                                         where id = {0} ", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToString(DBNullUtil.Convert(r));
        }
        public string GetTargetCellCode(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select target_cell_code from wcs_task 
                                         where id = {0} ", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToString(DBNullUtil.Convert(r));
        }
        public string GetOriginStorageCode(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select origin_storage_code from wcs_task 
                                         where id = {0} ", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToString(DBNullUtil.Convert(r));   
        }
        public string GetTargetStorageCode(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select target_storage_code from wcs_task 
                                         where id = {0} ", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToString(DBNullUtil.Convert(r));   
        }

        public string GetStockOutCellName(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select b.cell_name from wcs_task a
                left join wms_cell b on a.origin_cell_code = b.cell_code 
                where id = {0} ", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToString(DBNullUtil.Convert(r));   
        }
        public string GetProductName(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select product_name from wcs_task 
                                         where id = {0} ", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToString(DBNullUtil.Convert(r));   
        }
        public string GetStorageQuantity(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select quantity from wcs_task 
                                         where id = {0} ", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToString(DBNullUtil.Convert(r));   
        }
        public string GetStockOutQuantity(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select task_quantity from wcs_task 
                                         where id = {0} ", taskID);
            var r = ra.DoScalar(sql);
            return Convert.ToString(DBNullUtil.Convert(r));   
        }

        public bool CheckPositionTask(int positionID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select count(*) from wcs_task a
                                         where a.current_position_id = {0} 
                                            and a.current_position_state = '02'
                                            and (a.state = '01' or a.state = '02')
                                            and (a.storage_sequence  
				                                = (select isNull(min(storage_sequence),0) from wms_storage
					                                where quantity > 0 and cell_code = a.origin_cell_code)
				                                or a.order_type = '00'
				                                or a.order_type = '01'
				                                or a.order_type = '05' 
				                                or a.order_type = '06' 
				                                or a.order_type = '07' 
				                                or a.order_type = '08'
				                                or a.order_type = '09') ", positionID);
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r)) == 1;   
        }

        public void UpgradeTaskLevel(int positionID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            ra.DoCommand(string.Format(@"update wcs_task set task_level = 100
                                            where target_position_id = '{1}' 
                                                and state <> '04'", positionID));
        }
    }
}
