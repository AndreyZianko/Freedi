using Freedi.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.DataProvider
{
    public interface IFreediContext
    {
        DbSet<Good> Goods { get; set; }
        DbSet<Order> Orders { get; set; }
        
    }
}
