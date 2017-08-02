using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Shop.Web.BLL.Data.Enum;
using Shop.Web.BLL.Data.Models;
using DataLayer.Entities.Context.Respository;
using DataLayer;
using Shop.Web.BLL.Service.Books.Interface;
using Shop.Web.BLL.Service.Books.Implementation;

namespace Shop.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShopService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ShopService.svc or ShopService.svc.cs at the Solution Explorer and start debugging.
    public class ShopService : IBookContractor
    {
        private static readonly BookContractor _service = new BookContractor();
        public List<Book> FindBooks(BookType bookType, string title, string publisher)
        {
            return _service.FindBooks(bookType, title, publisher);
        }

        public List<Book> GetAllBooks()
        {
            return _service.GetAllBooks();
        }
    }
}
