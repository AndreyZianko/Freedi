using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Interfaces;
using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;
using Freedi.Model.ViewModels.CartModels;


namespace Freedi.Logic.Managers
{
    public class OrderManager : IOrderManager
    {
        public OrderManager(IUnitOfWork uow,
            IGoodRepository goodRepository,
            IOrderRepository orderRepository,IClientRepository clientRepository)
        {
            _uow = uow;
            _goodRepository = goodRepository;
            _orderRepository = orderRepository;
            _clientRepository = clientRepository;
        }

        private readonly IUnitOfWork _uow;
        private readonly IGoodRepository _goodRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IClientRepository _clientRepository;
        public void MakeOrder(OrderViewModel orderView)
        {
            var order = new Order
            {
                Date = DateTime.Now,
                Sum = orderView.Sum,
                ApplicationUserId = orderView.ApplicationUserId,
                CartLines =  orderView.CartLineView.Select(li => new CartLine {GoodsId = li.Goods.Id , Quantity  = li.Quantity } ).ToList(),
            };

            _orderRepository.Create(order);
            _uow.Save();
        }

        

        public List<OrderViewModel> GetOrdersByUserID(string userid)
        {
           
          var orders = _orderRepository.GetOrdersByUserID(userid);


            return orders.Select(x => new OrderViewModel {  Sum = x.Sum,Goods = FillEntityFromViewModel(x.CartLines.Select(p => p.Goods).ToList())}).ToList();
        }

    

        private List<GoodsViewModel> FillEntityFromViewModel(ICollection<Goods> products)
        {

            List<GoodsViewModel> l = new List<GoodsViewModel>();
            foreach (var goodsViewModel in products)
            {
                GoodsViewModel goods = new GoodsViewModel
                {
                    Name = goodsViewModel.Name,
                    Price = goodsViewModel.Price,
                    Currency = goodsViewModel.Currency,
                    Photo = goodsViewModel.Photos
                    .Select(ph => new PhotosViewModel { PhotoId = ph.Id, PhotoPath = ph.Path }).ToList()
                };
                l.Add(goods);
            }

            return l;
           
        }

    }
}