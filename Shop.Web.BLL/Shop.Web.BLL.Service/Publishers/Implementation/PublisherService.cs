using System.Collections.Generic;
using DataLayer.Entities.Context.Respository;
using System.Linq;
using Shop.Web.BLL.Data.Models;
using DataLayer;

namespace Shop.Web.BLL.Service.Publishers.Implementation
{
    public class PublisherService
    {
        // DIP
        public readonly IPublisher repository;
        public PublisherService(IPublisher medium)
        {
            medium = repository;
        }

    }
    public class Publishers : IPublisher
    {
        public List<Publisher> GetData()
        {
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                return _ctx.Context.Publishers.ToList();
            }
        }
    }
}
