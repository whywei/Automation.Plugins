using System;
using DBRabbit;
using Automation.Plugins.MDJ.WCS.Model;
using Automation.Core.Util;

namespace Automation.Plugins.MDJ.WCS.Dal
{
    [Serializable]
    class PositionDal : AbstractBaseDal
    {
        public void UpdateHasGoodsToFalse(int positionID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            ra.DoCommand(string.Format("update wcs_position set has_goods = 0 where id = {0}",positionID));
        }

        public void UpdateHasGoodsToTrue(int positionID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            ra.DoCommand(string.Format("update wcs_position set has_goods = 1 where id = {0}", positionID));
        }

        public string GetPositionNameByPositionID(int positionID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format("select position_name from wcs_position  where id = '{0}'", positionID);
            var r = ra.DoScalar(sql);
            return Convert.ToString(DBNullUtil.Convert(r));        
        }

        public int GetPositionIDByPositionName(string positionName)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format("select id from wcs_position  where position_name = '{0}'", positionName);
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r));        
        }

        public int GetTaskIDByTagAddress(string address)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format("select current_task_id from wcs_position  where tag_address = '{0}'", address);
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r));        
        }

        public int GetPositionIDByTagAddress(string address)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format("select id from wcs_position  where tag_address = '{0}'", address);
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r));        
        }

        public int GetOperateQuantityByTagAddress(string address)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format("select current_operate_quantity from wcs_position  where tag_address = '{0}'", address);
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r));
        }

        public void UpdatePositionStateToPicking(TagTaskInfo tagTaskInfo)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            ra.DoCommand(string.Format(@"update wcs_position set current_task_id = {0},current_operate_quantity ={1}
                                         where tag_address = {2}", tagTaskInfo.TaskID, tagTaskInfo.Quantity,tagTaskInfo.Address));
        }

        public void TagKeyPress(int taskID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            ra.DoCommand(string.Format(@"update wcs_position set current_task_id = 0,current_operate_quantity = 0
                                         where current_task_id = {0}", taskID));
        }

        public bool HasEmptyAutomaticDemolitionPlatePosition()
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select count(*) from wcs_position
                                            where position_type = '02'			
					                            and has_goods = 0");
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r)) > 0;   
        }
    }
}
