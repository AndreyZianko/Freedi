using Freedi.Logic.Managers;
using Freedi.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.Logic.Interfaces
{
    public interface IGoodsManager
    {
        List<GoodsViewModel> GetGoods();
        GoodsViewModel GetGoodsById(int? Id);
        bool GoodsUpdate(GoodsViewModel g);
    }
}
