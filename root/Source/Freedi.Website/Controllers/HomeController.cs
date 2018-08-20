using System.Web.Mvc;
using Freedi.Logic.Interfaces;

namespace Freedi.Website.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IGoodsManager _goodsManager;
        

        public HomeController( IGoodsManager goodsManager)
        {
        
            _goodsManager = goodsManager;
        }

        public ActionResult Freedi()
        {
            return View();
        }

        public ActionResult Catalog()
        {
            return View(_goodsManager.GetGoods());
        }

        [Authorize]
        public ActionResult SingleProduct(int? id)
        {
            if (id != null)
            {
                return _goodsManager.GetGoodsById(id) != null ? (ActionResult)View(_goodsManager.GetGoodsById(id)) : RedirectToAction("Catalog");
            }

            return RedirectToAction("Catalog");
        }

     
    }
}