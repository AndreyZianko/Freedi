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
    [Authorize]
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
        public ActionResult AddToCart(int Id , string Quantity)
        {
            var item = _goodsManager.GetGoodsById(Id);
            if (_goodsManager.GetGoodsById(Id).StockQuantity > Convert.ToInt32(Quantity)&& item!=null /*&& item.Stock*/)
            {
                GetCart().AddItem(item, Convert.ToInt32(Quantity));
              
            }
            else
            {

            }
            return Content(GetCart().Lines.Select(x => x.Quantity).First().ToString());
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