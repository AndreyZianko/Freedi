using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
namespace Freedi.DataProvider
{
    public class FreediContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ClientProfile> ClientProfiles { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }

        static FreediContext()
        {

            Database.SetInitializer<FreediContext>(new StoreDbInitializer());
        }


        public FreediContext()
            : base("name = FreediConnection")
        {
        }
    }

    public class StoreDbInitializer : CreateDatabaseIfNotExists<FreediContext>
    {
        protected override void Seed(FreediContext context)
        {

            context.Goods.Add(new Goods { Name = "Leather Bag", Sex = "Women", Type = "Bag", Price = 220, Currency = "USD", Description = "Very beautiful bag", SKU = "LB220", Stock = true, StockQuantity = 11, Unit = "pieces" });
            context.SaveChanges();
        }
    }
}

