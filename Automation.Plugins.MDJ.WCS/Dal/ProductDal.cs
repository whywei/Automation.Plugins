using System;
using DBRabbit;
using System.Data;
using Automation.Core.Util;

namespace Automation.Plugins.MDJ.WCS.Dal
{
    [Serializable]
    class ProductDal : AbstractBaseDal
    {
        public int GetProductNo(string barcode)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select product_no 
                                            from wms_product a
	                                            left join wcs_product_size b 
		                                            on a.product_code = b.product_code
                                            where a.piece_barcode = '{0}'", barcode);
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r));            
        }

        public bool Exist(string barcode)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format("select count(*) from  wms_product  where piece_barcode = '{0}'", barcode);
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r)) != 0;
        }

        public DataTable FindProduct(string productCode)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select product_code,product_name,piece_barcode 
                from wms_product where product_code like '%{0}%'", productCode);
            var set = ra.DoQuery(sql);
            if (set.Tables.Count == 1)
            {
                return ra.DoQuery(sql).Tables[0];
            }
            return null;
        }

        public void UpdateBarcode(string productCode, string barcode)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"update wms_product set piece_barcode ='{0}' 
                where product_code like '%{1}%'", barcode, productCode);
            ra.DoCommand(sql);
        }

        public CigaretteScanInfo FindProductForScan(string productCode)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select b.piece_barcode,a.product_no,a.area_no,a.size_no,a.length,a.width,a.height 
                                            from wcs_product_size a 
                                            left join wms_product b on a.product_code = b.product_code
                                            where a.product_code = '{0}'", productCode);
            var set = ra.DoQuery(sql);
            if (set.Tables.Count == 1 && set.Tables[0].Rows.Count == 1)
            {
                CigaretteScanInfo info = new CigaretteScanInfo();
                info.ProductNo = Convert.ToInt32(ra.DoQuery(sql).Tables[0].Rows[0]["product_no"]);
                info.Barcode =  ra.DoQuery(sql).Tables[0].Rows[0]["piece_barcode"].ToString();
                info.AreaNo = Convert.ToInt32(ra.DoQuery(sql).Tables[0].Rows[0]["area_no"]);
                info.SizeNo = Convert.ToInt32(ra.DoQuery(sql).Tables[0].Rows[0]["size_no"]);
                info.Length = Convert.ToInt32(ra.DoQuery(sql).Tables[0].Rows[0]["length"]);
                info.Width = Convert.ToInt32(ra.DoQuery(sql).Tables[0].Rows[0]["width"]);
                info.Height = Convert.ToInt32(ra.DoQuery(sql).Tables[0].Rows[0]["height"]);
                return info;
            }
            return null;
        }
    }
}
