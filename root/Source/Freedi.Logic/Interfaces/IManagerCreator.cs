using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.Logic.Interfaces
{
    interface IManagerCreator
    {
        IUserManager CreateUserManager();
    }
}
