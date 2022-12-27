using ConnectorGIS_GMP.ApiClient.Model.Request;
using ConnectorGIS_GMP.ApiClient.Model.Response;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace ConnectorGIS_GMP.ApiClient
{
    /// <summary>
    /// Типизированый клиент GisGmpClient
    /// </summary>
    public class GisGmpClient
    {
        private readonly HttpClient _client;

        private static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            //PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true,
        };

        //NOTE: API KEY
        private readonly string _key = "";

        public GisGmpClient(HttpClient сlient)
        {
            _client = сlient;
        }

        public async Task<CheckPayResponse?> Search(CheckPayRequest request)
        {
            try
            {
                request.Hash = CreateMD5Hash($"{request.Id}.{request.Top}.{_key}");

                string requestUrl = $"{_client.BaseAddress}/checkPay";
                string requestData = JsonSerializer.Serialize(request, JsonSerializerOptions);
                HttpRequestMessage message = new(HttpMethod.Post, requestUrl)
                {
                    Content = new StringContent(requestData),
                };
                message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json")
                {
                    CharSet = Encoding.UTF8.WebName
                };

                HttpResponseMessage response = _client.SendAsync(message).Result;
                response.EnsureSuccessStatusCode();

                string responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"Найденные начисления: {responseContent}");

                CheckPayResponse res = JsonSerializer.Deserialize<CheckPayResponse>(responseContent, JsonSerializerOptions);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex}");
                return null;
            }
        }

        private static string CreateMD5Hash(string data)
        {
            byte[] hash = MD5.HashData(Encoding.UTF8.GetBytes(data));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
