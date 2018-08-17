using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;
using Freedi.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Freedi.Website.Controllers
{
  
    public class CartController : Controller
    {
        private IGoodsManager _goodsManager { get; set; }
        public CartController(IGoodsManager goodsManager)
        {
            _goodsManager = goodsManager;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddToCart(int? Id , string Quantity)
        {
            if(Id!=null)
            { 
                var item = _goodsManager.GetGoodsById(Id);
                if (_goodsManager.GetGoodsById(Id).StockQuantity > Convert.ToInt32(Quantity)&& item!=null && item.Stock)
                {
                    GetCart().AddItem(item, Convert.ToInt32(Quantity));
              
                }
            }
            return Content(GetCart().Lines.Select(x => x.Quantity).First().ToString());
        }
        public ActionResult GetCartView()
        {
            CartViewModel model = new CartViewModel();
            model.Price = GetCart().Lines.Select(x => x.Goods.Price).FirstOrDefault();
            model.ProductName = GetCart().Lines.Select(x => x.Goods.Name).FirstOrDefault();
            model.Quantity = GetCart().Lines.Select(x => x.Quantity).FirstOrDefault();
            model.TotalPrice = GetCart().TotalValue();
            return PartialView("GetCartView",model);
        }
        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}