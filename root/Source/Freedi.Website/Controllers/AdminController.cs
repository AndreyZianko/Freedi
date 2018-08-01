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
        public AdminController(IOrderManager orderManager, IGoodsManager goodsManager)
        {

            _orderManager = orderManager;
            _goodsManager = goodsManager;

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
        public ActionResult CreateProduct(GoodsViewModel _goodsViewModel)
        {

           
            if (_goodsViewModel.UploadedFile != null)
            {
                _goodsViewModel.Photo = _goodsViewModel.UploadedFile.ResizeImg(_goodsViewModel.Name);
            }
           
            if ((_goodsManager.CreateProduct(_goodsViewModel)))
                return View("AdminView");
            return View("AdminView");
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

            return  PartialView("DeleteProductView", _goodsManager.GetGoodsById(Id));
                 
        }
        [HttpPost]
        public ActionResult DeleteProductConfirm(int? Id)
        {
            if (Id != null)
            {
                _goodsManager.DeleteProduct((int)Id);
                return RedirectToAction("Admin");
            }
            return PartialView("DeleteProductView", _goodsManager.GetGoodsById(Id));
        }
    }
}