using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.YZ.Sorting.Dal
{
    public class HandSupplyDal : AbstractBaseDal
    {
        public int GetCurrentSupplyBatch()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format("select top 1 supply_batch from handle_supply where status='0' order by supply_id, supply_batch ");
            string max = string.Format("select max(supply_batch) supply_batch from handle_supply ");
            DataTable dt1 = ra.DoQuery(sql).Tables[0];
            //作业已都补完
            if (dt1.Rows.Count == 0)
            {
                DataTable dt2 = ra.DoQuery(max).Tables[0];
                
                if (dt2.Rows[0]["supply_batch"].ToString() == "")
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
                return Convert.ToInt32(dt1.Rows[0]["supply_batch"]);
            }
        }

        public DataTable GetHandSupplyBySupplyBatch(int supplyBatch)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select a.supply_id,a.supply_batch,a.pack_no,a.channel_code,a.product_code
                                        ,a.product_name,a.quantity
                                        ,case when a.status = 1 then '已补货' else '未补货' end status 
                                        from handle_supply a 
                                        left join channel_allot b on a.channel_code = b.channel_code 
                                        where a.supply_batch='{0}' order by a.supply_id, a.quantity desc", supplyBatch);
            return ra.DoQuery(sql).Tables[0];
        }
    }
}
