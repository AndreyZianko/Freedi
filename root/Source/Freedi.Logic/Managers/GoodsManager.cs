using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Interfaces;
using Freedi.DataProvider.Models;
using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Hosting;

namespace Freedi.Logic.Managers
{
    public class GoodsManager : IGoodsManager
    {
        IUnitOfWork _uow { get; set; }
       public GoodsManager(IUnitOfWork uow)
        {
            _uow = uow;

        }
        public List<GoodsViewModel> GetGoods()
        {
            var allgoods = _uow.Goods.GetAll();
          
            var result = new List<GoodsViewModel>();
            
            foreach (var goods in allgoods)
            {
                result.Add(new GoodsViewModel
                {
                    Id = goods.Id,
                    Name = goods.Name,
                    Price = goods.Price,
                    Currency = goods.Currency,
                    Sex = goods.Sex,
                    StockQuantity = goods.StockQuantity,
                    SKU = goods.SKU,
                    Photo = goods.Photos.Where(x => x.PhotoPath.Contains("250x250")).Select(ph => new PhotosViewModel { PhotoId = ph.PhotoId, PhotoPath = ph.PhotoPath }).ToList(),
                    PhotoCount = goods.Photos.Where(x => x.PhotoPath.Contains("250x250")).Count(),
                    Description = goods.Description,
                    Type = goods.Type,
                    Unit = goods.Unit,
                    Stock = goods.Stock
                           
                });
                
               
            }
            return result;
        }
        public GoodsViewModel GetGoodsById(int? Id)
        {
            var _goods = _uow.Goods.Get(Id);
            return (new GoodsViewModel
            {
                Id = _goods.Id,
                Name = _goods.Name,
                Price = _goods.Price,
                Currency = _goods.Currency,
                Sex = _goods.Sex,
                Photo = _goods.Photos.Where(x=>x.PhotoPath.Contains("250x250")).Select(ph => new PhotosViewModel { PhotoId = ph.PhotoId, PhotoPath = ph.PhotoPath }).ToList(),
                StockQuantity = _goods.StockQuantity,
                SKU = _goods.SKU,
                Description = _goods.Description,
                Type = _goods.Type,
                Unit = _goods.Unit,
                Stock = _goods.Stock
            });
        }

        public bool GoodsUpdate(GoodsViewModel _goodsViewModel)
        {
            Photos _photos = new Photos();
            var _product = _uow.Goods.Get(_goodsViewModel.Id);
            _product.Name = _goodsViewModel.Name;
            _product.Price = _goodsViewModel.Price;
            _product.Sex = _goodsViewModel.Sex;
            _product.SKU = _goodsViewModel.SKU;
            _product.StockQuantity = _goodsViewModel.StockQuantity;
            _product.Unit = _goodsViewModel.Unit;
            _product.Type = _goodsViewModel.Type;
            _product.Currency = _goodsViewModel.Currency;
            _product.Description = _goodsViewModel.Description;
            if (_goodsViewModel.Photo != null)
                foreach (var _photo in _goodsViewModel.Photo)
                {
                    _photos.PhotoPath = _photo.PhotoPath;
                    _photos.GoodsId = _product.Id;
                    _uow.Photos.Update(_photos);
                    _uow.Save();
                }
            _product.Stock = _goodsViewModel.Stock;
            _uow.Goods.Update(_product);
            _uow.Save();
            return true;
        }

        public bool CreateProduct(GoodsViewModel _goodsViewModel)
        {
            Goods _product = new Goods();
            Photos _photos = new Photos();
            _product.Name = _goodsViewModel.Name;
            _product.Price = _goodsViewModel.Price;
            _product.Sex = _goodsViewModel.Sex;
            _product.SKU = _goodsViewModel.SKU;
            _product.StockQuantity = _goodsViewModel.StockQuantity;
            _product.Unit = _goodsViewModel.Unit;
            _product.Type = _goodsViewModel.Type;
            _product.Currency = _goodsViewModel.Currency;
            _product.Description = _goodsViewModel.Description;
            _product.Stock = _goodsViewModel.Stock;
            _uow.Goods.Create(_product);
            _uow.Save();
            if (_goodsViewModel.Photo != null)
                foreach (var _photo in _goodsViewModel.Photo)
                {
                    _photos.PhotoPath = _photo.PhotoPath;
                    _photos.GoodsId = _product.Id;
                    _uow.Photos.Create(_photos);
                    _uow.Save();
                }
       
            return true;
        }

        public bool DeleteProduct(int Id)
        {
            if(_uow.Goods.Get(Id).Photos.Count>0)
            foreach (var item in _uow.Goods.Get(Id).Photos.Select(x => x.PhotoPath))
            {
                    var fullpath = HostingEnvironment.MapPath(item.Replace("..", "~"));
                    FileInfo fileInf = new FileInfo(fullpath);
                    if (fileInf.Exists)
                    {
                        fileInf.Delete();  
                    }
                 
            }

            if (_uow.Goods.Delete(Id))
            {
                _uow.Save();
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
