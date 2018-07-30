using Freedi.DataProvider.Interfaces;
using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;
using System.Collections.Generic;

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
                result.Add(new GoodsView
                {
                    Id = goods.Id,
                    Name = goods.Name,
                    Price = goods.Price,
                    Currency = goods.Currency,
                    Sex = goods.Sex,
                    Photo = goods.Photo,
                    StockQuantity = goods.StockQuantity,
                    SKU = goods.SKU,
                    Description = goods.Description,
                    Type = goods.Type,
                    Unit = goods.Unit,
                    Stock = goods.Stock
                           
                });
                
               
            }
            return result;
        }
        public GoodsView GetGoodsById(int? Id)
        {
            var _goods = _uow.Goods.Get(Id);
            return (new GoodsView
            {
                Id = _goods.Id,
                Name = _goods.Name,
                Price = _goods.Price,
                Currency = _goods.Currency,
                Sex = _goods.Sex,
                Photo = _goods.Photo,
                StockQuantity = _goods.StockQuantity,
                SKU = _goods.SKU,
                Description = _goods.Description,
                Type = _goods.Type,
                Unit = _goods.Unit,
                Stock = _goods.Stock
            });
        }
    }
}
