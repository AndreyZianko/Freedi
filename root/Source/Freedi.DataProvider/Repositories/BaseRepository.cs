using Freedi.DataProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.DataProvider.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        FreediContext _context;
        FreediContext _appContext;
        protected readonly DbSet<T> _dbset;

        public BaseRepository(FreediContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public void Create(T item)
        {
            _dbset.Add(item);
        }

        public bool Delete(int id)
        {
            T resault = _dbset.Find(id);

            if (resault != null)
            {
                _dbset.Remove(resault);
                return true;
            }

            return false;
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            IEnumerable<T> result = _dbset.Where(predicate).ToList();
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public T Get(int? id)
        {
            T resault = _dbset.Find(id);
            return resault;
        }


    }
}
