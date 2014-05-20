using System;
using DBRabbit;
using Automation.Core.Util;

namespace Automation.Plugins.MDJ.WCS.Dal
{
    [Serializable]
    class StorageDal : AbstractBaseDal
    {
        public int GetStorageQuantity(int positionID)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select sum(c.quantity) from wcs_cell_position a
	                                        left join wms_cell b on a.cell_code = b.cell_code
	                                        left join wms_storage c on a.cell_code = c.cell_code
                                         where a.stock_in_position_id = '{0}' and b.is_single = 1", positionID);
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r));     
        }
    }
}
