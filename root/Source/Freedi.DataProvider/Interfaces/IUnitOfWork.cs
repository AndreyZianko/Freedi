namespace Freedi.DataProvider.Interfaces
{
    public interface IUnitOfWork 
    {
        IGoodRepository Goods{ get; }
        IOrderRepository Orders{ get; }
        void Save();
    }
}
