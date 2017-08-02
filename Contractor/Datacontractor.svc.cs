using System.Collections.Generic;
using Shop.Web.BLL.Data.Models;
using Shop.Web.BLL.Service.Books.Implementation;

namespace Contractor
{
    public class Datacontractor : IDataContractor
    {
        private readonly BookContractor _service;
        public Datacontractor()
        {
            _service = new BookContractor();
        }
        public List<Book> FindBooks(string title, string publisher)
        {
            return _service.FindBooks(title, publisher);
        }

        public List<Book> GetAllBooks()
        {
            return _service.GetAllBooks();
        }

      
    }
}
