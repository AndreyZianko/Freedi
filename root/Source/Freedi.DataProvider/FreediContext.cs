using Freedi.DataProvider.Models;
using System.Data.Entity;
namespace Freedi.DataProvider
{
    public class FreediContext : DbContext
    {

        public DbSet<Goods> Goods { get; set; }
        public DbSet<Order> Orders { get; set; }
        static FreediContext()
        {

            Database.SetInitializer<FreediContext>(new StoreDbInitializer());
        }
        public FreediContext()
            : base("name = FreediConnection")
        {

        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<FreediContext>
    {
        protected override void Seed(FreediContext db)
        {
            db.Goods.Add(new Goods { Name = "Leather Bag", Sex = "Women", Type = "Bag", Price = 220, Currency = "USD", Description = "Very beautiful bag", Photo = "/Content/TemplateImages/product_4.png", SKU = "LB220", Stock = true, StockQuantity = 11, Unit = "pieces" });
            db.SaveChanges();
        }
    }
}

