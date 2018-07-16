using Freedi.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.Logic.Interfaces
{
   public interface IOrderManager
    {
        void MakeOrder(OrderView orderView);
        OrderView GetGood(int? id);
        IEnumerable<OrderView> GetGoods();
        void Dispose();
    }
}
