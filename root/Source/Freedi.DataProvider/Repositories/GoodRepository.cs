using Freedi.DataProvider.Interfaces;
using Freedi.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.DataProvider.Repositories
{
    public class GoodRepository : BaseRepository<Good> , IGoodRepository
    {
        private FreediContext _context;

        public GoodRepository(FreediContext context) : base(context)
        {
            _context = context;
        }
    }
}
