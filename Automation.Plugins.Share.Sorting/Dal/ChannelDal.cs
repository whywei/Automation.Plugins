using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;
using Automation.Plugins.Share.Sorting.Model;

namespace Automation.Plugins.Share.Sorting.Dal
{
    public class ChannelDal : AbstractBaseDal
    {
        /// <summary>查询烟道信息</summary>
        public DataTable FindChannel()
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"select a.channel_code, a.channel_name
                                        ,case a.channel_type when '1' then '立式机(人工)' when '2' then '立式机(自动)' when '3' then '通道机'when '4' then '卧式机' else  '混合烟道' end channel_type
                                        ,a.sort_address, a.supply_address
                                        ,a.product_code, a.product_name, a.quantity, a.remain_quantity, a.group_no
                                        ,case a.status when '1' then '可用' else  '不可用' end status
                                        from channel_allot a");
            return ra.DoQuery(sql).Tables[0];
        }
        
        public void InsertChannel(DataRow row)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"insert into Channel_Allot values('{0}','{1}','{2}','{3}','{4}','{18}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')",
            row["channel_code"], row["channel_type"], row["channel_name"], row["product_code"], row["product_name"],
            row["quantity"], row["remain_quantity"], row["channel_capacity"], row["group_no"], row["order_no"],
            row["sort_address"], row["supply_address"], row["led_no"], row["x"],
            row["y"], row["width"], row["height"], row["is_active"], row["piece_barcode"]);
            ra.DoCommand(sql);
        }

        /// <summary>查询存在的烟道数组</summary>
        public string[] GetChannel()
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = "select distinct b.channel_code,b.channel_name from handle_supply a left join channel_allot b on a.channel_code=b.channel_code";
            DataTable dt = ra.DoQuery(sql).Tables[0];
            string[] array = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                array[i] = Convert.ToString(dr["channel_name"]);
            }
            return array;
        }

        /// <summary>根据烟道代码查询烟道类型和烟道组号</summary>
        public DataTable FindChannelCode(string channelCode)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format("select supply_address,channel_type,group_no from channel_allot where channel_code='{0}'", channelCode);
            return ra.DoQuery(sql).Tables[0];
        }

        /// <summary>根据烟道组号和烟道类型查询出烟道信息表</summary>
        public DataTable FindChannel(string channelCode, string channelType, int channelGroup)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"select channel_code, 
                        channel_name + ' ' + case channel_type when '2' then '立式机' when '5' then '立式机'  else '卧式机' end 
                        channel_name 
                        from channel_allot 
                        where channel_type in ('{0}') and channel_type != '5' and group_no = {1} and channel_code != '{2}'
                        order by channel_name", channelType, channelGroup, channelCode);
            return ra.DoQuery(sql).Tables[0];
        }

        /// <summary>查询烟道</summary>
        public DataTable FindChannelInfo()
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select channel_code, channel_name,
                            case channel_type when '2' then '立式机' when '5' then '立式机' else '卧式机' end channel_type, 
                            product_code, product_name, quantity 
                            from channel_allot order by channel_name";
            return ra.DoQuery(sql).Tables[0];
        }

        public void UpdateChannelByChannelCode(string channelCode, string cigaretteCode, string cigaretteName, string quantity)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"update channel_allot
                                        set product_code = '{0}',product_name = '{1}',quantity = {2}
                                        where channel_code='{3}'", cigaretteCode, cigaretteName, quantity, channelCode);
            ra.DoCommand(sql);
        }

        public int FindChannelAddressByChannelCode(string channelCode)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format("select sort_address from channel_allot where channel_code='{0}'", channelCode);
            object result = ra.DoScalar(sql);
            return result == null ? 0 : Convert.ToInt32(result);
        }

        public DataTable FindLessBarCodeChannel()
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select distinct product_code from channel_allot 
                         where len(product_code)>0 and (piece_barcode is null or len(piece_barcode)<=0)";
            return ra.DoQuery(sql).Tables[0];
        }

        public void UpdatePieceBarCode(string productCode,string pieceBarCode)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"update Channel_Allot set piece_barcode='{1}' where product_code='{0}'";
            ra.DoQuery(string.Format(sql, productCode, pieceBarCode));
        }

        public DataTable FindAllProduct()
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select distinct piece_barcode,product_name from Channel_Allot";
            return ra.DoQuery(sql).Tables[0];
        }

        public DataTable FindCigaretteChannelInfo(int groupNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select product_name,quantity,remain_quantity,sort_address,led_no,x,y,width,height
                          from channel_allot where channel_type='2' and group_no={0} order by sort_address";
            return ra.DoQuery(string.Format(sql,groupNo)).Tables[0];
        }

        public DataTable FindCigaretteChannelInfo2(int groupNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select sum(quantity) quantity,0 as remain_quantity,'混合道' product_name,sort_address,led_no,x,y,width,height
                          from channel_allot where channel_type='5' and group_no={0} 
                          group by sort_address,led_no,x,y,width,height order by sort_address";
            return ra.DoQuery(string.Format(sql, groupNo)).Tables[0];
        }
    }
}
