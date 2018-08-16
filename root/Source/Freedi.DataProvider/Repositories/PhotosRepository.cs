using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.DataProvider.Repositories
{
    public class PhotosRepository : BaseRepository<Photos>, IPhotosRepository
    {
        FreediContext _context;
        public PhotosRepository(FreediContext context) : base(context)
        {
            _context = context;
        }

        public void DeletePhotoByGoodsId(int id)
        {
            
            foreach (var item in _context.Photos.Where(x => x.GoodsId == id).ToList())
            {
                _context.Photos.Remove(item);
                _context.SaveChanges();
            }
          
          
        }
     
    }
}
