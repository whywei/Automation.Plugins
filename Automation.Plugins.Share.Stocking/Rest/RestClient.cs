using System.Data;
using Automation.Core;
using Spring.Rest.Client;
using Spring.Http.Converters;
using Spring.Http.Converters.Json;
using Spring.Http;

namespace Automation.Plugins.Share.Stocking.Rest
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

        public void AssignTaskOriginPositionAddress()
        {
            var restReturn = restTemplate.GetForObject<RestReturn>(@"supply\assignTaskOriginPositionAddress");
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error("分配补货任务出库位置失败，详情：" + restReturn.Message);
            }
        }

        public void CheckSupplyPositionStorage()
        {
            var restReturn = restTemplate.GetForObject<RestReturn>(@"supply\checkSupplyPositionStorage");
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error("检查拆盘位置库存失败，详情：" + restReturn.Message);
            }
        }
    }
}
