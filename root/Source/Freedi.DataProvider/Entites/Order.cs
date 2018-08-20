using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Freedi.DataProvider.Entites
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public virtual ICollection<CartLine> CartLines { get; set; } = new HashSet<CartLine>();
        public virtual ApplicationUser ApplicationUser { get; set; } 
    }
}