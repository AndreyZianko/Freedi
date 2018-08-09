using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Identity;
using Freedi.DataProvider.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace Freedi.DataProvider.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public FreediContext _context { get; set; }
        public UnitOfWork(FreediContext context)
        {
            _context = context;
        }
     
        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}

