using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace ShopApp.Services.Abstractions
{
    public interface IHttpService
    {
        public Task<T> SendAsync<T>(object httpContent, Uri uri, HttpMethod httpMethod);
    }
}
