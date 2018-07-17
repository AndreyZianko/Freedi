using Freedi.DataProvider.Interfaces;
using Freedi.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.DataProvider.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public FreediContext _context { get; set; }
        public IGoodRepository Goods { get; }
        public IOrderRepository Orders { get; }
        private bool disposed;
        public UnitOfWork(FreediContext context) 
        {
            _context = context;
            Goods = new GoodRepository(_context);
            Orders = new OrderRepository(_context);

        }

     
        public void Save()
        {
            _context.SaveChanges();
        }



        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

