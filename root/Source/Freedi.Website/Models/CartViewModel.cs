using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freedi.Website.Models
{
    public class CartViewModel
    {
       
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}