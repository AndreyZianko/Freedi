using System.Collections.Generic;
using System.Linq;
using Freedi.Model.ViewModels;

namespace Freedi.Logic.Managers
{
    public class CartManager
    {
        private readonly CartViewModel _cart = new CartViewModel();

        public IEnumerable<CartLine> Lines => _cart.Lines;

        public void AddItem(GoodsViewModel goodsViewModel, int quantity)
        {
            var line = _cart.Lines.FirstOrDefault(g => g.Goods.Id == goodsViewModel.Id);

            if (line == null)
                _cart.Lines.Add(new CartLine
                {
                    Goods = goodsViewModel,
                    Quantity = quantity
                });
            else
                line.Quantity += quantity;
        }

        public void RemoveLine(int id)
        {
            _cart.Lines.RemoveAll(l => l.Goods.Id == id);
        }

        public decimal TotalValue()
        {
            return _cart.Lines.Sum(e => e.Goods.Price * e.Quantity);
        }

        public int TotalGoods()
        {
            return _cart.Lines.Select(x => x.Quantity).Sum();
        }

        public void Clear()
        {
            _cart.Lines.Clear();
        }

        public CartViewModel CartFull()
        {
            if (_cart.Lines != null)
            {
                _cart.TotalValue = TotalValue();
                _cart.TotalGoods = TotalGoods();
            }

            return _cart;
        }
    }

    public class CartLine
    {
        public GoodsViewModel Goods { get; set; }
        public int Quantity { get; set; }
    }

    public class CartViewModel
    {
        public CartViewModel()
        {
            Lines = new List<CartLine>();
        }

        public List<CartLine> Lines { get; set; }


        public int TotalGoods { get; set; }
        public decimal TotalValue { get; set; }
    }
}