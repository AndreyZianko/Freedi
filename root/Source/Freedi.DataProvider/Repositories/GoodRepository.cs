using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Interfaces;
using Freedi.DataProvider.Models;

namespace Freedi.DataProvider.Repositories
{
    public class GoodRepository : BaseRepository<Goods>, IGoodRepository
    {
        private readonly FreediContext _context;

        public GoodRepository(FreediContext context) : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}