﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using ShopApp.Services.Abstractions;

namespace ShopApp.Services.Abstractions
{
    public interface IHttpService
    {
        public Task SendAsync<T>(StringContent httpContent, Uri uri, HttpMethod httpMethod);
    }
}
