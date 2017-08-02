using System.Collections.Generic;
using DataLayer.Entities.Context.Respository;
using System.Linq;
using Shop.Web.BLL.Data.Models;
using DataLayer;

namespace Shop.Web.BLL.Service.Mediums.Implementation
{
    public class MediumService 
    {
        // DIP
        public readonly IMedium repository;
        public MediumService(IMedium medium)
        {
            medium = repository;
        }

    }
    public class Mediums : IMedium
    {
        public List<Medium> GetDataDupa()
        {
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                return _ctx.Context.Mediums.ToList();
            }
        }
    }

}
