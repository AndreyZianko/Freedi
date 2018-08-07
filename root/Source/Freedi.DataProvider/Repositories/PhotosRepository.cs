﻿using Freedi.DataProvider.Entites;
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

     
    }
}
