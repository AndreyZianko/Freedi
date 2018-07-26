using Freedi.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Freedi.Website.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        IOrderManager _orderManager;
        IGoodsManager _goodsManager;
        public HomeController(IOrderManager orderManager,IGoodsManager goodsManager) 
        {
            _orderManager = orderManager;
            _goodsManager = goodsManager;
        }

        public ActionResult Index()
        {
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
           return PartialView("Catalog", _goodsManager.GetGoods()); 
        }
    }
}