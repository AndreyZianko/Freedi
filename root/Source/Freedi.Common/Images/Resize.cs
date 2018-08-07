using Freedi.Model.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text;
using System.Web;
using System.Web.Helpers;

namespace Freedi.Common.Images
{

    public static class Resize
    {
        public static List<PhotosViewModel> ResizeImg(this List<HttpPostedFileBase> _uploadfile, string name)
        {
            List<PhotosViewModel> paths = new List<PhotosViewModel>();
          
            foreach (var uploadfile in _uploadfile)
            {
                WebImage img = new WebImage(uploadfile.InputStream);
                img.Resize(250, 250);
         
                string Pth = Path.Combine(@"..\Content\PhotoProduct\" + name.Trim() + Path.GetRandomFileName()
                +"__" + "250x250" + Path.GetExtension(uploadfile.FileName)).Trim();
                img.Save(Pth);
                paths.Add(new PhotosViewModel
                {
                    PhotoPath = Pth
                });

                img.Resize(500, 500);
          
                string pth = Path.Combine(@"..\Content\PhotoProduct\" + name.Trim() + Path.GetRandomFileName() + "__" + "500x500" + Path.GetExtension(uploadfile.FileName)).Trim();
                img.Save(pth);

                paths.Add(new PhotosViewModel
                {
                    PhotoPath = pth
                });

            }
            return paths;
        }

    }
}
