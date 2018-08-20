using System;
using System.Collections.Generic;
using System.Linq;
using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Interfaces;
using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;
using CartLine = Freedi.DataProvider.Entites.CartLine;

namespace Freedi.Logic.Managers
{
    public class OrderManager : IOrderManager
    {
        public OrderManager(IUnitOfWork uow,
            IGoodRepository goodRepository,
            IOrderRepository orderRepository)
        {
            _uow = uow;
            _goodRepository = goodRepository;
            _orderRepository = orderRepository;
        }

        private readonly IUnitOfWork _uow;
        private readonly IGoodRepository _goodRepository;
        private readonly IOrderRepository _orderRepository;

        public void MakeOrder(OrderViewModel orderView)
        {
            var order = new Order
            {
                Date = DateTime.Now,
                Sum = orderView.Sum,
                ApplicationUserId = orderView.ApplicationUserId,
                CartLines =  orderView.CartModel.Lines.Select(li => new CartLine {GoodsId = li.Goods.Id , Quantity  = li.Quantity } ).ToList(),
            };

            _orderRepository.Create(order);
            _uow.Save();
        }

        public IEnumerable<GoodsViewModel> GetGoods()
        {
            var allgoods = _goodRepository.GetAll();
            var result = new List<GoodsViewModel>();
            foreach (var goods in allgoods)
                result.Add(new GoodsViewModel
                {
                    Id = goods.Id,
                    Name = goods.Name,
                    Price = goods.Price,
                    Currency = goods.Currency,
                    Sex = goods.Sex,
                    //Photo = goods.Photo,
                    StockQuantity = goods.StockQuantity,

                    Description = goods.Description,
                    Type = goods.Type,

                    Stock = goods.Stock
                });
            return result;
        }

        public GoodsViewModel GetGood(int? id)
        {
            if (id != null)
            {
                var good = _goodRepository.Get(id);
                return new GoodsViewModel {Id = good.Id, Name = good.Name, Price = good.Price};
            }

            return null;
        }
    }
}