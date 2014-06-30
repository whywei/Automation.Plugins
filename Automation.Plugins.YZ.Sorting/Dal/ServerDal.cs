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
            string sql = string.Format(@"SELECT TOP 1 batch_sort_id,batch_id,sorting_line_code,status
            FROM sms_batch_sort where status='01'");
            return ra.DoQuery(sql).Tables[0];
        }


        //下载烟道表
        public DataTable FindChannel(string batchsortid)
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = string.Format(@"SELECT a.channel_allot_code
                                              ,a.batch_sort_id
                                              ,a.channel_code
                                              ,a.product_code
                                              ,a.product_name
                                              ,a.in_quantity
                                              ,a.out_quantity
                                              ,a.real_quantity
                                              ,a.remain_quantity  
                                              ,b.channel_code
                                              ,b.sorting_line_code
                                              ,b.channel_name
                                              ,b.channel_type
                                              ,b.led_code
                                              ,b.default_product_code
                                              ,b.remain_quantity
                                              ,b.middle_quantity
                                              ,b.max_quantity
                                              ,b.group_no
                                              ,b.order_no
                                              ,b.address
                                              ,b.cell_code
                                              ,b.status 
                                               FROM sms_channel_allot a 
                                               left join dbo.sms_channel b on a.channel_code=b.channel_code
                                               WHERE batch_sort_id='{0}'", batchsortid);
            return ra.DoQuery(sql).Tables[0];
        }

        //下载订单主表 
        public DataTable FindOrderMaster(string batchsortid)
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = string.Format(@"SELECT a.batch_sort_id,
                                                pack_no,
                                                d.order_id,
                                                customer_order,
                                                customer_deliver_order,
                                                quantity,
                                                export_no,
                                                start_time,
                                                finish_time,
                                                a.status,
                                                c.order_date,
                                                c.batch_no,
                                                e.custom_code,
                                                e.customer_name,
                                                g.deliver_line_code,
                                                g.deliver_line_name,
                                                h.sorting_line_code,
                                                e.license_code,
                                                e.address,
                                                f.dist_code,
                                                f.dist_name
                                                FROM sms_sort_order_allot_master a
                                                left join sms_batch_sort b on a.batch_sort_id=b.batch_sort_id
                                                left join sms_batch c on b.batch_id=c.batch_id
                                                left join wms_sort_order d on a.order_id=d.order_id
                                                left join wms_customer e on d.customer_code=e.custom_code
                                                left join wms_deliver_dist f on d.customer_code=f.custom_code 
                                                left join dbo.wms_deliver_line g on e.custom_code=g.custom_code
                                                left join dbo.sms_batch_sort h on a.batch_sort_id=h.batch_sort_id
                                                WHERE a.batch_sort_id='{0}'", batchsortid);
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
                                                left join sms_sort_order_allot_master b on b.order_master_code=a.order_master_code where b.batch_sort_id='{0}'", batchsortid);
            return ra.DoQuery(sql).Tables[0];
        }
        //下载手工补货订单明细表   //未实现功能模块
        public DataTable FindHandleSupply(string batchsortid)
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = string.Format(@"select 


                                        where b.batch_sort_id='{0}')", batchsortid);
            return ra.DoQuery(sql).Tables[0];
        }

        //更新批次状态提示数据下载完成
        public void UpdateBatchStatus(string batchsortid)
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            ra.DoCommand(string.Format("update sms_batch_sort set status ='02' where batch_sort_id = '{0}'", batchsortid));
        }
    }
}
