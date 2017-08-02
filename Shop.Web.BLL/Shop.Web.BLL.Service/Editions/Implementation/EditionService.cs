using System.Collections.Generic;
using DataLayer.Entities.Context.Respository;
using System.Linq;
using Shop.Web.BLL.Data.Models;
using DataLayer;

namespace Shop.Web.BLL.Service.Editions.Implementation
{
    public class EditionService
    {
        // DIP
        public readonly IEdition repository;
        public EditionService(IEdition medium)
        {
            medium = repository;
        }

    }
    public class Editions : IEdition
    {
        public List<Edition> GetData()
        {
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                return _ctx.Context.Editions.ToList();
            }
        }
    }
}
