using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ShopApp.Services.Abstractions;
using ShopApp.Models;

namespace ShopApp.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpService _httpService;
        private readonly IConfigService _configService;
        private readonly string _userUrl;
        public UserService(IHttpService httpService, IConfigService configService)
        {
            _configService = configService;
            _httpService = httpService;
            _userUrl = @"/api/users";
        }

        public async Task GetUserList()
        {
            var uri = new Uri($"{_configService.DeserializeConfig().HttpService.Url}{_userUrl}?page=2");
            var httpMethod = HttpMethod.Get;
            await _httpService.SendAsync<ListDTO<UserDataDTO>>(null, uri, httpMethod);
        }

        public async Task GetPostponedUserList()
        {
            var uri = new Uri($"{_configService.DeserializeConfig().HttpService.Url}{_userUrl}?delay=3");
            var httpMethod = HttpMethod.Get;
            await _httpService.SendAsync<ListDTO<UserDataDTO>>(null, uri, httpMethod);
        }

        public async Task GetSingleUser()
        {
            var uri = new Uri($"{_configService.DeserializeConfig().HttpService.Url}{_userUrl}/2");
            var httpMethod = HttpMethod.Get;
            await _httpService.SendAsync<UserDTO>(null, uri, httpMethod);
        }

        public async Task GetSingleUserError()
        {
            var uri = new Uri($"{_configService.DeserializeConfig().HttpService.Url}{_userUrl}/23");
            var httpMethod = HttpMethod.Get;
            await _httpService.SendAsync<UserDTO>(null, uri, httpMethod);
        }

        public async Task CreateUser()
        {
            var uri = new Uri($"{_configService.DeserializeConfig().HttpService.Url}{_userUrl}");
            var httpMethod = HttpMethod.Post;
            var content = new UserOnAddDTO()
            {
                Name = "morpheus",
                Job = "leader"
            };
            var serializedContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            await _httpService.SendAsync<UserOnAddDTO>(serializedContent, uri, httpMethod);
        }

        public async Task UpdateUserByPut()
        {
            var uri = new Uri($"{_configService.DeserializeConfig().HttpService.Url}{_userUrl}/2");
            var httpMethod = HttpMethod.Put;
            var content = new UserOnAddDTO()
            {
                Name = "morpheus",
                Job = "zion resident"
            };
            var serializedContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            await _httpService.SendAsync<UserOnAddDTO>(serializedContent, uri, httpMethod);
        }

        public async Task UpdateUserByPatch()
        {
            var uri = new Uri($"{_configService.DeserializeConfig().HttpService.Url}{_userUrl}/2");
            var httpMethod = HttpMethod.Patch;
            var content = new UserOnAddDTO()
            {
                Name = "morpheus",
                Job = "zion resident"
            };
            var serializedContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            await _httpService.SendAsync<UserOnAddDTO>(serializedContent, uri, httpMethod);
        }

        public async Task DeleteUser()
        {
            var uri = new Uri($"{_configService.DeserializeConfig().HttpService.Url}{_userUrl}/2");
            var httpMethod = HttpMethod.Delete;
            await _httpService.SendAsync<UserOnAddDTO>(null, uri, httpMethod);
        }
    }
}
