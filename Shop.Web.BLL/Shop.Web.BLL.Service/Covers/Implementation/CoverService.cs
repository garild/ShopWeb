using System.Collections.Generic;
using DataLayer.Entities.Context.Respository;
using System.Linq;
using DataLayer;
using Shop.Web.BLL.Data.Models;

namespace Shop.Web.BLL.Service.Covers.Implementation
{
    public class CoverService
    {
        // DIP
        public readonly ICover repository;
        public CoverService(ICover cover)
        {
            repository = cover;
        }

    }
    public class Covers : ICover
    {
        public List<Cover> GetData()
        {
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                return _ctx.Context.Covers.ToList();
            }
        }
    }
}
