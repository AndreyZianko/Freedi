using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freedi.Logic.Interfaces;
using Freedi.Logic.Managers;
using Freedi.Model.ViewModels;

namespace Freedi.Website.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        public ActionResult Index()
        {
            return View();
        }

        public OrderViewModel MakeOrder()
        {
            OrderViewModel order=null;
            if(HttpContext.Session["Cart"] != null)
            {
               

                   var cart = (CartManager)Session["Cart"];
                    order = new OrderViewModel
                    {
                        CartModel = cart.CartFull(),
                        Sum = cart.TotalValue(),
                        ClientName = User.Identity.Name
                    };
                _orderManager.MakeOrder(order);


            }

            return order;
        }
    }
}