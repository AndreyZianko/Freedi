using AutoMapper;
using Freedi.DataProvider.Interfaces;
using Freedi.DataProvider.Models;
using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;
using System;
using System.Collections.Generic;

namespace Freedi.Logic.Managers
{
    public class OrderManager : IOrderManager
    {
        private IUnitOfWork _uow { get; set; }
        private IGoodRepository _goodRepository { get; set; }
        private IOrderRepository _orderRepository{ get; set; }

        public OrderManager(IUnitOfWork uow, 
            IGoodRepository goodRepository,
            IOrderRepository orderRepository)
        {
            _uow = uow;
            _goodRepository = goodRepository;
            _orderRepository = orderRepository;
        }
 
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
            {
                result.Add(new GoodsViewModel
                {
                    Id = goods.Id,
                    Name = goods.Name,
                    Price = goods.Price,
                    Currency = goods.Currency,
                    Sex = goods.Sex,
                    //Photo = goods.Photo,
                    StockQuantity = goods.StockQuantity,
                    SKU = goods.SKU,
                    Description = goods.Description,
                    Type = goods.Type,
                    Unit = goods.Unit,
                    Stock = goods.Stock

                });


            }
            return result;
        }

        public GoodsViewModel GetGood(int? id)
        {

            if (id != null)
            {
                var good = _goodRepository.Get(id);
                return new GoodsViewModel { Id = good.Id, Name = good.Name, Price = good.Price };
            }
            else
                return null;
           
        }
    }
}
