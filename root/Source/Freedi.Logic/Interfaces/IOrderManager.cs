using System.Collections.Generic;
using Freedi.DataProvider.Entites;
using Freedi.Model.ViewModels;

namespace Freedi.Logic.Interfaces
{
    public interface IOrderManager
    {
        void MakeOrder(OrderViewModel orderView);
        List<OrderViewModel> GetOrdersByUserID(string userid);
    }
}