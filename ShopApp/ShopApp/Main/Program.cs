using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShopApp.Services.Abstractions;
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
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<ILoggerService, LoggerService>()
                .AddTransient<IConfigService, ConfigService>()
                .AddTransient<Starter>()
                .BuildServiceProvider();

            var start = serviceProvider.GetService<Starter>();
            Task.Run(async () =>
            {
                await start.Run();
            });

            Console.ReadKey();
        }
    }
}
