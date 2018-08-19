using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Identity;
using Freedi.DataProvider.Repositories;

namespace Freedi.DataProvider.Interfaces
{
    public interface IClientRepository : IRepository<ClientRepository>
    {
        void Create(ClientProfile item);

        ApplicationUserManager UserManager();
        ApplicationRoleManager RoleManager();
    }
}