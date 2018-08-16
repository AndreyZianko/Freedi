using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Interfaces;
using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Hosting;

namespace Freedi.Logic.Managers
{
    public class PhotoManager : IPhotoManager
    {

        private IPhotosRepository _photosRepository {get;set;}
        private IGoodRepository _goodRepository { get; set; }
        private IGoodsManager _goodsManager { get; set; }
        private IUnitOfWork _uow { get; set; }
        public PhotoManager(IPhotosRepository photosRepository, IGoodRepository goodRepository, IGoodsManager goodsManager,IUnitOfWork uow)
        {
            _photosRepository = photosRepository;
            _goodRepository = goodRepository;
            _goodsManager = goodsManager;
            _uow = uow;
        }

        public List<string> GetPhotos(int IdGoods)
        {
            throw new NotImplementedException();
        }

    
        public List<PhotosViewModel> UploadPhoto(List<HttpPostedFileBase> _uploadfile, string name)
        {
            var imageDirectory = @"~/Content/PhotoProduct";
            List<PhotosViewModel> _photos = new List<PhotosViewModel>();
            {
                foreach (var photo in _uploadfile)
                {

                    var goodsDirectory = Path.Combine(imageDirectory, name.Trim());
                    var goodsPhotoName = name.Trim() + Path.GetRandomFileName()+Path.GetExtension(photo.FileName);
                    var phisicalPathToDirectory = HostingEnvironment.MapPath(goodsDirectory);
                    var folder = new DirectoryInfo(phisicalPathToDirectory);
                    if (!string.IsNullOrEmpty(phisicalPathToDirectory))
                    {
                      
                        if(!folder.Exists)
                        Directory.CreateDirectory(phisicalPathToDirectory);
                        WebImage img = new WebImage(photo.InputStream);
                        img.Resize(250, 250);
                        img.Save(Path.Combine(phisicalPathToDirectory, goodsPhotoName));
                        PhotosViewModel _photo = new PhotosViewModel(){
                         PhotoPath = Path.Combine(goodsDirectory, goodsPhotoName)};
                        _photos.Add(_photo);
                   
                    }
                }
                return _photos;
            }
            throw new Exception("");
        }



        public void UpdatePhoto(GoodsViewModel goods)
        {
            foreach (var photo in goods.Photo)
            {
                if (photo.PhotoChange)
                {

                    DeletePhotoFromProjectByPhotoId(photo.PhotoId);
                    DeletePhotoByPhotoId(photo.PhotoId);
                }

            }
            if (goods.UploadedFile.Count > 0)
                goods.Photo = UploadPhoto(goods.UploadedFile, goods.Name);
        }

        public void Resize (HttpPostedFileBase uploadfile)
        {
          
        }
        public void DeletePhotoByPhotoId(int PhotoId)
        {
            _photosRepository.Delete(PhotoId);
            _uow.Save();
        }
        public void DeletePhotoFromProjectByPhotoId(int PhotoId )
        {
            var pathbyid = _photosRepository.Get(PhotoId);
            var fullpath = HostingEnvironment.MapPath(pathbyid.PhotoPath);
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
