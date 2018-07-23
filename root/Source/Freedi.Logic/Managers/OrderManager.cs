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
        IUnitOfWork _uow { get; set; }

        public OrderManager(IUnitOfWork uow)
        {
            _uow = uow;
            
        }
 
        public void MakeOrder(OrderView orderView)
        {
            var good = _uow.Goods.Get(orderView.GoodId);
           
          
            var order = new Order
            {
                Date = DateTime.Now,
                Address = orderView.Address,
                GoodId = good.Id,
                PhoneNumber = orderView.PhoneNumber
            };
            _uow.Orders.Create(order);
            _uow.Save();
        }

        public IEnumerable<GoodsView> GetGoods()
        {
            var allgoods = _uow.Goods.GetAll();
            var result = new List<GoodsView>();
            foreach (var goods in allgoods)
            {
                result.Add(new GoodsView
                {
                    Id = goods.Id,
                    Name = goods.Name,
                    Price = goods.Price,
                    Currency = goods.Currency,
                    Sex = goods.Sex,
                    Photo = goods.Photo,
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

        public GoodsView GetGood(int? id)
        {

            if (id != null)
            {
                var good = _uow.Goods.Get(id);
                return new GoodsView { Id = good.Id, Name = good.Name, Price = good.Price };
            }
            else
                return null;
           
        }
    }
}
