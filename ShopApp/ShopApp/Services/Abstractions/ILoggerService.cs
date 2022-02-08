namespace ShopApp.Services.Abstractions
{
    public interface ILoggerService
    {
        public void RequestMessage(object statusCode);
        public void CompletedMessage();
    }
}
