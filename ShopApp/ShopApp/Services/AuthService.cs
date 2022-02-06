using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopApp.Models;
using ShopApp.Services.Abstractions;

namespace ShopApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpService _httpService;
        private readonly IConfigService _configService;
        private string _userUrl;
        public AuthService(IHttpService httpService, IConfigService configService)
        {
            _configService = configService;
            _httpService = httpService;
            _userUrl = @"/api/register";
        }

        public async Task OnSuccessfulRegister()
        {
            var uri = new Uri($"{_configService.DeserializeConfig().HttpService.Url}{_userUrl}");
            var httpMethod = HttpMethod.Post;
            var content = new UserOnAuthDTO()
            {
                Email = "eve.holt@reqres.in",
                Password = "pistol"
            };
            var serializedContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            await _httpService.SendAsync<UserOnAuthDTO>(serializedContent, uri, httpMethod);
        }

        public async Task OnUnsuccessfulRegister()
        {
            var uri = new Uri($"{_configService.DeserializeConfig().HttpService.Url}{_userUrl}");
            var httpMethod = HttpMethod.Post;
            var content = new UserOnAuthDTO()
            {
                Email = "sydney@fife"
            };
            var serializedContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            await _httpService.SendAsync<UserOnAuthDTO>(serializedContent, uri, httpMethod);
        }

        public async Task OnSuccessfulLogin()
        {
            _userUrl = @"/api/login";
            var uri = new Uri($"{_configService.DeserializeConfig().HttpService.Url}{_userUrl}");
            var httpMethod = HttpMethod.Post;
            var content = new UserOnAuthDTO()
            {
                Email = "eve.holt@reqres.in",
                Password = "cityslicka"
            };
            var serializedContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            await _httpService.SendAsync<UserOnAuthDTO>(serializedContent, uri, httpMethod);
        }

        public async Task OnUnsuccessfulLogin()
        {
            _userUrl = @"/api/login";
            var uri = new Uri($"{_configService.DeserializeConfig().HttpService.Url}{_userUrl}");
            var httpMethod = HttpMethod.Post;
            var content = new UserOnAuthDTO()
            {
                Email = "peter@klaven"
            };
            var serializedContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            await _httpService.SendAsync<UserOnAuthDTO>(serializedContent, uri, httpMethod);
        }
    }
}
