using Freedi.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.Logic.Interfaces
{
    public interface IUserManager
    {

        Task<OperationDetails> Create(UserViewModel userViewModel);
        Task<ClaimsIdentity> Authenticate(UserViewModel userViewModel);
        Task SetInitialData(UserViewModel adminViewModel, List<string> roles);
    } 
}
