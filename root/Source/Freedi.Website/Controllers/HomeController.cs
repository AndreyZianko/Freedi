using System.Web.Mvc;
using Freedi.Logic.Interfaces;

namespace Freedi.Website.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IGoodsManager _goodsManager;
        private IOrderManager _orderManager;

        public HomeController(IOrderManager orderManager, IGoodsManager goodsManager)
        {
            _orderManager = orderManager;
            _goodsManager = goodsManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Catalog()
        {
            return View(_goodsManager.GetGoods());
        }

        [Authorize]
        public ActionResult SingleProduct(int? Id)
        {
            if (Id != null)
            {
                return _goodsManager.GetGoodsById(Id) != null ? (ActionResult)View(_goodsManager.GetGoodsById(Id)) : RedirectToAction("Catalog");
            }

            return RedirectToAction("Catalog");
        }

     
    }
}