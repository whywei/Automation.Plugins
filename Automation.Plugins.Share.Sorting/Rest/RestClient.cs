﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Http.Converters;
using Spring.Rest.Client;
using Spring.Http.Converters.Json;
using Spring.Http;
using Automation.Plugins.Share.Sorting.Dal;
using System.Data;
using Automation.Core;

namespace Automation.Plugins.Share.Sorting.Rest
{
    public class RestClient
    {
        public const string httpUrl = "http://10.57.64.171:8080/";
        private RestTemplate restTemplate;

        public RestClient(string url = null)
        {
            string BaseUrl = string.Empty;
            var httpUrl = Properties.Settings.Default.HttpUrl;
            if (!string.IsNullOrEmpty(httpUrl))
            {
                BaseUrl = httpUrl;
            }
            else
            {
                BaseUrl = RestClient.httpUrl;
                Properties.Settings.Default.HttpUrl = RestClient.httpUrl;
                Properties.Settings.Default.Save();
            }

            BaseUrl = url ?? BaseUrl;

            restTemplate = new RestTemplate(BaseUrl);
            IHttpMessageConverter jsonConverter = new DataContractJsonHttpMessageConverter();
            jsonConverter.SupportedMediaTypes.Add(MediaType.APPLICATION_JSON);
            restTemplate.MessageConverters.Add(jsonConverter);
        }

        public void CreateSupplyTask(string position, int quantity)
        {
            OrderDal orderDal = new OrderDal();
            DataTable table = orderDal.FindOrderDate();
            if (table.Rows.Count > 0)
            {
                var restReturn = restTemplate.GetForObject<RestReturn>(@"supply\createSupplyTask\?positionName={positionName}&quantity={quantity}&orderdate={orderdate}&batchNo={batchNo}", position, quantity, table.Rows[0]["order_date"], table.Rows[0]["batch_no"]);
                if (restReturn != null && restReturn.IsSuccess)
                {
                    if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                }
                else if (restReturn != null && !restReturn.IsSuccess)
                {
                    Logger.Error("生成补货计划失败，详情：" + restReturn.Message);
                }
            }
        }
    }
}
