using System;
using Spring.Http;
using Spring.Http.Converters.Xml;
using Spring.Rest.Client;
using Spring.Http.Converters;
using Spring.Http.Converters.Json;
using Automation.Core;
using System.Xml;

namespace Automation.Plugins.MDJ.WCS.Rest
{
    public class RestClient
    {
        public const string httpUrl = "http://10.57.64.171:8080/TaskRest/";

        private RestTemplate restTemplate;

        public RestTemplate RestTemplate
        {
            get { return this.restTemplate; }
        }

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

        public bool CreateNewTaskForEmptyPalletStack(string positionName)
        {
            var restReturn = restTemplate.GetForObject<RestReturn>("CreateNewTaskForEmptyPalletStack/?positionName={p}", positionName);
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                return true;
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error("生成空托盘回收任务失败，详情：" + restReturn.Message);
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool CreateNewTaskForEmptyPalletSupply(string positionName)
        {
            var restReturn = restTemplate.GetForObject<RestReturn>("CreateNewTaskForEmptyPalletSupply/?positionName={p}", positionName);
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                return true;
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error("生成空托盘补货任务失败，详情：" + restReturn.Message);
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool CreateNewTaskForMoveBackRemain(int taskID)
        {
            var restReturn = restTemplate.GetForObject<RestReturn>("CreateNewTaskForMoveBackRemain/?taskID={p}", taskID);
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                return true;
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error("生成小品种或异型烟余烟回库任务失败，详情：" + restReturn.Message);
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool FinishTask(int taskID)
        {
            var restReturn = restTemplate.GetForObject<RestReturn>("FinishTaskUseTaskID/?taskID={taskID}", taskID);
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                return true;
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error("完成任务失败，详情：" + restReturn.Message);
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool FinishTask(int taskID, string orderType, string orderID, int allotID,string originCellCode, string targetCellCode, string originStorageCode, string targetStorageCode)
        {
            var restReturn = restTemplate.GetForObject<RestReturn>("FinishTask/?taskID={taskID}&orderType={orderType}&orderID={orderID}&allotID={allotID}&originCellCode={originCellCode}&targetCellCode={targetCellCode}&originStorageCode={originStorageCode}&targetStorageCode={targetStorageCode}", taskID, orderType, orderID, allotID, originCellCode, targetCellCode, originStorageCode, targetStorageCode);
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                return true;
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error("完成任务失败，详情：" + restReturn.Message);
                return false;
            }
            else
            {
                return false;
            }
        }

        public int FinishInventoryTask(int taskID, int realQuantity)
        {
            var restReturn = restTemplate.GetForObject<RestReturn>("FinishInventoryTask/?taskID={taskID}&realQuantity={realQuantity}", taskID, realQuantity);
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                return Convert.ToInt32(restReturn.Data);
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error("完成盘点任务失败，详情：" + restReturn.Message);
                return 0;
            }
            else
            {
                return 0;
            }
        }

        public int FinishStockOutTask(int taskID, int stockOutQuantity)
        {
            var restReturn = restTemplate.GetForObject<RestReturn>("FinishStockOutTask/?taskID={taskID}&stockOutQuantity={stockOutQuantity}", taskID, stockOutQuantity);
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                return Convert.ToInt32(restReturn.Data);
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error("完成出库任务失败，详情：" + restReturn.Message);
                return 0;
            }
            else
            {
                return 0;
            }
        }

        public bool AutoCreateMoveBill()
        {
            var restReturn = restTemplate.GetForObject<RestReturn>("AutoCreateMoveBill");
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                return true;
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error("自动生成补大品种拆盘位移库单失败，详情：" + restReturn.Message);
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool CreateAutoMoveCell()
        {
            var restReturn = restTemplate.GetForObject<RestReturn>("CreateAutoMoveCell");
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                return true;
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error("自动生成同品牌货位调整移库单失败，详情：" + restReturn.Message);
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
