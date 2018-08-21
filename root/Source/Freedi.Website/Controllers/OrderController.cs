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

        public ActionResult MakeOrder()
        {
          
            if (HttpContext.Session["Cart"] != null)
            {
                var cart = (CartManager)Session["Cart"];
                OrderViewModel order = new OrderViewModel
                {
                    CartLineView = cart.Lines,
                    Sum = cart.TotalValue(),
                    ApplicationUserId = User.Identity.GetUserId()
                };
                _orderManager.MakeOrder(order);
                cart.Clear();

            }
            return RedirectToAction("Freedi", "Home", new { area = "" });

        }

        public ActionResult GetOrders()
        {
            return PartialView("GetOrders", _orderManager.GetOrdersByUserID(User.Identity.GetUserId()));
        }
    }
}