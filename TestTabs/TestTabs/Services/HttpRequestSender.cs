using System;
using System.Net;
using System.Text;
using System.Text.Json;

namespace TestTabs.Services
{
	public class HttpRequestSender : IHttpRequestSender
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        static readonly HttpClient _client = new HttpClient() { Timeout = TimeSpan.FromMinutes(1) };

        public Task<(TReturn Result, bool Success)> GetAsync<TReturn>(string endpoint)
        {
            return SendAsync<TReturn>(endpoint, HttpMethod.Get);
        }

        private async Task<(TReturn Result, bool Success)> SendAsync<TReturn>(string endpoint, HttpMethod method, string body = null)
        {
            bool isSuccess = false;

            var result = default(TReturn);

            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Version = HttpVersion.Version20;

                    request.RequestUri = new Uri(endpoint);
                    request.Method = method;

                    if (body != null)
                    {
                        request.Content = new StringContent(body, Encoding.UTF8, "application/json");
                    }

                    using (var response = await _client.SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var str = await response.Content.ReadAsStringAsync();
                            var reee = JsonSerializer.Deserialize<TReturn>(str, _jsonOptions);

                            var responseStream = await response.Content.ReadAsStreamAsync();
                            result = await JsonSerializer.DeserializeAsync<TReturn>(responseStream, _jsonOptions);

                            isSuccess = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: log
            }

            return (result, isSuccess);
        }
    }
}

