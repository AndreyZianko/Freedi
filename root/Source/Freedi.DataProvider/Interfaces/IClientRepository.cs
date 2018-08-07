using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Identity;
using Freedi.DataProvider.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.DataProvider.Interfaces
{
    public interface IClientRepository : IRepository<ClientRepository>
    {
        void Create(ClientProfile item);
        
        ApplicationUserManager UserManager();
        ApplicationRoleManager RoleManager();
    }
}
