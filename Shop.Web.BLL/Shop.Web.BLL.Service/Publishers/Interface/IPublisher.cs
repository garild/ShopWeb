using Shop.Web.BLL.Data.Models;
using System.Collections.Generic;

namespace Shop.Web.BLL.Service.Publishers.Implementation
{
    public interface IPublisher
    {
        List<Publisher> GetData();
    }

}
