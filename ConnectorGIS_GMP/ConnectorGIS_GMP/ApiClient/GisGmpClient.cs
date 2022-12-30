using ConnectorGIS_GMP.ApiClient.Model.Request;
using ConnectorGIS_GMP.ApiClient.Model.Response;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

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
                request.Hash = CreateMD5Hash($"{request.Id}{request.Top}{_key}");

                string requestUrl = $"{_client.BaseAddress}";
                var data = GeneratePostForm(request);
                HttpRequestMessage message = new(HttpMethod.Post, requestUrl)
                {
                    Content = new FormUrlEncodedContent(data),
                };

                HttpResponseMessage response = _client.SendAsync(message).Result;
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"Найденные начисления: {Regex.Unescape(responseContent)}");

                CheckPayResponse res = JsonSerializer.Deserialize<CheckPayResponse>(Regex.Unescape(responseContent), JsonSerializerOptions);
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

        private Dictionary<string, string> GeneratePostForm(CheckPayRequest request)
        {
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                ["top"] = request.Top.ToString(),
                ["id"] = request.Id,
                ["hash"] = request.Hash,
                ["type"] = request.Type.ToString(),
                ["sts"] = request.Sts,
                ["paid"] = request.Paid.ToString(),
                ["inn"] = request.Inn,
                ["snils"] = request.Snils,
                ["vu"] = request.Vu,
                ["num"] = request.Num,
                ["pasp"] = request.Pasp,
                ["ind"] = request.Ind,
            };

            return data;
        }
    }
}
