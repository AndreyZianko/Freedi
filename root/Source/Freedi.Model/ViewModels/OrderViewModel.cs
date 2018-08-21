using Freedi.Model.ViewModels.CartModels;
using System.Collections.Generic;

namespace Freedi.Model.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public IEnumerable<CartLineView> CartLineView { get; set; }
        public string ApplicationUserId { get; set; }
        public List<GoodsViewModel> Goods { get; set; }
    }
}