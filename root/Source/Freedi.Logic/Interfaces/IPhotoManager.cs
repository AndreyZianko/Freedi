﻿using Freedi.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Freedi.Logic.Interfaces
{
   public interface IPhotoManager
    {
        List<PhotosViewModel> UploadPhoto(List<HttpPostedFileBase> _uploadfile, string name);
        void DeletePhoto(int Id);
        void UpdatePhoto(int Id);
        List<string> GetPhotos(int IdGoods);
    }
}
