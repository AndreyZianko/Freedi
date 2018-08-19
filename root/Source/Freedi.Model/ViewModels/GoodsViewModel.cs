using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Freedi.Model.ValidateImage;

namespace Freedi.Model.ViewModels
{
    public class GoodsViewModel
    {
        public GoodsViewModel()
        {
            UploadedFile = new List<HttpPostedFileBase>();
            Photo = new List<PhotosViewModel>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public string Type { get; set; }

        public int StockQuantity { get; set; }
        public bool Stock { get; set; }
        public List<PhotosViewModel> Photo { get; set; }
        public int PhotoCount { get; set; }

        [FileType("JPG,JPEG,PNG")] public List<HttpPostedFileBase> UploadedFile { get; set; }

        [Required] public string Description { get; set; }

        [Required] public string Sex { get; set; }
    }
}