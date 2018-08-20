using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Freedi.DataProvider.Entites
{
    [Table("Goods")]
    public class Goods
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string Type { get; set; }
        public int StockQuantity { get; set; }
        public bool Stock { get; set; }
        public string Description { get; set; }
        public string Sex { get; set; }

        public virtual ICollection<Photos> Photos { get; set; } = new HashSet<Photos>();
        public virtual ICollection<CartLine> CartLines { get; set; } = new HashSet<CartLine>();
    }
}