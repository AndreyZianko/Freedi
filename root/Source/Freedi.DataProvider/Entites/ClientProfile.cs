﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Freedi.DataProvider.Entites
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Order> Orders{ get; set;} = new HashSet<Order>();
    }
}