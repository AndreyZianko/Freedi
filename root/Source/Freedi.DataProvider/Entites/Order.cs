using System;
using System.ComponentModel.DataAnnotations.Schema;
using Freedi.DataProvider.Entites;

namespace Freedi.DataProvider.Models
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int GoodId { get; set; }
        public Goods Good { get; set; }
        public DateTime Date { get; set; }
    }
}