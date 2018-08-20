using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Hosting;
using Freedi.DataProvider.Interfaces;
using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;

namespace Freedi.Logic.Managers
{
    public class PhotoManager : IPhotoManager
    {
        public PhotoManager(IPhotosRepository photosRepository, IGoodRepository goodRepository,
            IGoodsManager goodsManager, IUnitOfWork uow)
        {
            _photosRepository = photosRepository;
            _goodRepository = goodRepository;
            _goodsManager = goodsManager;
            _uow = uow;
        }

        private IPhotosRepository _photosRepository { get; }
        private IGoodRepository _goodRepository { get; }
        private IGoodsManager _goodsManager { get; }
        private IUnitOfWork _uow { get; }

        public List<string> GetPhotos(int idGoods)
        {
            throw new NotImplementedException();
        }


        public List<PhotosViewModel> UploadPhoto(List<HttpPostedFileBase> uploadfile, string name)
        {
            var imageDirectory = @"~/Content/PhotoProduct";
            var _photos = new List<PhotosViewModel>();
            {
                foreach (var photo in uploadfile)
                {
                    var goodsDirectory = Path.Combine(imageDirectory, name.Trim());
                    var goodsPhotoName = name.Trim() + Path.GetRandomFileName() + Path.GetExtension(photo.FileName);
                    var phisicalPathToDirectory = HostingEnvironment.MapPath(goodsDirectory);
                    var folder = new DirectoryInfo(phisicalPathToDirectory ?? throw new InvalidOperationException());
                    if (!string.IsNullOrEmpty(phisicalPathToDirectory))
                    {
                        if (!folder.Exists)
                            Directory.CreateDirectory(phisicalPathToDirectory);
                        var img = new WebImage(photo.InputStream);
                        img.Resize(250, 250);
                        img.Save(Path.Combine(phisicalPathToDirectory, goodsPhotoName));
                        var _photo = new PhotosViewModel
                        {
                            PhotoPath = Path.Combine(goodsDirectory, goodsPhotoName)
                        };
                        _photos.Add(_photo);
                    }
                }

                return _photos;
            }
        }


        public void UpdatePhoto(GoodsViewModel goods)
        {
            foreach (var photo in goods.Photo)
                if (photo.PhotoChange)
                {
                    DeletePhotoFromProjectByPhotoId(photo.PhotoId);
                    DeletePhotoByPhotoId(photo.PhotoId);
                }

            if (goods.UploadedFile.Count > 0)
                goods.Photo = UploadPhoto(goods.UploadedFile, goods.Name);
        }

        public void DeletePhotoByPhotoId(int photoId)
        {
            _photosRepository.Delete(photoId);
            _uow.Save();
        }

        public void DeletePhotoFromProjectByPhotoId(int photoId)
        {
            var pathbyid = _photosRepository.Get(photoId);
            var fullpath = HostingEnvironment.MapPath(pathbyid.Path);
            var fileInf = new FileInfo(fullpath ?? throw new InvalidOperationException());
            if (fileInf.Exists)
            {
                fileInf.Delete();
                fileInf.Refresh();
                var folder = new DirectoryInfo(Path.GetDirectoryName(fullpath) ?? throw new InvalidOperationException());
                if (folder.Exists && !fileInf.Exists) Directory.Delete(Path.GetDirectoryName(fullpath) ?? throw new InvalidOperationException(), true);
            }
        }

        public void Resize(HttpPostedFileBase uploadfile)
        {
        }
    }
}