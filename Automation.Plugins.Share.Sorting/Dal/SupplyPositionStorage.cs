using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.YZ.Sorting.Dal
{
    public class SupplyPositionStorage : AbstractBaseDal
    {
        public DataTable FindSupplyPositionStorage()
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = @"SELECT id
                          ,position_id
                          ,product_code
                          ,product_name
                          ,quantity
                          ,wait_quantity  FROM sms_supply_position_storage";
            return ra.DoQuery(sql).Tables[0];
        }
    }
}
