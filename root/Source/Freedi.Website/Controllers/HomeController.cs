using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;
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
        public ActionResult Catalog(int? Id)
        {
            if (Id != null)
            {
                return PartialView("ParticularProductView", _goodsManager.GetGoodsById(Id));
            }
           return  PartialView("Catalog", _goodsManager.GetGoods()); 
        }
        [HttpPost]
        public ActionResult Catalog(GoodsViewModel goods)
        {

            return  _goodsManager.GoodsUpdate(goods) ? Content("Success") : Content("False");
        }
    }
}