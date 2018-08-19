using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Freedi.Model.ViewModels;

namespace Freedi.Logic.Interfaces
{
    public interface IUserManager
    {
        Task<OperationDetails> Create(UserViewModel userViewModel);
        Task<ClaimsIdentity> Authenticate(UserViewModel userViewModel);
        Task SetInitialData(UserViewModel adminViewModel, List<string> roles);
    }
}