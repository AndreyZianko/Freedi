using Freedi.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freedi.Website.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(GoodsViewModel goodsViewModel, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Goods.Id == goodsViewModel.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Goods = goodsViewModel,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(GoodsViewModel goodsView)
        {
            lineCollection.RemoveAll(l => l.Goods.Id == goodsView.Id);
        }

        public decimal TotalValue()
        {
            return lineCollection.Sum(e => e.Goods.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public GoodsViewModel Goods { get; set; }
        public int Quantity { get; set; }
    }
}
