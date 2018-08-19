using System.Collections.Generic;
using System.Web;
using Freedi.Model.ViewModels;

namespace Freedi.Logic.Interfaces
{
    public interface IPhotoManager
    {
        List<PhotosViewModel> UploadPhoto(List<HttpPostedFileBase> uploadfile, string name);
        void DeletePhotoByPhotoId(int id);
        List<string> GetPhotos(int idGoods);
        void UpdatePhoto(GoodsViewModel photo);
        void DeletePhotoFromProjectByPhotoId(int photoId);
    }
}