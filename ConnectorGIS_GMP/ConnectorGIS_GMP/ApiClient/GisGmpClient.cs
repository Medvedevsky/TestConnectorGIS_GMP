using ConnectorGIS_GMP.ApiClient.Model.Request;
using ConnectorGIS_GMP.ApiClient.Model.Response;
using ConnectorGIS_GMP.Converters;
using System.Reflection;
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
            Converters = { new DateTimeConverter() }
        };

        //NOTE: API KEY
        private static readonly string _key = "";

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

                CheckPayResponse res = JsonSerializer.Deserialize<CheckPayResponse>(Regex.Unescape(responseContent), JsonSerializerOptions)!;
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

        private static Dictionary<string, string> GeneratePostForm(CheckPayRequest request)
        {
            if (request is null) 
                throw new ArgumentNullException($"Параметра метода {nameof(GeneratePostForm)} является null");

            var result = new Dictionary<string, string>();
            Type type = typeof(CheckPayRequest);

            // NOTE: заполняем модель данных полями, которые имеют значения
            foreach (PropertyInfo p in type.GetProperties())
            {
                object value = p.GetValue(request)!;
                string a = p.Name;

                if (value is not null && string.IsNullOrEmpty(value.ToString()) == false)
                {
                    result.Add(p.Name.ToLower(), value.ToString()!);
                }
            }

            return result;
        }
    }
}
