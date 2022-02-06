using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Abstractions
{
    public interface IUserService
    {
        public Task GetUserList();
        public Task GetPostponedUserList();
        public Task GetSingleUser();
        public Task GetSingleUserError();
        public Task CreateUser();
        public Task UpdateUserByPut();
        public Task UpdateUserByPatch();
        public Task DeleteUser();
    }
}
