using Freedi.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Freedi.DataProvider
{
    public class FreediContext : DbContext
    {
       
        public DbSet<Good> Goods { get; set; }
        public DbSet<Order> Orders { get; set; }
        static FreediContext()
        {
   
            Database.SetInitializer<FreediContext>(new StoreDbInitializer());
        }
        public FreediContext()
            : base("name = DefaultConnection")
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<FreediContext>
    {
        protected override void Seed(FreediContext db)
        {
            db.Goods.Add(new Good {Id=1 ,Name = "black Bag", Type = "Bag",  Price = 220,Description ="d",Photo="ph",SKU="p",Stock=true,StockQuantity=11,Unit="count" });
            db.SaveChanges();
        }
    }
}

