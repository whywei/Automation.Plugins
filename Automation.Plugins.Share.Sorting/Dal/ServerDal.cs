using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBRabbit;

namespace Automation.Plugins.Share.Sorting.Dal
{
    public class ServerDal : AbstractBaseDal
    {
        public DataTable FindBatch(string lineCode)
        {
            var ra = TransactionScopeManager[Global.SERVER_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select id,convert(nvarchar(10), order_date,20) order_date,batch_no,sorting_line_code
                        from sms_sort_batch 
                        where status='03' and sorting_line_code='{0}'
                        order by order_date,batch_no";
            return ra.DoQuery(string.Format(sql, lineCode)).Tables[0];
        }

        //下载烟道表  a.sort_batch_id,
        public DataTable FindChannel(string batchsortid)
        {
            var ra = TransactionScopeManager[Global.SERVER_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"select a.channel_code,a.product_code,a.product_name,c.piece_barcode,a.quantity,
                                        b.channel_type,b.channel_name,b.sorting_line_code,b.led_no,b.x,b.y,b.width,
                                        b.height,b.remain_quantity,b.channel_capacity,b.group_no,b.order_no,b.sort_address,
                                        b.supply_address,b.is_active
                                        from sms_channel_allot a 
                                        left join sms_channel b on a.channel_code=b.channel_code
                                        left join wms_product c on a.product_code=c.product_code
                                        where sort_batch_id={0}", batchsortid);
            return ra.DoQuery(sql).Tables[0];
        }

        //下载订单主表  
        public DataTable FindOrderMaster(string batchsortid)
        {
            var ra = TransactionScopeManager[Global.SERVER_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"select b.order_date,b.batch_no,b.sorting_line_code,a.pack_no,
                                    a.order_id,d.dist_code,d.dist_name,a.deliver_line_code,e.deliver_line_name,
                                    a.customer_code,a.customer_name,f.license_code,f.address,a.customer_order,
                                    a.customer_deliver_order,a.customer_info,a.quantity,a.export_no
                                    from sms_sort_order_allot_master a
                                    left join sms_sort_batch b on a.sort_batch_id=b.id
                                    left join wms_deliver_line e on a.deliver_line_code=e.deliver_line_code
                                    left join wms_deliver_dist d on e.dist_code=d.dist_code
                                    left join wms_customer f on a.customer_code=f.customer_code
                                    where a.sort_batch_id='{0}' order by a.pack_no", batchsortid);
            return ra.DoQuery(sql).Tables[0];
        }
        //下载订单细表
        public DataTable FindOrderDetail(string batchsortid)
        {
            var ra = TransactionScopeManager[Global.SERVER_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"select a.channel_code,a.product_code,a.product_name,a.quantity,b.pack_no as pack_no
                                    from sms_sort_order_allot_detail a
                                    left join sms_sort_order_allot_master b on b.id=a.master_id where b.sort_batch_id='{0}'", batchsortid);
            return ra.DoQuery(sql).Tables[0];
        }
        //下载手工补货订单明细表
        public DataTable FindHandleSupply(string batchsortid)
        {
            var ra = TransactionScopeManager[Global.SERVER_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"select supply_id,supply_batch,pack_no,channel_code,product_code,product_name,quantity
                                      from sms_hand_supply where sort_batch_id='{0}'", batchsortid);
            return ra.DoQuery(sql).Tables[0];
        }

        //更新批次状态提示数据下载完成
        public void UpdateBatchStatus(string batchsortid)
        {
            var ra = TransactionScopeManager[Global.SERVER_DATABASE_NAME].NewRelationAccesser();
            ra.DoCommand(string.Format("update sms_sort_batch set status ='04' where id = '{0}'", batchsortid));
        }

        public DataTable FindBatchInfoById(string batchId)
        {
            var ra = TransactionScopeManager[Global.SERVER_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select order_date,batch_no from sms_sort_batch where id={0}";
            return ra.DoQuery(string.Format(sql, batchId)).Tables[0];
        }
    }
}
