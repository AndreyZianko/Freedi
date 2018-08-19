using System;
using System.Collections.Generic;
using Freedi.DataProvider.Interfaces;
using Freedi.DataProvider.Models;
using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;

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

        private IUnitOfWork _uow { get; }
        private IGoodRepository _goodRepository { get; }
        private IOrderRepository _orderRepository { get; }

        public void MakeOrder(OrderViewModel orderView)
        {
            var good = _goodRepository.Get(orderView.GoodId);


            var order = new Order
            {
                Date = DateTime.Now,
                Address = orderView.Address,
                GoodId = good.Id,
                PhoneNumber = orderView.PhoneNumber
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