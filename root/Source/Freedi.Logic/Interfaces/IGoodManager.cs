using Freedi.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.Logic.Interfaces
{
    public interface IGoodManager
    {
        List<GoodsManager> GetGoods();
    }
}
