using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Interfaces;
using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;
using Microsoft.AspNet.Identity;

namespace Freedi.Logic.Managers
{
    public class UserManager : IUserManager
    {
        public UserManager(IUnitOfWork uow, IClientRepository clientRepository)
        {
            _uow = uow;
            _clientRepository = clientRepository;
        }

        private IUnitOfWork _uow { get; }
        private IClientRepository _clientRepository { get; }

        public async Task<OperationDetails> Create(UserViewModel userDto)
        {
            var user = await _clientRepository.UserManager().FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser {Email = userDto.Email, UserName = userDto.Email};
                var result = await _clientRepository.UserManager().CreateAsync(user, userDto.Password);
                if (result.Errors.Any())
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                await _clientRepository.UserManager().AddToRoleAsync(user.Id, userDto.Role);
                var clientProfile = new ClientProfile {Id = user.Id, Address = userDto.Address, Name = userDto.Name};
                _clientRepository.Create(clientProfile);
                await _uow.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }

            return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
        }


        public async Task<ClaimsIdentity> Authenticate(UserViewModel userDto)
        {
            ClaimsIdentity claim = null;
            var user = await _clientRepository.UserManager().FindAsync(userDto.Email, userDto.Password);
            if (user != null)
                claim = await _clientRepository.UserManager()
                    .CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task SetInitialData(UserViewModel adminDto, List<string> roles)
        {
            foreach (var roleName in roles)
            {
                var role = await _clientRepository.RoleManager().FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole {Name = roleName};
                    await _clientRepository.RoleManager().CreateAsync(role);
                }
            }

            await Create(adminDto);
        }
    }
}