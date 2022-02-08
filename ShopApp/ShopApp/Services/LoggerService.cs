using System;
using ShopApp.Services.Abstractions;

namespace ShopApp.Services
{
    public class LoggerService : ILoggerService
    {
        public void RequestMessage(object statusCode)
        {
            Console.WriteLine($"Request status code: {statusCode}");
        }

        public void CompletedMessage()
        {
            Console.WriteLine("Done");
        }
    }
}
