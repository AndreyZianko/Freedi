using Microsoft.AspNet.Identity.EntityFramework;

namespace Freedi.DataProvider.Entites
{
    public class ApplicationUser : IdentityUser

    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}