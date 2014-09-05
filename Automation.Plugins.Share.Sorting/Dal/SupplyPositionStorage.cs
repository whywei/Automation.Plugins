using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.Share.Sorting.Dal
{
    public class SupplyPositionStorage : AbstractBaseDal
    {
        public DataTable FindSupplyPositionStorage()
        {
            var ra = TransactionScopeManager[Global.SERVER_DATABASE_NAME].NewRelationAccesser();
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
