using System.Data.Entity;
using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using Photos = Freedi.DataProvider.Entites.Photos;

namespace Freedi.DataProvider
{
    public class FreediContext : IdentityDbContext<ApplicationUser>
    {
        static FreediContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FreediContext, Configuration>(true));
        }


        public FreediContext()
            : base("name = FreediConnection")
        {
        }

        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ClientProfile> ClientProfiles { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
    }

  
}