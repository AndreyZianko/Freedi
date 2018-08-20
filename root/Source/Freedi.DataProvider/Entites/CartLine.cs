using System.ComponentModel.DataAnnotations;

namespace Freedi.DataProvider.Entites
{
    public class CartLine
    {
        [Key]
        public int Id { get; set; }
        public int GoodsId { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Goods Goods { get; set; }
    }
}
