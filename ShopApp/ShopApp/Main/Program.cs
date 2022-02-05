using Microsoft.Extensions.DependencyInjection;
using ShopApp.Services.Abstractions;
using ShopApp.Providers.Abstractions;
using ShopApp.Providers;
using ShopApp.Services;

namespace StyleCop.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IHttpService, HttpService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IResourceService, ResourceService>()
                .AddTransient<IConfigService, ConfigService>()
                .AddTransient<Starter>()
                .BuildServiceProvider();

            var start = serviceProvider.GetService<Starter>();
            start!.Run();
        }
    }
}
