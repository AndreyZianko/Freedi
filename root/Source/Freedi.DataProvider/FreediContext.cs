using System.Data.Entity;
using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Migrations;
using Freedi.DataProvider.Models;
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

    //    class StoreDbInitializer : MigrateDatabaseToLatestVersion<FreediContext, Configuration>
    //{
    //    protected override void Seed(FreediContext context)
    //    {
    //        context.Goods.Add(new Goods
    //        {
    //            Name = "Leather Bag",
    //            Sex = "Women",
    //            Type = "Bag",
    //            Price = 220,
    //            Currency = "USD",
    //            Description = "Very beautiful bag",
    //            Stock = true,
    //            StockQuantity = 11

    //        });
    //        context.SaveChanges();
    //    }
    //}
}