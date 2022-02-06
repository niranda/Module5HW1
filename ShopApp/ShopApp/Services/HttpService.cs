using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopApp.Services.Abstractions;

namespace ShopApp.Services
{
    public class HttpService : IHttpService
    {
        public async Task SendAsync<T>(StringContent httpContent, Uri uri, HttpMethod httpMethod)
        {
            using (var httpClient = new HttpClient())
            {
                var httpMessage = new HttpRequestMessage();
                httpMessage.Content = httpContent;
                httpMessage.RequestUri = uri;
                httpMessage.Method = httpMethod;

                var result = await httpClient.SendAsync(httpMessage);

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("Error 404");
                    var content = await result.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<T>(content);
                    return;
                }

                if (result.StatusCode == HttpStatusCode.BadRequest)
                {
                    Console.WriteLine("Something went wrong. Error 400");
                    return;
                }

                if (result.StatusCode == HttpStatusCode.NoContent)
                {
                    Console.WriteLine("Deleted successfully");
                    return;
                }

                if (result.StatusCode == HttpStatusCode.OK || result.StatusCode == HttpStatusCode.Created)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<T>(content);
                    Console.WriteLine($"Query Completed, status code: {result.StatusCode.ToString()}");
                }
            }
        }
    }
}
