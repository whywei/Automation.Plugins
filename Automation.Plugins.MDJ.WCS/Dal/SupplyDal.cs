using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Plugins.MDJ.WCS.Model;
using DBRabbit.Relation;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.MDJ.WCS.Dal
{
    [Serializable]
    class SupplyDal : AbstractBaseDal
    {
        public SupplyInfo GetSupplyInfo()
        {
            var spa = TransactionScopeManager[Global.THOK_STOCK_DB_NAME].NewSPAccesser();
            IList<SPParameter> @params = new List<SPParameter>();
            IDictionary<string, object> outVals = new Dictionary<string, object>();
            //todo：存储过程未实现；
            var set = spa.ExecuteQuery("pro_get_supply_Info", @params, out outVals);
            if (set.Tables.Count == 1 && set.Tables[0].Rows.Count == 1)
            {
                var row = set.Tables[0].Rows[0];
                SupplyInfo supplyInfo = new SupplyInfo();
                supplyInfo.ProductCode = row["product_code"].ToString();
                supplyInfo.Quantity = Convert.ToInt32(row["quantity"]);
                return supplyInfo;
            }
            return null;
        }

        public bool UpdateSupplyState(SupplyInfo currentSupplyInfo)
        {
            var spa = TransactionScopeManager[Global.THOK_STOCK_DB_NAME].NewSPAccesser();
            IList<SPParameter> @params = new List<SPParameter>();
            SPParameter sPParameter1 = new SPParameter("product_code", ParameterDirection.Input, currentSupplyInfo.ProductCode);
            SPParameter sPParameter2 = new SPParameter("quantity", ParameterDirection.Input, currentSupplyInfo.Quantity);
            @params.Add(sPParameter1);
            @params.Add(sPParameter2);
            IDictionary<string, object> outVals = new Dictionary<string, object>();
            //todo：存储过程未实现；
            spa.ExecuteNoneQuery("pro_update_supply_Info", @params, out outVals);
            return true;
        }
    }
}
