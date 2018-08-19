using System.Threading.Tasks;

namespace Freedi.DataProvider.Interfaces
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();
    }
}