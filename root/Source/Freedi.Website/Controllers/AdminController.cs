﻿using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Freedi.Common.Images;
namespace Freedi.Website.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IOrderManager _orderManager;
        IGoodsManager _goodsManager;
        IPhotoManager _photoManager;
        public AdminController(IOrderManager orderManager, IGoodsManager goodsManager , IPhotoManager photoManager)
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
            //if (!ModelState.IsValid)
            //{
            //    return PartialView("CreateProductPartialVIew", _goodsViewModel);
            //}

            //if (_goodsViewModel.UploadedFile[0]!=null)
            //{
            //    foreach (var file in _goodsViewModel.UploadedFile)
            //    {
            //        if (file != null && file.ContentLength > 0)
            //        {
            //            _goodsViewModel.Photo = _goodsViewModel.UploadedFile.ResizeImg(_goodsViewModel.Name);

            //        }
            //    }

            //}

            _goodsViewModel.Photo = _photoManager.UploadPhoto(_goodsViewModel.UploadedFile, _goodsViewModel.Name);
            _goodsManager.CreateProduct(_goodsViewModel);
                return Content("Success");
        }


        [HttpPost]
        public ActionResult Catalog(GoodsViewModel goods)
        {
                 _goodsManager.GoodsUpdate(goods);
                return View("SuccessPartialView");
        }
        
        public ActionResult DeleteProduct(int? Id)
        {

            return  PartialView("DeleteProductView", _goodsManager.GetGoodsById(Id));
                 
        }
        [HttpPost]
        public ActionResult DeleteProductConfirm(int? Id)
        {
            
            if (Id != null)
            {
                _goodsManager.DeleteProduct((int)Id);
                return View("SuccessPartialView");
            }
            return PartialView("DeleteProductView", _goodsManager.GetGoodsById(Id));
        }
    }
}