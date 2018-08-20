using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Interfaces;

namespace Freedi.DataProvider.Repositories
{
    public class GoodsRepository : BaseRepository<Goods>, IGoodRepository
    {
        private readonly FreediContext _context;

        public GoodsRepository(FreediContext context) : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}