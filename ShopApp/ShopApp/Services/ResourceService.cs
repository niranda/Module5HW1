using System;
using System.Net.Http;
using System.Threading.Tasks;
using ShopApp.Models;
using ShopApp.Services.Abstractions;

namespace ShopApp.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IConfigService _configService;
        private readonly IHttpService _httpService;
        private readonly string _resourceUrl;
        public ResourceService(IConfigService configService, IHttpService httpService)
        {
            _configService = configService;
            _httpService = httpService;
            _resourceUrl = @"/api/unknown";
        }

        public async Task GetResourceList()
        {
            var uri = new Uri($"{_configService.DeserializeConfig().HttpService.Url}{_resourceUrl}");
            var httpMethod = HttpMethod.Get;
            await _httpService.SendAsync<ListDTO<ResourceDataDTO>>(null, uri, httpMethod);
        }

        public async Task GetSingleResource()
        {
            var uri = new Uri($"{_configService.DeserializeConfig().HttpService.Url}{_resourceUrl}/2");
            var httpMethod = HttpMethod.Get;
            await _httpService.SendAsync<ResourceDTO>(null, uri, httpMethod);
        }

        public async Task GetSingleResourceError()
        {
            var uri = new Uri($"{_configService.DeserializeConfig().HttpService.Url}{_resourceUrl}/23");
            var httpMethod = HttpMethod.Get;
            await _httpService.SendAsync<ResourceDTO>(null, uri, httpMethod);
        }
    }
}
