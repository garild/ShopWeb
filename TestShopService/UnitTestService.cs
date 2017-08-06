using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestShopService.BookConctractor;

namespace TestShopService
{
    [TestClass]
    public class UnitTestService
    {
        [TestMethod]
        public void Check_If_Data_Is_Not_Null()
        {
            var _service = new BookContractorClient();
            var result = _service.GetAllBooks();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Search_Data_By_Paramas_Audiobooks_NullParams()
        {
            var _service = new BookContractorClient();
            var bookType = BookType.AudioBooks;
            var result = _service.FindBooks(bookType, null, null);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Search_Data_By_Paramas_AudioBooks_NotNull()
        {
            var _service = new BookContractorClient();
            string title = "Uwod";
            string publisher = "g";
            var result = _service.FindBooks(BookType.AudioBooks, title, publisher);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Find_E_Book()
        {
            var _service = new BookContractorClient();
            var bookType = BookType.EBooks;
            string title = "Zaburzenie";
            string publisher = "OSP";
            var result1 = _service.FindBooks(bookType, title, publisher);

            Assert.IsTrue(result1.Length > 0);
        }

        [TestMethod]
        public void Compare_AllBooks_SearchBooks()
        {
            var _service = new BookContractorClient();
            var bookType = BookType.EBooks;
            string title = "";
            string publisher = "G";
            var result1 = _service.FindBooks(bookType, title, publisher);
            var result2 = _service.GetAllBooks();

            Assert.AreNotSame(result1, result2);
        }

    }
}
