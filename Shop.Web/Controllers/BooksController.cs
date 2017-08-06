using System.Collections.Generic;
using System.Web.Mvc;
using Shop.Web.Products.Shop;
using Shop.Web.BLL.Service.Books.Implementation;

namespace Shop.Web.Controllers
{
    public class BooksController : Controller
    {
        //TODO Split to controllers New,Ebooks etc
        //TODO route prefix  AllBooks,News

        private static readonly AllBooks _allbookRepo = new AllBooks();
        private static readonly AudioBooks _audiobookRepo = new AudioBooks();
        private static readonly EBooks _ebookRepo = new EBooks();
        private static readonly News _newsRepo = new News();
        private static readonly Upcomming _upcommingRepo = new Upcomming();
        private static readonly SuperPromotions _promoRepo = new SuperPromotions();

        public BooksController()
        {

        }


        public ActionResult Index()
        {
            return View();
        }

        #region FindBook

        public JsonResult FindBookAll(int search)
        {
            var result = _allbookRepo.FindBook(search);
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult FindBookAudiotbooks(int search)
        {
          
            var result = _audiobookRepo.FindBook(search);
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public JsonResult FindEBook(int search)
        {
           
            var result = _ebookRepo.FindBook(search);
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public JsonResult FindNews(int search)
        {
          
            var result = _newsRepo.FindBook(search);
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public JsonResult FindPromotions(int search)
        {

            var result = _promoRepo.FindBook(search);
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public JsonResult FindUpcomming(int search)
        {

            var result = _upcommingRepo.FindBook(search);
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        #endregion

        #region GetBook

        public JsonResult GetAllBooks()
        {
            var result = _allbookRepo.GetBooks();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetAudioBooks()
        {
            var result = _audiobookRepo.GetBooks();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetEBooks()
        {
            var result = _ebookRepo.GetBooks();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetNews()
        {
            var result = _newsRepo.GetBooks();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetPromotions()
        {
            var result = _promoRepo.GetBooks();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetUpComming()
        {
          
            var result = _upcommingRepo.GetBooks();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        #endregion
    }
}