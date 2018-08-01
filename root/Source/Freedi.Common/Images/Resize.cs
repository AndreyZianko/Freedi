using System.IO;
using System.Web;
using System.Web.Helpers;

namespace Freedi.Common.Images
{

    public static class Resize
    {
        public static string ResizeImg(this HttpPostedFileBase _uploadfile, string name)
        {
            string Pth = Path.Combine(@"..\Content\PhotoProduct\" + name + Path.GetExtension(_uploadfile.FileName)).Trim();
            WebImage img = new WebImage(_uploadfile.InputStream);
            if (img.Width > 500)
                img.Resize(250, 250);
            img.Save(Pth);

            return Pth;
        }
    }
}
