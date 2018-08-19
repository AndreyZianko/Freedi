using System.Collections.Generic;
using Freedi.Model.ViewModels;

namespace Freedi.Logic.Interfaces
{
    public interface IGoodsManager
    {
        List<GoodsViewModel> GetGoods();
        GoodsViewModel GetGoodsById(int? id);
        void GoodsUpdate(GoodsViewModel goodsViewModel);
        void CreateProduct(GoodsViewModel goodsViewModel);
        void DeleteProduct(int id);
    }
}