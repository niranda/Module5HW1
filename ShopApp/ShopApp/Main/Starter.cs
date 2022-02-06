using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ShopApp.Models;
using ShopApp.Services.Abstractions;

namespace StyleCop.Main
{
    public class Starter
    {
        private readonly IUserService _userService;
        private readonly IResourceService _resourceService;
        private readonly IAuthService _authService;

        public Starter(IUserService userService, IResourceService resourceService, IAuthService authService)
        {
            _userService = userService;
            _resourceService = resourceService;
            _authService = authService;
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
            Console.WriteLine("Done");
        }
    }
}
