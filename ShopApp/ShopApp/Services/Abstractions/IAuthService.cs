using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Abstractions
{
    public interface IAuthService
    {
        public Task OnSuccessfulRegister();
        public Task OnUnsuccessfulRegister();
        public Task OnSuccessfulLogin();
        public Task OnUnsuccessfulLogin();
    }
}
