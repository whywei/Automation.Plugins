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
        public DataTable FindSupplyPosition()
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = @"SELECT id
                          ,position_name
                          ,case position_type when '01' then '正常拆盘位' else  '混合拆盘位' end position_type
                          ,product_code
                          ,product_name
                          ,position_address
                          ,position_capacity
                          ,sorting_line_codes
                          ,target_supply_addresses
                          ,description
                          ,case is_active when '1' then '可用' else  '不可用' end is_active FROM sms_supply_position";
            return ra.DoQuery(sql).Tables[0];
        }

    }
}
