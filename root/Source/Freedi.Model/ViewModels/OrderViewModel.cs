using System;

namespace Freedi.Model.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int GoodId { get; set; }
        public DateTime Date { get; set; }
    }
}
