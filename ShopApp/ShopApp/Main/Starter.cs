using System.Threading.Tasks;
using System.Collections.Generic;
using ShopApp.Services.Abstractions;

namespace StyleCop.Main
{
    public class Starter
    {
        private readonly IUserService _userService;
        private readonly IResourceService _resourceService;
        private readonly IAuthService _authService;
        private readonly ILoggerService _loggerService;

        public Starter(IUserService userService, IResourceService resourceService, IAuthService authService, ILoggerService loggerService)
        {
            _userService = userService;
            _resourceService = resourceService;
            _authService = authService;
            _loggerService = loggerService;
        }

        public async Task Run()
        {
            var list = new List<Task>();
            list.Add(_userService.GetSingleUser());
            list.Add(_userService.GetUserList());
            list.Add(_userService.GetSingleUserError());
            list.Add(_resourceService.GetResourceList());
            list.Add(_resourceService.GetSingleResource());
            list.Add(_resourceService.GetSingleResourceError());
            list.Add(_userService.CreateUser());
            list.Add(_userService.UpdateUserByPut());
            list.Add(_userService.UpdateUserByPatch());
            list.Add(_userService.DeleteUser());
            list.Add(_authService.OnSuccessfulRegister());
            list.Add(_authService.OnUnsuccessfulRegister());
            list.Add(_authService.OnSuccessfulLogin());
            list.Add(_authService.OnUnsuccessfulLogin());
            list.Add(_userService.GetPostponedUserList());

            await Task.WhenAll(list);
            _loggerService.CompletedMessage();
        }
    }
}
