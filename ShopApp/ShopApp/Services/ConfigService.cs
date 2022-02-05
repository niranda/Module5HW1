using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ShopApp.Services.Abstractions;
using Newtonsoft.Json;
using ShopApp.Configs;

namespace ShopApp.Services
{
    public class ConfigService : IConfigService
    {
        public Config DeserializeConfig()
        {
            var configFile = File.ReadAllText("Configs/config.json");
            var config = JsonConvert.DeserializeObject<Config>(configFile);
            return config!;
        }
    }
}
