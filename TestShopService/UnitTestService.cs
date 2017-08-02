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
        public void Search_Data_By_Null_Paramas_Result_IsDefault_Type()
        {

            var _service = new BookContractorClient();
            var bookType = BookType.AudioBooks;
            string title = null;
            string publisher = null;
            var result = _service.FindBooks(bookType, null, null);

            Assert.AreNotSame(result, new Book());
           
        }

      

        [TestMethod]
        public void Search_Data_By_Paramas_Audiobooks()
        {
            var _service = new BookContractorClient();
            var bookType = BookType.AudioBooks;
            string title = "";
            string publisher = "G";
            var result = _service.FindBooks(bookType, title, publisher);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Search_Data_By_Paramas_News_NotNull()
        {
            var _service = new BookContractorClient();
            var bookType = BookType.News;
            string title = "Uwod";
            string publisher = "g";
            var result = _service.FindBooks(bookType, title, publisher);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Compare_AllBooks_SearchBooks()
        {
            var _service = new BookContractorClient();
            var bookType = BookType.SuperOccasions;
            string title = "";
            string publisher = "G";
            var result1 = _service.FindBooks(bookType, title, publisher);
            var result2 = _service.GetAllBooks();

            Assert.AreNotSame(result1, result2);
        }

        [TestMethod]
        public void Find_1_Book()
        {
            var _service = new BookContractorClient();
            var bookType = BookType.SuperOccasions;
            string title = "Zaburzenie";
            string publisher = "OSP";
            var result1 = _service.FindBooks(bookType, title, publisher);
          

            Assert.IsTrue(result1.Length == 1);
        }
    }
}
