using System;
using System.Collections.Generic;
using Freedi.Model.ViewModels.CartModels;

namespace Freedi.Model.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public CartViewModel CartModel {get; set; }
        public string ClientName { get; set; }
    }
}