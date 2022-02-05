using System;
using ShopApp.Models;
using ShopApp.Services.Abstractions;
using ShopApp.Helpers;

namespace StyleCop.Main
{
    public class Starter
    {
        private readonly IUserService _userService;
        private readonly IResourceService _resourceService;

        public Starter(IUserService userService, IResourceService resourceService)
        {
            _userService = userService;
            _resourceService = resourceService;
        }

        public void Run()
        {
            _userService.GetSingleUser();
            _userService.GetUserList();
            _userService.GetSingleUserError();

            _resourceService.GetResourceList();
            _resourceService.GetSingleResource();
            _resourceService.GetSingleResourceError();

            _userService.CreateUser();

            Console.ReadKey();
        }
    }
}
