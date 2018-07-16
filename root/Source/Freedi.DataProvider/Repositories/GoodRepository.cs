using Freedi.DataProvider.Interfaces;
using Freedi.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.DataProvider.Repositories
{
    public class GoodRepository : IRepository<Good>
    {
        private FreediContext db;

        public GoodRepository(FreediContext context)
        {
            this.db = context;
        }

        public IEnumerable<Good> GetAll()
        {
            return db.Goods;
        }

        public Good Get(int id)
        {
            return db.Goods.Find(id);
        }

        public void Create(Good good)
        {
            db.Goods.Add(good);
        }

        public void Update(Good good)
        {
            db.Entry(good).State = EntityState.Modified;
        }

        public IEnumerable<Good> Find(Func<Good, Boolean> predicate)
        {
            return db.Goods.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Good book = db.Goods.Find(id);
            if (book != null)
                db.Goods.Remove(book);
        }

      
    }
}
