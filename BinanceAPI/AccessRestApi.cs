using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BinanceAPI
{
    enum SecurityType
    {
        NONE,
        TRADE,
        USER_DATA,
        USER_STREAM,
        MARKET_DATA,
    }

    enum InvokeMethod
    {
        GET,
        DELETE,
        POST,
        PUT
    }

    static class AccessRestApi
    {
        const string endpointBase = "https://api.binance.com";

        static HttpClient _httpClient;
        static TimeSpan _offset;

        static AccessRestApi()
        {
            _httpClient = new HttpClient();
            _offset = DateTime.UtcNow - GetServerTime().Result;
        }

        static async Task<DateTime> GetServerTime()
        {
            string info = await (await _httpClient.GetAsync(endpointBase + "/api/v1/time"))
                .Content.ReadAsStringAsync();

            return ConvertHelper.ConvertServerTime(info);
        }

        static string Crypto(string endpoint, string secretKey)
        {
            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
            var totalParams = new Uri(endpoint).Query.Substring(1);

            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(totalParams));

            var signature = BitConverter.ToString(hash).Replace("-", "");
            return signature;
        }

        public static async Task<T> InvokeHttpCall<T>(
            string args,
            InvokeMethod method,
            SecurityType token,
            string apiKey,
            string secretKey)
        {
            string endpoint = endpointBase + args;
            if (token == SecurityType.TRADE || token == SecurityType.USER_DATA)
            {
                endpoint += "&recvWindow=5000";

                long timestamp = JsTimeConverter.TimeToMs(DateTime.UtcNow - _offset);
                endpoint += "&timestamp=" + timestamp.ToString();

                var signature = Crypto(endpoint, secretKey);
                endpoint += "&signature=" + signature;
            }

            if (_httpClient.DefaultRequestHeaders.Contains("X-MBX-APIKEY"))
                _httpClient.DefaultRequestHeaders.Remove("X-MBX-APIKEY");

            if (token != SecurityType.NONE)
                _httpClient.DefaultRequestHeaders.Add("X-MBX-APIKEY", apiKey);

            HttpResponseMessage res;
            switch (method)
            {
                case InvokeMethod.GET:
                    res = await _httpClient.GetAsync(endpoint);
                    break;
                case InvokeMethod.DELETE:
                    res = await _httpClient.DeleteAsync(endpoint);
                    break;
                case InvokeMethod.POST:
                    res = await _httpClient.PostAsync(endpoint, null);
                    break;
                case InvokeMethod.PUT:
                    res = await _httpClient.PutAsync(endpoint, null);
                    break;
                default:
                    res = null;
                    break;
            }

            string data = await res.Content.ReadAsStringAsync();

            if (!res.IsSuccessStatusCode)
                throw new HttpRequestException(data);

            return ConvertHelper.DataConvert<T>(data);
        }
    }
}
