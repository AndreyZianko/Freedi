using System;
using System.Collections.Generic;

namespace Freedi.DataProvider.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int? id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        bool Delete(int id);
    }
}
