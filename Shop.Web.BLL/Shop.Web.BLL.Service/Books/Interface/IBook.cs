using Shop.Web.BLL.Data.Enum;
using Shop.Web.BLL.Data.Models;
using System.Collections.Generic;

namespace Shop.Web.BLL.Service.Books.Interface
{

    public interface IBook
    {
        List<Book> GetBooks();
        List<Book> FindBook(int search);
    }

}
