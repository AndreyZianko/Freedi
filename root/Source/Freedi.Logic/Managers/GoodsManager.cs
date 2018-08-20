using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Interfaces;
using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;

namespace Freedi.Logic.Managers
{
    public class GoodsManager : IGoodsManager
    {
        public GoodsManager(IUnitOfWork uow, IGoodRepository goodRepository,
            IOrderRepository orderRepository, IPhotosRepository photosRepository)
        {
            Uow = uow;
            GoodRepository = goodRepository;
            OrderRepository = orderRepository;
            PhotosRepository = photosRepository;
        }

        private IUnitOfWork Uow { get; }
        private IGoodRepository GoodRepository { get; }
        private IOrderRepository OrderRepository { get; }
        private IPhotosRepository PhotosRepository { get; }

        public List<GoodsViewModel> GetGoods()
        {
            return GoodRepository.GetAll().Select(goods => new GoodsViewModel
            {
                Id = goods.Id,
                Name = goods.Name,
                Price = goods.Price,
                Currency = goods.Currency,
                Sex = goods.Sex,
                StockQuantity = goods.StockQuantity,
                Photo = goods.Photos.Select(ph => new PhotosViewModel { PhotoId = ph.Id, PhotoPath = ph.Path })
                    .ToList(),
                PhotoCount = goods.Photos.Count(),
                Description = goods.Description,
                Type = goods.Type,
                Stock = goods.Stock
            }).ToList();
        }

        public GoodsViewModel GetGoodsById(int? id)
        {
            var goods = GoodRepository.Get(id) ?? null;
            if (goods != null)
                return new GoodsViewModel
                {
                    Id = goods.Id,
                    Name = goods.Name,
                    Price = goods.Price,
                    Currency = goods.Currency,
                    Sex = goods.Sex,
                    Photo = goods.Photos
                        .Select(ph => new PhotosViewModel { PhotoId = ph.Id, PhotoPath = ph.Path })
                        .ToList(),
                    PhotoCount = goods.Photos.Count,
                    StockQuantity = goods.StockQuantity,
                    Description = goods.Description,
                    Type = goods.Type,
                    Stock = goods.Stock
                };

            return null;
        }

        public void GoodsUpdate(GoodsViewModel goodsViewModel)
        {

            var goods = GoodRepository.Get(goodsViewModel.Id);
            if (goods != null)
            {
                fillGoodModelForUpdate(goods, goodsViewModel);
                GoodRepository.Update(goods);
                Uow.Save();
            }
        }


        public void CreateProduct(GoodsViewModel goodsViewModel)
        {

            if (goodsViewModel != null)
            {
                var goods = new Goods();
                FillEntityFromViewModel(goods, goodsViewModel);
                GoodRepository.Create(goods);
                Uow.Save();
            }

        }


        public void DeleteProduct(int id)
        {

            DeletePhotoFromProjectByPath(id);
            GoodRepository.Delete(id);
            Uow.Save();
        }


        public void DeletePhotoFromProjectByPath(int id)
        {

            if (GoodRepository.Get(id) != null && GoodRepository.Get(id).Photos.Count > 0)
                foreach (var item in GoodRepository.Get(id).Photos.Select(x => x.Path).ToList())
                {
                    var fullpath = HostingEnvironment.MapPath(item);
                    var fileInf = new FileInfo(fullpath ?? throw new InvalidOperationException());
                    if (fileInf.Exists)
                    {
                        fileInf.Delete();
                        fileInf.Refresh();
                        var folder =
                            new DirectoryInfo(Path.GetDirectoryName(fullpath) ?? throw new InvalidOperationException());
                        if (folder.Exists && !fileInf.Exists)
                            Directory.Delete(Path.GetDirectoryName(fullpath) ?? throw new InvalidOperationException(),
                                true);
                    }
                }
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
                if (photo.PhotoPath != null)
                    goods.Photos.Add(new Photos { Path = photo.PhotoPath });
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

            foreach (var photo in goodsViewModel.Photo) goods.Photos.Add(new Photos { Path = photo.PhotoPath });
        }
    }
}