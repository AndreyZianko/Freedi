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

        Task<OperationDetails> Create(UserViewModel userDto);
        Task<ClaimsIdentity> Authenticate(UserViewModel userDto);
        Task SetInitialData(UserViewModel adminDto, List<string> roles);
    } 
}
