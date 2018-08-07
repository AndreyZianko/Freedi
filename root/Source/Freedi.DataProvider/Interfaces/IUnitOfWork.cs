﻿using Freedi.DataProvider.Identity;
using System.Threading.Tasks;

namespace Freedi.DataProvider.Interfaces
{
    public interface IUnitOfWork 
    {
        IGoodRepository Goods{ get; }
        IOrderRepository Orders{ get; }
        IClientRepository Users { get; }
        IPhotosRepository Photos { get; }
        void Save();
        Task SaveAsync();
    }
}
