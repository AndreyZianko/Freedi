using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Identity;
using Freedi.DataProvider.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace Freedi.DataProvider.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public FreediContext _context { get; set; }

        //public IGoodRepository Goods { get; }
        //public IOrderRepository Orders { get; }
        //public IClientRepository Users { get; }
        //public IPhotosRepository Photos { get; }

        public UnitOfWork(FreediContext context)
            
        {
            _context = context;

            //Goods = new GoodRepository(_context);
            //Orders = new OrderRepository(_context);
            //Users = new ClientRepository(_context);
            //Photos = new PhotosRepository(_context);
        }
     
        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}

