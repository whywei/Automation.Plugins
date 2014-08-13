using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBRabbit;

namespace Automation.Plugins.YZ.ManualSupply.Dal
{
    public class HandSupplyDal : AbstractBaseDal
    {
        public DataTable GetHandSupplyBySupplyBatch(int supplyBatch)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select a.supply_id ,a.supply_batch ,a.pack_no ,a.channel_code ,a.product_code
                                        ,a.product_name ,a.quantity
                                        ,cast(a.status as bit) status
                                        ,b.channel_name
                                        from handle_supply a 
                                        left join channel_allot b on a.channel_code = b.channel_code 
                                        where a.supply_batch='{0}' order by a.supply_id,a.quantity desc", supplyBatch);
            return ra.DoQuery(sql).Tables[0];
        }

        public int GetLastSupplyBatchNo()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select top 1 supply_batch from handle_supply 
                                         where supply_batch 
                                         in (select top 1 max(supply_batch) from handle_supply)");
            object result = ra.DoScalar(sql);
            return result == null ? 0 : Convert.ToInt32(result);
        }

        public int GetCurrentSupplyBatch()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql1 = string.Format("select top 1 supply_batch from handle_supply where status='0' order by supply_id,supply_batch ");
            string sql2 = string.Format("select max(supply_batch) supply_batch from handle_supply ");
            DataTable dt1 = ra.DoQuery(sql1).Tables[0];
            //作业已都补完
            if (dt1.Rows.Count == 0)
            {
                DataTable dt2 = ra.DoQuery(sql2).Tables[0];
                if (dt2.Rows.ToString() == "")
                {
                    throw new Exception("手工补货表无数据");
                }
                else
                {
                    throw new Exception("手工补货任务都已完成");
                }
            }
            else
            {
                object result = dt1.Rows[0]["supply_batch"];
                return result == null ? 0 : Convert.ToInt32(result);
            }
        }

        public int GetHandSupplyCountBySupplyBatch(int supplyBatch)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format("select count(*) from handle_supply where supply_batch='{0}' ", supplyBatch);
            object result = ra.DoScalar(sql);
            return result == null ? 0 : Convert.ToInt32(result);
        }

        public void FinishSupply(string supplyId)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format("update handle_supply set status = '1' where supply_id={0} ", supplyId);
            ra.DoCommand(sql);
        }
    }
}
