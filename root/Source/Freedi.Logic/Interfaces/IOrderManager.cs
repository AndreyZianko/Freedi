using System.Collections.Generic;
using Freedi.Model.ViewModels;

namespace Freedi.Logic.Interfaces
{
    public interface IOrderManager
    {
        void MakeOrder(OrderViewModel orderView);
        GoodsViewModel GetGood(int? id);
        IEnumerable<GoodsViewModel> GetGoods();
    }
}