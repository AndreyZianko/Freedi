using System.Linq;
using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Interfaces;

namespace Freedi.DataProvider.Repositories
{
    public class PhotosRepository : BaseRepository<Photos>, IPhotosRepository
    {
        private readonly FreediContext _context;

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