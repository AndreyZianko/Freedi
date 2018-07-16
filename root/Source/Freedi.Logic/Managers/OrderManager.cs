using AutoMapper;
using Freedi.DataProvider.Interfaces;
using Freedi.DataProvider.Models;
using Freedi.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.Logic.Managers
{
    public class OrderManager
    {
        IUnitOfWork Database { get; set; }

        public OrderManager(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOrder(OrderView orderView)
        {
            Good good = Database.Goods.Get(orderView.GoodId);


            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderView.Address,
                GoodId = good.Id,
                PhoneNumber = orderView.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }

        public GoodView GetGood(int? id)
        {
            if (id != null)
            { 
            var good = Database.Goods.Get(id.Value);
            return new GoodView { Id = good.Id, Name = good.Name, Price = good.Price };
            }
            else
            {
                return null;
            }

        }
        public IEnumerable<GoodView> GetGoods()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Good, GoodView>()).CreateMapper();
            return mapper.Map<IEnumerable<Good>, List<GoodView>>(Database.Goods.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
