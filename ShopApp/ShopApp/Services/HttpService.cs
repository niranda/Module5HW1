using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopApp.Services.Abstractions;

namespace ShopApp.Services
{
    public class HttpService : IHttpService
    {
        private readonly ILoggerService _loggerService;
        public HttpService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public async Task<T> SendAsync<T>(object httpContent, Uri uri, HttpMethod httpMethod)
        {
            using (var httpClient = new HttpClient())
            {
                var httpMessage = new HttpRequestMessage();
                httpMessage.Content = (HttpContent)httpContent;
                httpMessage.RequestUri = uri;
                httpMessage.Method = httpMethod;

                var result = await httpClient.SendAsync(httpMessage);

                var content = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<T>(content);

                _loggerService.RequestMessage(result.StatusCode);

                return response;
            }
        }
    }
}
