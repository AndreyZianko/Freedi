using Freedi.DataProvider.Entites;

namespace Freedi.DataProvider.Interfaces
{
    public interface IGoodRepository : IRepository<Goods>
    {
        void Save();
    }
}