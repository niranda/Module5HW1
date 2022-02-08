using ShopApp.Configs;

namespace ShopApp.Services.Abstractions
{
    public interface IConfigService
    {
        public Config DeserializeConfig();
    }
}
