using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Freedi.Website.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IOrderManager _orderManager;
        IGoodsManager _goodsManager;
        public AdminController(IOrderManager orderManager, IGoodsManager goodsManager)
        {

            _orderManager = orderManager;
            _goodsManager = goodsManager;

        }
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Catalog(int? Id)
        {
            if (Id != null)
            {
                return PartialView("ParticularProductView", _goodsManager.GetGoodsById(Id));
            }
            return PartialView("CatalogPartialView", _goodsManager.GetGoods());
        }
        public ActionResult CreateProduct()
        {
            return PartialView("CreateProductPartialVIew");
        }
        [HttpPost]
        public ActionResult CreateProduct(GoodsViewModel _goodsViewModel)
        {

           if((_goodsManager.CreateProduct(_goodsViewModel)))
                return View("Admin");
            return View("Admin");
        }


        [HttpPost]
        public ActionResult Catalog(GoodsViewModel goods)
        {
            if(_goodsManager.GoodsUpdate(goods) )
                return View("Admin");

            return View("Admin");
        }

        public ActionResult DeleteProduct(int? Id)
        {
            if (Id != null)
            {
                _goodsManager.DeleteProduct((int)Id);
                 return View("Admin");
            }
            else
            {
                return View("Admin");
            }
            
        }
    }
}