using Freedi.DataProvider.Interfaces;
using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.Logic.Managers
{
    public class GoodsManager : IGoodsManager
    {
        IUnitOfWork _uow { get; set; }
       public GoodsManager(IUnitOfWork uow)
        {
            _uow = uow;

        }
        public List<GoodsView> GetGoods()
        {
            var allgoods = _uow.Goods.GetAll();
            var result = new List<GoodsView>();
            foreach (var goods in allgoods)
            {
                if(goods.Stock)
                {
                        result.Add(new GoodsView
                        {
                            Id = goods.Id,
                            Name = goods.Name,
                            Price = goods.Price,
                            Currency =goods.Currency,
                            Sex = goods.Sex,
                            Photo = goods.Photo,
                            StockQuantity = goods.StockQuantity,
                            SKU = goods.SKU,
                            Description = goods.Description,
                            Type = goods.Type,
                            Unit = goods.Unit
                        });
                   
                }
               
            }
            return result;
        }
    }
}
