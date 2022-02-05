using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopApp.Configs;

namespace ShopApp.Services.Abstractions
{
    public interface IConfigService
    {
        public Config DeserializeConfig();
    }
}
