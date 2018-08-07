using System.Collections.Generic;
using System.Web;

namespace Freedi.Model.ViewModels
{
    public class GoodsViewModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string Unit { get; set; }
        public string Type { get; set; }
        public int StockQuantity { get; set; }
        public bool Stock { get; set; }
        public string SKU { get; set; }
        public string Photo { get; set; }
        public HttpPostedFileBase[] UploadedFile { get; set; }
        public string Description { get; set; }
        public string Sex { get; set; }
    }
}
