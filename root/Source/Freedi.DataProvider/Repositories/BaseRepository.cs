using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Freedi.DataProvider.Interfaces;

namespace Freedi.DataProvider.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> Dbset;
        private readonly FreediContext _context;

        public BaseRepository(FreediContext context)
        {
            _context = context;
            Dbset = context.Set<T>();
        }

        public void Create(T item)
        {
            Dbset.Add(item);
        }

        public bool Delete(int id)
        {
            var resault = Dbset.Find(id);

            if (resault != null)
            {
                Dbset.Remove(resault);
                return true;
            }

            return false;
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            IEnumerable<T> result = Dbset.Where(predicate).ToList();
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            return Dbset.ToList();
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public T Get(int? id)
        {
            var resault = Dbset.Find(id);
            return resault;
        }
    }
}