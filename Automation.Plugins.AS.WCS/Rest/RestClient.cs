using Automation.Core;
using Spring.Rest.Client;
using Spring.Http.Converters;
using Spring.Http.Converters.Json;
using Spring.Http;
using Automation.Common.SRM;

namespace Automation.Plugins.AS.WCS.Rest
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

        public SRMTask ApplyNewTask()
        {
            var restReturn = restTemplate.GetForObject<RestReturn<SRMTask>>(@"supply\assignTaskOriginPositionAddress");
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                return restReturn.Data;
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error("分配补货任务出库位置失败，详情：" + restReturn.Message);
                return null;
            }
            else
            {
                return null;
            }
        }

        public bool CancelCurrentTask(SRMTask task)
        {
            var restReturn = restTemplate.GetForObject<RestReturn>(@"supply\checkSupplyPositionStorage");
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                return true;
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error("检查拆盘位置库存失败，详情：" + restReturn.Message);
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool FinishCurrentTask(SRMTask task)
        {
            var restReturn = restTemplate.GetForObject<RestReturn>(@"supply\checkSupplyPositionStorage");
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                return false;
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error("检查拆盘位置库存失败，详情：" + restReturn.Message);
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
