using System.Collections.Generic;

namespace Freedi.Model.ViewModels.CartModels
{
    public class CartViewModel
    {
        public List<CartLineView> Lines { get; set; } = new List<CartLineView>();
        public int TotalGoods { get; set; }
        public decimal TotalValue { get; set; }
    }
}
