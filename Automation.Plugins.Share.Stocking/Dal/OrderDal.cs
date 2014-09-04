using DBRabbit;
using System.Data;

namespace Automation.Plugins.Share.Stocking.Dal
{
    public class OrderDal : AbstractBaseDal
    {
        public DataTable FindProduct()
        {
            var ra = TransactionScopeManager[Global.DATABASE_NAME].NewRelationAccesser();
            string sql = @"select distinct d.product_code,d.product_name,d.piece_barcode
                            from sms_sort_batch a   
                            left join  sms_sort_order_allot_master b on a.id = b.sort_batch_id
                            left join  sms_sort_order_allot_detail c on b.id = c.master_id
                            left join  wms_product d on c.product_code = d.product_code
                            where a.order_date > DATEADD(day,7,GETDATE())
                            order by d.product_code";
            return ra.DoQuery(sql).Tables[0];
        }
    }
}
