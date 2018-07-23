using Freedi.DataProvider.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.DataProvider.Interfaces
{
    public interface IClientManager
    {
        void Create(ClientProfile item);
    }
}
