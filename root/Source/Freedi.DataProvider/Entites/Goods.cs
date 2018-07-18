using System.ComponentModel.DataAnnotations.Schema;

namespace Freedi.DataProvider.Models
{
    [Table("Goods")]
    public class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public string Type { get; set; }
        public int StockQuantity { get; set; }
        public bool Stock { get; set; }
        public string SKU { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }

    }
}

