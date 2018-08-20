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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public virtual ICollection<CartLine> CartLines { get; set; } = new List<CartLine>();
        public DateTime Date { get; set; }
        public string ClientName { get; set; }
        public virtual ClientProfile ClientProfile { get; set; }
        public int ClientProfileId { get; set; }


    }
}