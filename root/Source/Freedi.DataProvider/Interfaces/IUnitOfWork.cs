using Freedi.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.DataProvider.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Good> Goods { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}
