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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Goods, GoodsView>()).CreateMapper();
            return mapper.Map<IEnumerable<Goods>, List<GoodsView>>(_uow.Goods.GetAll());
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
