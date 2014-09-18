﻿using Automation.Core;
using Spring.Rest.Client;
using Spring.Http.Converters;
using Spring.Http.Converters.Json;
using Spring.Http;
using Automation.Common.SRM;

namespace Automation.Plugins.AS.WCS.Rest
{
    public class RestClient
    {
        public const string httpUrl = "http://10.93.5.172:8081/";
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

        public SRMTask ApplyNewTask(string name, int travelPos,int liftPos)
        {
            var restReturn = restTemplate.GetForObject<RestReturn>(@"transport\getSrmTask\?name={name}&travelPos={travelPos}&liftPos={liftPos}", name, travelPos, liftPos);
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                return restReturn.Data;
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error(string.Format("{0}请求新任务失败，详情：{1}" ,name, restReturn.Message));
                return null;
            }
            else
            {
                return null;
            }
        }

        public bool CancelCurrentTask(string name,SRMTask task)
        {
            var restReturn = restTemplate.GetForObject<RestReturn>(@"transport\cancelTask\?taskid={taskid}",task.ID);
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                return true;
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error(string.Format("{0}取消任务失败，详情：{1}", name, restReturn.Message));
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool FinishCurrentTask(string name,SRMTask task)
        {
            var restReturn = restTemplate.GetForObject<RestReturn>(@"transport\finishTask\?taskid={taskid}&operatorName={operatorName}", task.ID, name);
            if (restReturn != null && restReturn.IsSuccess)
            {
                if (restReturn.Message != string.Empty) Logger.Info(restReturn.Message);
                return true;
            }
            else if (restReturn != null && !restReturn.IsSuccess)
            {
                Logger.Error(string.Format("{0}完成任务失败，详情：{1}", name, restReturn.Message));
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
