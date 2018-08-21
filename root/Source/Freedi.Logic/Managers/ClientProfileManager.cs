using Freedi.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Interfaces;
using Freedi.Model.ViewModels;

namespace Freedi.Logic.Managers
{
    public class ClientProfileManager : IClientProfileManager
    {
        private readonly IClientRepository _clientRepository;
        public ClientProfileManager(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
    
        public ClientProfileViewModel GetProfile(string userid)
        {
           var repProfile = _clientRepository.GetClientProfile(userid);
            ClientProfileViewModel profile = new ClientProfileViewModel
            {
                Name = repProfile.Name,
                Address = repProfile.Address
            };
            return profile;
        }
    }
}
