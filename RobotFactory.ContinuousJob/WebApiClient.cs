using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RobotFactory.ContinuousJob
{
    internal class WebApiClient
    {
        private static string GetAppSetting(string key, string defaultValue)
        {
            var config = ConfigurationManager.AppSettings[key];

            if (config == null)
                return defaultValue;
            else
                return config;
        }

        public static string GetApiBaseUrl()
        {
            return GetAppSetting("RobotFactoryApiBaseUrl", "http://localhost:44758");
        }

        private static HttpClient GetWebApiClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(GetApiBaseUrl());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        internal static async void UpdateRobotStatus(string robotName, int value)
        {
            using (var client = GetWebApiClient())
            {
                await client.GetAsync(
                    string.Format("robot/charge/{0}/{1}", robotName, value)
                    );
            }
        }

        internal static async void RechargeRobot(string robotName)
        {
            using (var client = GetWebApiClient())
            {
                await client.GetAsync(
                    string.Format("robot/recharge/{0}", robotName)
                    );
            }
        }
    }
}
