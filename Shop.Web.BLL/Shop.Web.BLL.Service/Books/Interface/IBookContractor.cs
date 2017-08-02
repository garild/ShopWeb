using Shop.Web.BLL.Data.Enum;
using Shop.Web.BLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Web.BLL.Service.Books.Interface
{
    [ServiceContract]
    public interface IBookContractor
    {
        [OperationContract]
        List<Book> GetAllBooks();
        [OperationContract]
        List<Book> FindBooks(BookType bookType, string title, string publisher);
    }
}
