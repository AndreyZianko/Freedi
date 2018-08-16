using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freedi.DataProvider.Entites;

namespace Freedi.DataProvider.Interfaces
{
    public interface IPhotosRepository : IRepository<Photos>
    {
       void DeletePhotoByGoodsId(int id);
    }
}
