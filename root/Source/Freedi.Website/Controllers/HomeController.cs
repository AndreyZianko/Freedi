using Freedi.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Freedi.Website.Controllers
{
    public class HomeController : Controller
    {
        IOrderManager orderManage;
        public HomeController(IOrderManager order)
        {
            orderManage = order;
        }
        public ActionResult Index()
        {
            var k = orderManage.GetGoods();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Catalog()
        {
          

            return View();
        }
    }
}