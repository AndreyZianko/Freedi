using Freedi.DataProvider.Entites;

namespace Freedi.DataProvider.Interfaces
{
    public interface IPhotosRepository : IRepository<Photos>
    {
        void DeletePhotoByGoodsId(int id);
    }
}