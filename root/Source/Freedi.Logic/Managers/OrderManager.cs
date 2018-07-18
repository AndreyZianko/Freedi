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
        IUnitOfWork Database { get; set; }

        public OrderManager(IUnitOfWork uow)
        {
            Database = uow;
        }
 
        public void MakeOrder(OrderView orderView)
        {
            var good = Database.Goods.Get(orderView.GoodId);


            var order = new Order
            {
                Date = DateTime.Now,
                Address = orderView.Address,
                GoodId = good.Id,
                PhoneNumber = orderView.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }

        public IEnumerable<GoodView> GetGoods()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Goods, GoodView>()).CreateMapper();
            return mapper.Map<IEnumerable<Goods>, List<GoodView>>(Database.Goods.GetAll());
        }

        public GoodView GetGood(int? id)
        {
            if (id != null)
            {
                var good = Database.Goods.Get(id);
                return new GoodView { Id = good.Id, Name = good.Name, Price = good.Price };
            }
            else
                return null;
           
        }
    }
}
