using Freedi.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.DataProvider.Entites
{
    public class Photos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhotoId { get; set; }
        public string PhotoPath { get; set; }
        public virtual Goods Goods { get; set; }
        public int GoodsId { get; set; }
    }
}
