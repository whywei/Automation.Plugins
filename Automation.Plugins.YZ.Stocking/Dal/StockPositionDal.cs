using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.YZ.Stocking.Dal
{
    public class StockPositionDal : AbstractBaseDal
    {
        public DataTable FindStockPositionByProduct(string productCode)
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = @"select a.id,a.product_code,a.product_name,quantity,b.position_type,b.position_address 
                        from sms_supply_position_storage a left join sms_supply_position b on a.position_id=b.id
                        where a.product_code='{0}' order by quantity";
            return ra.DoQuery(string.Format(sql,productCode)).Tables[0];
        }

        public DataTable FindMixStockPosition()
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = @"select id,position_address from sms_supply_position";
            return ra.DoQuery(sql).Tables[0];
        }

        public void UpdateSupplyPositionStorage(string id)
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = @"update sms_supply_position_storage set quantity=quantity-1 where id={0}";
            ra.DoCommand(string.Format(sql, id));
        }
    }
}
