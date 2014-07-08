using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBRabbit;

namespace Automation.Plugins.YZ.Sorting.Dal
{
    public class ServerDal : AbstractBaseDal
    {

        public DataTable FindBatch()
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = string.Format(@"SELECT TOP 1 batch_no,sorting_line_code,status
            FROM sms_sort_batch where status='01'");
            return ra.DoQuery(sql).Tables[0];
        }


        //下载烟道表  a.sort_batch_id,
        public DataTable FindChannel(string batchsortid)
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = string.Format(@"SELECT 

                                                a.channel_code,
                                                a.product_code,
                                                a.product_name,
                                                a.quantity,
                                                b.channel_type,
                                                b.channel_name,
                                                b.sorting_line_code,
                                                b.led_no,
                                                b.x,
                                                b.y,
                                                b.width,
                                                b.height,
                                                b.default_product_code,
                                                b.default_product_name,
                                                b.remain_quantity,
                                                b.channel_capacity,
                                                b.group_no,
                                                b.order_no,
                                                b.sort_address,
                                                b.supply_address,                                             
                                                b.status 
                                                FROM sms_channel_allot a 
                                                left join dbo.sms_channel b on a.channel_code=b.channel_code
                                                WHERE sort_batch_id='{0}'", batchsortid);
            return ra.DoQuery(sql).Tables[0];
        }

        //下载订单主表  
        public DataTable FindOrderMaster(string batchsortid)
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = string.Format(@"SELECT a.sort_batch_id,
                                                a.pack_no,
                                                a.order_id,
                                                a.deliver_line_code,
                                                a.customer_code,
                                                a.customer_name,
                                                a.customer_order,
                                                a.customer_deliver_order,
                                                a.customer_info,
                                                a.quantity,
                                                a.export_no,
                                                a.start_time,
                                                a.finish_time,
                                                a.status,
                                                b.order_date,
                                                b.batch_no,
                                                b.sorting_line_code,
                                                c.master_id,
                                                d.dist_code,
                                                d.dist_name,
                                                e.deliver_line_name,
                                                f.license_code,
                                                f.address  
                                                FROM sms_sort_order_allot_master a
                                                left join sms_sort_batch b on a.sort_batch_id=b.batch_no
                                                left join sms_sort_order_allot_detail c on a.id=c.master_id
                                                left join wms_deliver_dist d on a.customer_code=d.custom_code
                                                left join wms_deliver_line e on a.deliver_line_code=e.deliver_line_code
                                                left join wms_customer f on a.customer_code=f.custom_code
                                                WHERE a.sort_batch_id='{0}'", batchsortid);
            return ra.DoQuery(sql).Tables[0];
        }
        //下载订单细表
        public DataTable FindOrderDetail(string batchsortid)
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = string.Format(@"select a.channel_code,                                              
                                                a.product_code,
                                                a.product_name,
                                                a.quantity,
                                                b.pack_no as pack_no
                                                from sms_sort_order_allot_detail a
                                                left join sms_sort_order_allot_master b on b.id=a.master_id where b.sort_batch_id='{0}'", batchsortid);
            return ra.DoQuery(sql).Tables[0];
        }
        //下载手工补货订单明细表
        public DataTable FindHandleSupply(string batchsortid)
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = string.Format(@"SELECT supply_id,supply_batch,pack_no,channel_code,product_code,product_name,quantity
                                                FROM sms_hand_supply where sort_batch_id='{0}'", batchsortid);
            return ra.DoQuery(sql).Tables[0];
        }

        //更新批次状态提示数据下载完成
        public void UpdateBatchStatus(string batchsortid)
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            ra.DoCommand(string.Format("update sms_sort_batch set status ='02' where batch_no = '{0}'", batchsortid));
        }
    }
}
