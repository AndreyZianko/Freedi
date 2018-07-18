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
        GoodView GetGood(int? id);
        IEnumerable<GoodView> GetGoods();
    }
}
