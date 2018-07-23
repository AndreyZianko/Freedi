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

        Task<OperationDetails> Create(UserView userDto);
        Task<ClaimsIdentity> Authenticate(UserView userDto);
        Task SetInitialData(UserView adminDto, List<string> roles);
    } 
}
