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
        private IUnitOfWork _uow { get; set; }
        private IGoodRepository _goodRepository { get; set; }
        private IOrderRepository _orderRepository { get; set; }
        private IPhotosRepository _photosRepository { get; set; }
        public GoodsManager(IUnitOfWork uow, IGoodRepository goodRepository,
            IOrderRepository orderRepository, IPhotosRepository photosRepository)
        {
            _uow = uow;
            _goodRepository = goodRepository;
            _orderRepository = orderRepository;
            _photosRepository = photosRepository;

        }
        public List<GoodsViewModel> GetGoods()
        {
            return _goodRepository.GetAll().Select(goods => new GoodsViewModel
            {
                Id = goods.Id,
                Name = goods.Name,
                Price = goods.Price,
                Currency = goods.Currency,
                Sex = goods.Sex,
                StockQuantity = goods.StockQuantity,
                SKU = goods.SKU,
                Photo = goods.Photos.Select(ph => new PhotosViewModel { PhotoId = ph.PhotoId, PhotoPath = ph.PhotoPath }).ToList(),
                PhotoCount = goods.Photos.Count(),
                Description = goods.Description,
                Type = goods.Type,
                Unit = goods.Unit,
                Stock = goods.Stock

            }).ToList();
            
        }

        public GoodsViewModel GetGoodsById(int? Id)
        {
            var _goods = _goodRepository.Get(Id);
            return (new GoodsViewModel
            {
                Id = _goods.Id,
                Name = _goods.Name,
                Price = _goods.Price,
                Currency = _goods.Currency,
                Sex = _goods.Sex,
                Photo = _goods.Photos.Select(ph => new PhotosViewModel { PhotoId = ph.PhotoId, PhotoPath = ph.PhotoPath }).ToList(),
                PhotoCount = _goods.Photos.Count,
                StockQuantity = _goods.StockQuantity,
                SKU = _goods.SKU,
                Description = _goods.Description,
                Type = _goods.Type,
                Unit = _goods.Unit,
                Stock = _goods.Stock
            });
        }

        public void GoodsUpdate(GoodsViewModel goodsViewModel)
        {
            Photos _photos = new Photos();
            var _product = _goodRepository.Get(goodsViewModel.Id);
            _product.Name = goodsViewModel.Name;
            _product.Price = goodsViewModel.Price;
            _product.Sex = goodsViewModel.Sex;
            _product.SKU = goodsViewModel.SKU;
            _product.StockQuantity = goodsViewModel.StockQuantity;
            _product.Unit = goodsViewModel.Unit;
            _product.Type = goodsViewModel.Type;
            _product.Currency = goodsViewModel.Currency;
            _product.Description = goodsViewModel.Description;
            if (goodsViewModel.Photo != null)
                foreach (var _photo in goodsViewModel.Photo)
                {
                    _photos.PhotoPath = _photo.PhotoPath;
                    _photos.GoodsId = _product.Id;
                    _photosRepository.Update(_photos);
                    _uow.Save();
                }
            _product.Stock = goodsViewModel.Stock;
            _goodRepository.Update(_product);
            _uow.Save();
         
        }

        public void CreateProduct(GoodsViewModel goodsViewModel)
        {
            Goods goods = new Goods();
            Photos photos = new Photos();
            FillEntityFromViewModel(goods, goodsViewModel, photos);
            _goodRepository.Create(goods);
            _uow.Save();
        }


        public void DeleteProduct(int Id)
        {
            if(_goodRepository.Get(Id).Photos.Count>0)
            foreach (var item in _goodRepository.Get(Id).Photos.Select(x => x.PhotoPath))
            {
                    var fullpath = HostingEnvironment.MapPath(item.Replace("..", "~"));
                    FileInfo fileInf = new FileInfo(fullpath);
                    if (fileInf.Exists)
                    {
                        fileInf.Delete();  
                    }
            }
            _goodRepository.Delete(Id);
            _uow.Save();

        }






        private void FillEntityFromViewModel(Goods goods, GoodsViewModel goodsViewModel, Photos photos)
        {
            goods.Name = goodsViewModel.Name;
            goods.Price = goodsViewModel.Price;
            goods.Sex = goodsViewModel.Sex;
            goods.SKU = goodsViewModel.SKU;
            goods.StockQuantity = goodsViewModel.StockQuantity;
            goods.Unit = goodsViewModel.Unit;
            goods.Type = goodsViewModel.Type;
            goods.Currency = goodsViewModel.Currency;
            goods.Description = goodsViewModel.Description;
            goods.Stock = goodsViewModel.Stock;

            foreach (var photo in goodsViewModel.Photo)
            {
                goods.Photos.Add(new Photos { PhotoPath = photo.PhotoPath });
            }
        
            

        }
    }
}
