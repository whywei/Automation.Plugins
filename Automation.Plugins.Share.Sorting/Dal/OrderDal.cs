using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;
using THOK.Util;
using Automation.Core.Util;

namespace Automation.Plugins.Share.Sorting.Dal
{
    public class OrderDal : AbstractBaseDal
    {
        public DataTable FindMaster()
        {

            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select order_date,batch_no,line_code,pack_no,order_id,dist_code,
                   dist_name,deliver_line_code,deliver_line_name,customer_code,customer_name,license_no,
                   address,customer_order,customer_deliver_order,quantity,export_no,start_time,finish_time,
                   case status when '01' then '未下单' else '已下单' end status from sort_order_allot_master";
            return ra.DoQuery(sql).Tables[0];
        }

        public DataTable FindDetailBySortNo(string pack_no)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"select a.pack_no,a.channel_code,b.channel_name,a.product_code,a.product_name,a.quantity,
            c.customer_deliver_order,c.quantity as quantity1,c.export_no
            from sort_order_allot_detail a left join channel_allot b on a.channel_code=b.channel_code and a.product_code=b.product_code
            left join sort_order_allot_master c on a.pack_no=c.pack_no 
            where a.pack_no={0} order by pack_no", pack_no);
            return ra.DoQuery(sql).Tables[0];
        }

        /// <summary>
        /// 查询多沟带缓存段
        /// </summary>
        /// <param name="channelGroup">通道组</param>
        /// <param name="sortNoStart">前端订单号</param>
        /// <returns>返回多沟带缓存段起所有订单数据</returns>         
        public DataTable FindDetailForCacheOrderQuery(string channelGroup, int sortNoStart)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select a.sortno,a.orderid,a.cigarettecode, a.cigarettename, a.quantity ,c.customername,b.channelname,   
                        case b.channeltype when '2' then '立式机' when '5' then '立式机' else '卧式机' end channeltype,   
                        case when a.channelgroup=1 then 'A线' else 'B线' end  channelline
                        from as_sc_order a  
                          left join as_sc_channelused b on a.channelcode=b.channelcode   
                            left join as_sc_palletmaster c on a.sortno = c.sortno and a.orderid = c.orderid and a.orderdate = c.orderdate
                              where a.channelgroup ={0} and a.sortno >={1} order by a.sortno,b.channeladdress";
            return ra.DoQuery(string.Format(sql, channelGroup == "A" ? "1" : "2", sortNoStart)).Tables[0];
        }

        public DataTable FindCustomerMaster()
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select orderno,min(sortno) as sortno,orderid,routecode,routename,customercode,customername,batchno,
                        address,sum(quantity)as quantity,sum(quantity1) as quantity1,sum(quantity) + sum(quantity1) as allquantity,
                        case min(status) when '01' then '未下单' else '已下单' end status,min(orderdate) as orderdate 
                        from as_sc_palletmaster
                        group by orderno ,orderid,routecode,routename,customercode,customername,batchno,address order by sortno";
            return ra.DoQuery(sql).Tables[0];
        }

        public List<string> FindCigaretteList()
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select cigarettecode+'-'+cigarettename as cigarette
                           from as_sc_order group by cigarettecode,cigarettename order by cigarettecode";
            DataTable table = ra.DoQuery(sql).Tables[0];
            List<string> list = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(row["cigarette"].ToString());
            }
            return list;
        }

        public DataTable FindPackMaster(string cigaretteCode, int quantity)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"select orderno,min(sortno) as sortno,orderid,routecode,routename,customercode,customername,batchno,
                                        address,sum(quantity)as quantity,sum(quantity1) as quantity1,sum(quantity) + sum(quantity1) as allquantity,
                                        case min(status) when '01' then '未下单' else '已下单' end status,min(orderdate) as orderdate 
                                        from as_sc_palletmaster
                                        where orderid in (select orderid  from as_sc_order where  cigarettecode = '{0}'  group by orderid,cigarettecode having sum(quantity) = {1} )
                                         group by orderno ,orderid,routecode,routename,customercode,customername,batchno,address order by sortno", cigaretteCode, quantity);
            return ra.DoQuery(sql).Tables[0];
        }

        /// <summary>
        /// 根据A线或B线查询当前缺烟的流水号
        /// </summary>
        /// <param name="channelGroup">A线或者B线</param>
        /// <returns>返回一个流水号</returns>
        public string FindMaxSortedMaster(string channelGroup)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = "select isnull(max(sortno),0) from as_sc_palletmaster where status{0} ='1'";
            object result = ra.DoScalar(string.Format(sql, channelGroup == "A" ? "" : "1"));
            return result == null ? "0" : result.ToString();
        }

        public void UpdateOrderDetailByChannelCode(string sourceChannelCode, string targetChannelCode)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format("update sort_order_allot_detail set channel_code='{0}' where channel_code='{1}'", targetChannelCode, sourceChannelCode);
            ra.DoCommand(sql);
        }

        public DataTable FindHandSupply(string condition)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"select a.supplyno,a.sortno,a.cigarettecode,a.batchno,a.cigarettename,
                           a.linecode,a.orderdate,a.supplybatch,a.quantity,a.channelcode,channelname,
                           case when a.status = 1 then '已补货' else '未补货' end status 
                           from as_sc_handlesupply a left join as_sc_channelused b on a.channelcode = b.channelcode 
                           {0} order by a.supplyno", condition);
            return ra.DoQuery(sql).Tables[0];
        }

        //判断是否存在未分拣数据
        public int FindUnSortCount()
        {
            var ra = TransactionScopeManager[Global.SERVER_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"select count(*) from sms_sort_order_allot_master where status='01'");
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r));
        }

        /// <summary>
        /// 删除贴标机数据
        /// </summary>
        public void DeleteTable(string tableName)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            ra.DoScalar(string.Format("truncate table {0}",tableName));
        }


        public void InsertMaster(DataRow row)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"insert into sort_order_allot_master values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}',NULL,NULL,'01')";
            ra.DoCommand(string.Format(sql,row["order_date"], row["batch_no"], row["sorting_line_code"], row["pack_no"]
                ,row["order_id"], row["dist_code"], row["dist_name"], row["deliver_line_code"],row["deliver_line_name"]
                , row["customer_code"], row["customer_name"], row["license_code"],row["address"], row["customer_order"]
                , row["customer_deliver_order"], row["customer_Info"],row["quantity"],row["export_no"]));
        }

        public void InsertOrderDetail(DataRow row)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"insert into sort_order_allot_detail values('{0}','{1}','{2}','{3}','{4}')",
            row["pack_no"], row["channel_code"], row["product_code"], row["product_name"], row["quantity"]);
            ra.DoCommand(sql);
        }

        public void InsertHandleSupply(DataRow row)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"insert into handle_supply values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
            row["supply_id"], row["supply_batch"], row["pack_no"], row["channel_code"], row["product_code"], row["product_name"], row["quantity"], '0');
            ra.DoCommand(sql);
        }

        public DataTable FindOrderInfo(string sortNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = "";
            if (sortNo != "all")
                sql = @"select count(distinct customer_code) customer_num, count(distinct deliver_line_code) deliver_line_num,
                         (select isnull(sum(quantity),0) from sort_order_allot_master where finish_time <= getdate() and status='02' ) quantity
                         from sort_order_allot_master where finish_time <= getdate()";
            else
                sql = @"select count(distinct customer_code) customer_num, count(distinct deliver_line_code) deliver_line_num,
                         (select isnull(sum(quantity),0) from sort_order_allot_master) quantity
                         from sort_order_allot_master";
            return ra.DoQuery(sql).Tables[0];
        }

        /// <summary>
        /// 获取主单最大的包号
        /// </summary>
        /// <returns>包号</returns>
        public int FindMaxPackNo(int groupNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select isnull(max(pack_no),0) pack_no from sort_order_allot_detail a
                            left join channel_allot b on a.channel_code=b.channel_code and a.product_code=b.product_code
                           where group_no={0}";
            return Convert.ToInt32(ra.DoScalar(string.Format(sql,groupNo)));
        }

        /// <summary>
        /// 获取主单卷烟总条数
        /// </summary>
        /// <returns>条数</returns>
        public int FindSumQuantityFromMaster()
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = "select isnull(sum(quantity),0) quantity from sort_order_allot_master";
            return Convert.ToInt32(ra.DoScalar(sql));
        }

        public void UpdateMasterStatus(int packNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = "update sort_order_allot_master set status='02',start_time=getdate() where pack_no<={0} and status='01'";
            ra.DoCommand(string.Format(sql, packNo));
        }

        public DataTable FindOrderDetailByPackNo(int packNo,int groupNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select a.pack_no,a.channel_code,c.sort_address,c.group_no,b.export_no,b.customer_order,a.product_code,a.product_name,a.quantity,c.piece_barcode
                          from sort_order_allot_detail a left join sort_order_allot_master b on a.pack_no=b.pack_no
                          left join channel_allot c on a.channel_code=c.channel_code and a.product_code=c.product_code
                          left join handle_supply d on  a.pack_no=d.pack_no and a.channel_code=d.channel_code and a.product_code=d.product_code
                          where a.pack_no=(select isnull(min(pack_no),0) pack_no from sort_order_allot_detail e
							               left join channel_allot f on e.channel_code=f.channel_code and e.product_code=f.product_code
							               where e.pack_no>{0} and group_no={1}) and c.group_no={1}
                          order by a.pack_no asc,c.group_no desc,c.sort_address,d.supply_batch,d.supply_id";
            return ra.DoQuery(string.Format(sql, packNo,groupNo)).Tables[0];
        }

        public int FindRemainquantity(int packNo, string channelCode)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select isnull(sum(d.quantity),0)-(select count(*) from sorting f where f.channel_code='{1}' and f.pack_no={0}+1) 
                          from sort_order_allot_detail d left join channel_allot e on d.channel_code=e.channel_code and d.product_code=e.product_code 
                          where d.pack_no>{0} and e.channel_code='{1}' ";
            return Convert.ToInt32(ra.DoScalar(string.Format(sql, packNo, channelCode)));
        }

        public DataTable FindExporNoFromMaster()
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = "select distinct export_no,convert(varchar(100),order_date,23) order_date from sort_order_allot_master";
            return ra.DoQuery(sql).Tables[0];
        }

        public DataTable FindPackData(string condition)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select row_number() over(order by a.pack_no,c.group_no desc,c.sort_address,d.supply_batch,d.supply_id) id
                        ,a.pack_no,(select isnull(sum(e.quantity),0) from sort_order_allot_master e where e.customer_code=b.customer_code) total_quantity
                        ,b.quantity bag_quantity,a.quantity,b.export_no,convert(varchar(100),b.order_date,23) order_date,b.batch_no,b.line_code
                        ,b.order_id,b.deliver_line_code,b.deliver_line_name,b.customer_code,b.customer_name,b.address,b.customer_order
                        ,b.customer_deliver_order,b.customer_info,a.product_code,a.product_name,b.dist_code,b.dist_name
                        from sort_order_allot_detail a left join sort_order_allot_master b on a.pack_no=b.pack_no
                        left join channel_allot c on a.channel_code=c.channel_code and a.product_code=c.product_code
                        left join handle_supply d on a.pack_no=d.pack_no and a.channel_code =d.channel_code and a.product_code=d.product_code
                        {0}
                        order by a.pack_no,c.group_no desc,c.sort_address,d.supply_batch,d.supply_id";
            return ra.DoQuery(string.Format(sql,condition)).Tables[0];
        }

        public int FindMaxPackNoInDeliverLine(int packNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select isnull(max(pack_no),0) from sort_order_allot_master where deliver_line_code=
                        (select distinct deliver_line_code from sort_order_allot_master where pack_no={0})";
            return Convert.ToInt32(ra.DoScalar(string.Format(sql, packNo)));
        }

        public void UpdateFinishTime(int packNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"update sort_order_allot_master set finish_time=getdate() where pack_no<={0} and status='02' and finish_time is null";
            ra.DoCommand(string.Format(sql, packNo));
        }

        public void UpdateStatus(string packNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"update sort_order_allot_master set start_time=getdate(),finish_time=getdate(),status='02' where pack_no<{0}";
            ra.DoCommand(string.Format(sql, packNo));
            sql = @"update sort_order_allot_master set start_time=null,finish_time=null,status='01' where pack_no>={0}";
            ra.DoCommand(string.Format(sql, packNo));
        }

        public DataTable FindOrderDate()
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select distinct order_date,batch_no from sort_order_allot_master";
            return ra.DoQuery(sql).Tables[0];
        }
    }
}

