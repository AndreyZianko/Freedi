using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freedi.Logic.Interfaces;
using Freedi.Logic.Managers;
using Freedi.Model.ViewModels;
using Microsoft.AspNet.Identity;

namespace Freedi.Website.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {

        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public OrderViewModel MakeOrder()
        {
            OrderViewModel order = null;
            if (HttpContext.Session["Cart"] != null)
            {
                var cart = (CartManager)Session["Cart"];
                order = new OrderViewModel
                {
                    CartModel = cart.CartFull(),
                    Sum = cart.TotalValue(),
                    ApplicationUserId = User.Identity.GetUserId()
                };
                _orderManager.MakeOrder(order);
                cart.Clear();
            }

            return order;
        }
    }
}