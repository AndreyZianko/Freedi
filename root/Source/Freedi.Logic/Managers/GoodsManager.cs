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
                Photo = goods.Photos.Select(ph => new PhotosViewModel { PhotoId = ph.PhotoId, PhotoPath = ph.PhotoPath }).ToList(),
                PhotoCount = goods.Photos.Count(),
                Description = goods.Description,
                Type = goods.Type,
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
                Description = _goods.Description,
                Type = _goods.Type,
                Stock = _goods.Stock
            });
        }

        public void GoodsUpdate(GoodsViewModel goodsViewModel)
        {
            Goods goods = _goodRepository.Get(goodsViewModel.Id);
            
            fillGoodModelForUpdate(goods, goodsViewModel);
            _goodRepository.Update(goods);
            _uow.Save();
         
        }

       private void fillGoodModelForUpdate(Goods goods, GoodsViewModel goodsViewModel)
        {
            goods.Name = goodsViewModel.Name;
            goods.Price = goodsViewModel.Price;
            goods.Sex = goodsViewModel.Sex;
            goods.StockQuantity = goodsViewModel.StockQuantity;
            goods.Type = goodsViewModel.Type;
            goods.Currency = goodsViewModel.Currency;
            goods.Description = goodsViewModel.Description;
            goods.Stock = goodsViewModel.Stock;

            foreach (var photo in goodsViewModel.Photo)
            {
                if(photo.PhotoPath!=null)
                goods.Photos.Add(new Photos { PhotoPath = photo.PhotoPath });
            }

        }



        public void CreateProduct(GoodsViewModel goodsViewModel)
        {
            Goods goods = new Goods();
            FillEntityFromViewModel(goods, goodsViewModel);
            _goodRepository.Create(goods);
            _uow.Save();
        }


        public void DeleteProduct(int Id)
        {

            DeletePhotoFromProjectByPath(Id);
            _goodRepository.Delete(Id);
            _uow.Save();

        }


        public void DeletePhotoFromProjectByPath(int Id)
        {
            
            if (_goodRepository.Get(Id).Photos.Count > 0)
            { 
                foreach (var item in _goodRepository.Get(Id).Photos.Select(x => x.PhotoPath).ToList())
                {
                    var fullpath = HostingEnvironment.MapPath(item);
                    FileInfo fileInf = new FileInfo(fullpath);
                    if (fileInf.Exists)
                    {

                   
                        fileInf.Delete();
                        fileInf.Refresh();
                        var folder = new DirectoryInfo(Path.GetDirectoryName(fullpath));
                        if (folder.Exists && !fileInf.Exists)
                        {
                            Directory.Delete(Path.GetDirectoryName(fullpath), true);
                        }          
                    }
                 
                }
            }
        }



        private void FillEntityFromViewModel(Goods goods, GoodsViewModel goodsViewModel)
        {
            goods.Name = goodsViewModel.Name;
            goods.Price = goodsViewModel.Price;
            goods.Sex = goodsViewModel.Sex;
            goods.StockQuantity = goodsViewModel.StockQuantity;
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
