using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Interfaces;

namespace Freedi.DataProvider.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private FreediContext _context;

        public OrderRepository(FreediContext context) : base(context)
        {
            _context = context;
        }
    }
}