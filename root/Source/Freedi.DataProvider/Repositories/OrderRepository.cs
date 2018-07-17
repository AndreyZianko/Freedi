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
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        FreediContext _context;
        public OrderRepository(FreediContext context) : base(context)
        {
            _context = context;
        }
    }
}
