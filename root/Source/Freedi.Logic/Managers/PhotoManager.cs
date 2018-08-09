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
using System.Web.Hosting;

namespace Freedi.Logic.Managers
{
    public class PhotoManager : IPhotoManager
    {

        private IPhotosRepository _photosRepository {get;set;}
        private IGoodRepository _goodRepository { get; set; }
        public PhotoManager(IPhotosRepository photosRepository, IGoodRepository goodRepository)
        {
            _photosRepository = photosRepository;
            _goodRepository = goodRepository;


        }

        public List<string> GetPhotos(int IdGoods)
        {
            throw new NotImplementedException();
        }

        public void UpdatePhoto(int Id)
        {
            throw new NotImplementedException();
        }

        public List<PhotosViewModel> UploadPhoto(List<HttpPostedFileBase> _uploadfile, string name)
        {
            var imageDirectory = @"~/Content/PhotoProduct";
            List<PhotosViewModel> _photos = new List<PhotosViewModel>();
            PhotosViewModel _photo = new PhotosViewModel();
            if(!string.IsNullOrEmpty(imageDirectory))
            {
                var goodsDirectory = Path.Combine(imageDirectory, name);
                var goodsPhotoName = name + Path.GetExtension(_uploadfile.Select(x => x.FileName).FirstOrDefault());
                var phisicalPathToDirectory = HostingEnvironment.MapPath(goodsDirectory);
                if (!string.IsNullOrEmpty(phisicalPathToDirectory))
                    Directory.CreateDirectory(phisicalPathToDirectory);
                _uploadfile[0].SaveAs(Path.Combine(phisicalPathToDirectory, goodsPhotoName));
                _photo.PhotoPath = Path.Combine(goodsDirectory, goodsPhotoName);
                _photos.Add(_photo);
                return _photos;

            }
            throw new Exception("");
        }

        public void DeletePhoto(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
