using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Freedi.DataProvider.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
        public virtual ICollection<Order> Order { get; set; } = new HashSet<Order>();
    }
}