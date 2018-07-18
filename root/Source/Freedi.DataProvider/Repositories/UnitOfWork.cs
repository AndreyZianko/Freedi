using Freedi.DataProvider.Interfaces;

namespace Freedi.DataProvider.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public FreediContext _context { get; set; }
        public IGoodRepository Goods { get; }
        public IOrderRepository Orders { get; }

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
    }
}

