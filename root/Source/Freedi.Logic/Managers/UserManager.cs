using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Interfaces;
using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.Logic.Managers
{
    public class UserManager: IUserManager
    {
        IUnitOfWork _uow { get; set; }
        public UserManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<OperationDetails> Create(UserViewModel userDto)
        {
            ApplicationUser user = await _uow.Users.UserManager().FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await _uow.Users.UserManager().CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // добавляем роль
                await _uow.Users.UserManager().AddToRoleAsync(user.Id, userDto.Role);
                // создаем профиль клиента
                ClientProfile clientProfile = new ClientProfile { Id = user.Id, Address = userDto.Address, Name = userDto.Name };
                _uow.Users.Create(clientProfile);
                await _uow.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }


        public async Task<ClaimsIdentity> Authenticate(UserViewModel userDto)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await _uow.Users.UserManager().FindAsync(userDto.Email, userDto.Password);
            if (user != null)
                claim = await _uow.Users.UserManager().CreateIdentityAsync(user,DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task SetInitialData(UserViewModel adminDto, List<string> roles)
        {

            foreach (string roleName in roles)
            {
                var role = await _uow.Users.RoleManager().FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await _uow.Users.RoleManager().CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

       
    }
}
