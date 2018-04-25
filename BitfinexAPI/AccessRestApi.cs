using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace BitfinexAPI
{
    static class AccessRestApi
    {
        const string endpointBase = "https://api.bitfinex.com";
        static HttpClient _httpClient = new HttpClient();

        public static async Task<T> InvokePublicCall<T>(string path)
        {
            string endpoint = endpointBase + path;
            var req = new HttpRequestMessage(HttpMethod.Get, endpoint);

            var res = await _httpClient.SendAsync(req);

            string data = await res.Content.ReadAsStringAsync();

            if (!res.IsSuccessStatusCode)
                throw new HttpRequestException(data);

            return JsonConvert.DeserializeObject<T>(data);
        }

        public static async Task<T> InvokeAuthenticatedCall<T>(
            BaseInfo args,
            string apiKey,
            string secretKey)
        {
            string json = JsonConvert.SerializeObject(args);
            string payload = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            var crypto = new HMACSHA384(Encoding.UTF8.GetBytes(secretKey));
            var hash = crypto.ComputeHash(Encoding.UTF8.GetBytes(payload));
            string signature = BitConverter.ToString(hash).Replace("-", "").ToLower();

            string endpoint = endpointBase + args["request"];
            var req = new HttpRequestMessage(HttpMethod.Post, endpoint);
            req.Headers.Add("X-BFX-APIKEY", apiKey);
            req.Headers.Add("X-BFX-PAYLOAD", payload);
            req.Headers.Add("X-BFX-SIGNATURE", signature);

            var res = await _httpClient.SendAsync(req);

            string data = await res.Content.ReadAsStringAsync();

            if (!res.IsSuccessStatusCode)
                throw new HttpRequestException(data);

            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
