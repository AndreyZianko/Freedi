using System.Web.Mvc;
using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;

namespace Freedi.Website.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IGoodsManager _goodsManager;
        private readonly IPhotoManager _photoManager;
        private IOrderManager _orderManager;

        public AdminController(IOrderManager orderManager, IGoodsManager goodsManager, IPhotoManager photoManager)
        {
            _orderManager = orderManager;
            _goodsManager = goodsManager;
            _photoManager = photoManager;
        }

        public ActionResult Admin()
        {
            return View("AdminView");
        }

        public ActionResult Catalog()
        {
            return PartialView("CatalogPartialView", _goodsManager.GetGoods());
        }

        public ActionResult EditProduct(int? Id)
        {
            return PartialView("EditProductView", _goodsManager.GetGoodsById(Id));
        }

        public ActionResult CreateProduct()
        {
            return PartialView("CreateProductPartialVIew");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(GoodsViewModel _goodsViewModel)
        {
            if (!ModelState.IsValid) return PartialView("CreateProductPartialVIew", _goodsViewModel);
            _goodsViewModel.Photo = _photoManager.UploadPhoto(_goodsViewModel.UploadedFile, _goodsViewModel.Name);
            _goodsManager.CreateProduct(_goodsViewModel);
            return PartialView("CreateProductPartialVIew");
        }


        [HttpPost]
        public ActionResult EditProduct(GoodsViewModel goods)
        {
            foreach (string fileName in Request.Files)
                if (Request.Files[fileName] != null && Request.Files[fileName].ContentLength > 0)
                    goods.UploadedFile.Add(Request.Files[fileName]);

            _photoManager.UpdatePhoto(goods);
            _goodsManager.GoodsUpdate(goods);
            return PartialView("EditProductView", _goodsManager.GetGoodsById(goods.Id));
        }

        public ActionResult DeleteProduct(int? Id)
        {
            return PartialView("DeleteProductView", _goodsManager.GetGoodsById(Id));
        }

        [HttpPost]
        public ActionResult DeleteProductConfirm(GoodsViewModel goods)
        {
            if (goods.Id >0)
            {
                _goodsManager.DeleteProduct(goods.Id);
                return RedirectToAction("Admin");
            }

            return RedirectToAction("Admin");
        }
    }
}