using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Apteka.Utils
{
    public static class CRest
    {
        public static async Task<TReturn> Post<TParam, TReturn>(this string url, TParam param) where TParam : class
        {
            try
            {
                var c = new HttpClient();
                var ServerUrl = ConfigurationManager.AppSettings["ServerUrl"];
                c.BaseAddress = new Uri(ServerUrl);
                c.DefaultRequestHeaders.Accept.Clear();
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var cd = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
                var response = await c.PostAsync(url, cd);

                if (response.IsSuccessStatusCode)
                {
                    var searchResult = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TReturn>(searchResult);
                }
                else
                {                    
                    var li = new LogItem
                    {
                        App = "Apteka.Utils",                        
                        Message = $"Алоқада хато => {response.StatusCode} {response.ReasonPhrase}",
                        Url = url,
                        Method = "CRest.Get"
                    };
                    CLogJson.Write(li);
                    throw new Exception(li.Message);
                }                
            }
            catch (Exception ee)
            {
                var li = new LogItem
                {
                    App = "Apteka.Utils",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Url = url,
                    Method = "CRest.Get"
                };
                CLogJson.Write(li);
                throw new Exception(li.Message);
            }

        }


        public static async Task<T> Get<T>(this string url) where T : class
        {
            try
            {
                var c = new HttpClient();
                var ServerUrl = ConfigurationManager.AppSettings["ServerUrl"];
                c.BaseAddress = new Uri(ServerUrl);
                c.DefaultRequestHeaders.Accept.Clear();
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                
                var response = await c.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var searchResult = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(searchResult);
                }
                else
                {
                    var li = new LogItem
                    {
                        App = "Apteka.Utils",
                        Message = $"Алоқада хато => {response.StatusCode} {response.ReasonPhrase}",
                        Url = url,
                        Method = "CRest.Get"
                    };
                    CLogJson.Write(li);
                    throw new Exception(li.Message);
                }
            }
            catch (Exception ee)
            {
                var li = new LogItem
                {
                    App = "Apteka.Utils",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Url = url,
                    Method = "CRest.Get"
                };
                CLogJson.Write(li);
                throw new Exception(li.Message);
            }
        }

        public static async Task<T> DownloadFile<T>(this string url) where T : class
        {
            try
            {
                var c = new HttpClient();
                var ServerUrl = ConfigurationManager.AppSettings["ServerUrl"];
                c.BaseAddress = new Uri(ServerUrl);
                c.DefaultRequestHeaders.Accept.Clear();
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await c.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var searchResult = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(searchResult);
                }
                else
                {
                    var li = new LogItem
                    {
                        App = "Apteka.Utils",
                        Message = $"Алоқада хато => {response.StatusCode} {response.ReasonPhrase}",
                        Url = url,
                        Method = "CRest.Get"
                    };
                    CLogJson.Write(li);
                    throw new Exception(li.Message);
                }
            }
            catch (Exception ee)
            {
                var li = new LogItem
                {
                    App = "Apteka.Utils",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Url = url,
                    Method = "CRest.Get"
                };
                CLogJson.Write(li);
                throw new Exception(li.Message);
            }

        }
    }
}
