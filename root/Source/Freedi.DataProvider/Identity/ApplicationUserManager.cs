using Freedi.DataProvider.Entites;
using Microsoft.AspNet.Identity;

namespace Freedi.DataProvider.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
    }
}