using Freedi.DataProvider.Entites;
using System.Collections.Generic;

namespace Freedi.DataProvider.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order>GetOrdersByUserID(string userid);
    }
}