using System.Threading.Tasks;
using Freedi.DataProvider.Interfaces;

namespace Freedi.DataProvider.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(FreediContext context)
        {
            Context = context;
        }

        private FreediContext Context { get; set; }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}