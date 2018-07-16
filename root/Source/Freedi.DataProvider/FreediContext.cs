using Freedi.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public FreediContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<FreediContext>
    {
        protected override void Seed(FreediContext db)
        {
            db.Goods.Add(new Good { Name = "black Bag", Type = "Bag",  Price = 220 , });
            db.Goods.Add(new Good { Name = "black Pants", Type = "Pants",  Price = 320 });
            db.Goods.Add(new Good { Name = "black Shoes", Type = "Shoes",  Price = 260 });
            db.Goods.Add(new Good { Name = "black Shoes", Type = "Panties",  Price = 300 });

         
            db.SaveChanges();
        }
    }
}

