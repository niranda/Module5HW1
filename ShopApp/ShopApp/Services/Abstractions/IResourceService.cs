using System.Threading.Tasks;

namespace ShopApp.Services.Abstractions
{
    public interface IResourceService
    {
        public Task GetResourceList();
        public Task GetSingleResource();
        public Task GetSingleResourceError();
    }
}
