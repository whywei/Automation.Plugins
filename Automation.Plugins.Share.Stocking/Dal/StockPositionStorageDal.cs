using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.Share.Stocking.Dal
{
    public class StockPositionStorageDal : AbstractBaseDal
    {
        public DataTable FindStockPositionStorage()
        {
            //todo:库存查询时，要显示位置名称
            var ra = TransactionScopeManager[Global.DATABASE_NAME].NewRelationAccesser();
            string sql = @"select id,position_id,product_code,product_name,quantity,wait_quantity  
                            from sms_supply_position_storage";
            return ra.DoQuery(sql).Tables[0];
        }
    }
}
