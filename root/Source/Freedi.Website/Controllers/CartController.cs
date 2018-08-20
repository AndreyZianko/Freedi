using System;
using System.Linq;
using System.Web.Mvc;
using Freedi.Logic.Interfaces;
using Freedi.Logic.Managers;


namespace Freedi.Website.Controllers
{
    public class CartController : Controller
    {
        public CartController(IGoodsManager goodsManager, IOrderManager orderManager)
        {
            GoodsManager = goodsManager;
            OrderManager = orderManager;
        }

        private IGoodsManager GoodsManager { get; }
        private IOrderManager OrderManager { get; }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddToCart(int? id, string quantity)
        {
            if (id != null)
            {
                var item = GoodsManager.GetGoodsById(id);
              
                if (item.StockQuantity > Convert.ToInt32(quantity)  && item.Stock)
                    GetCart().AddItem(item, quantity!=null? Convert.ToInt32(quantity):0);
            }

            return Content(GetCart().TotalGoods().ToString());
        }

        public ActionResult RemoveFromCart(int id)
        {
            GetCart().RemoveLine(id);

            return PartialView("GetCartView", GetCart().CartFull());
        }

        public int CartItemsCounter()
        {
            return GetCart().TotalGoods();
        }

        
        public ActionResult GetCartView()
        {
            return PartialView("GetCartView", GetCart().CartFull());
        }

        public CartManager GetCart()
        {
            var cart = (CartManager) Session["Cart"];
            if (cart == null)
            {
                cart = new CartManager();
                Session["Cart"] = cart;
            }

            return cart;
        }

      
    }
}