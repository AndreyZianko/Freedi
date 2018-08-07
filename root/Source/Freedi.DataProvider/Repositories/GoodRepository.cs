using Freedi.DataProvider.Interfaces;
using Freedi.DataProvider.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Freedi.DataProvider.Repositories
{
    public class GoodRepository : BaseRepository<Goods> , IGoodRepository
    {
        private FreediContext _context;
       
        public GoodRepository(FreediContext context) : base(context)
        {
            _context = context;
           
        }
    }
}
