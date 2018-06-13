using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Cryptography;
using Newtonsoft.Json;

using BitfinexAPI;
using System.Collections.Generic;

/// <summary>
/// 这部分相当于copy了AccessRestApi的类，主要为了使用其中的方法
/// 
/// </summary>


namespace Portal
{
    static class HttpCall
    {
        //此处为部署之后的服务器地址
        const string endpointBase = "http://localhost:12345/";
        static HttpClient _httpClient = new HttpClient();


        public static async Task<T> InvokeHttpCall<T>(string path)
        {
            return await InvokeHttpCall<T>(path, null);
        }

        public static async Task<T> InvokeHttpCall<T>(
            string path, BaseInfo args)
        {
            var req = new HttpRequestMessage(HttpMethod.Post, endpointBase + path);
            string newpath = endpointBase + path;
            HttpResponseMessage res = null;
            if (args != null)
            {
                var contentDic = new Dictionary<string, string>();
                foreach (var item in args)
                {
                    contentDic[item.Key] = item.Value.ToString();
                }
                var content = new FormUrlEncodedContent(contentDic);
                req.Content = content;
                res = await _httpClient.PostAsync(newpath, content);

            }
            else
            {
                res = await _httpClient.GetAsync(newpath);
            }

            string data = await res.Content.ReadAsStringAsync();

            if (!res.IsSuccessStatusCode)
                throw new HttpRequestException(data);

            return JsonConvert.DeserializeObject<T>(data);

        }
    }

}
