using System.Collections.Generic;
using System.Web.Mvc;
using Shop.Web.Products.Shop;
using Shop.Web.BLL.Service.Books.Implementation;

namespace Shop.Web.Controllers
{
    public class BooksController : Controller
    {
      

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
            AllBooks _services = new AllBooks();
            var result = _services.FindBook(search);
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        #endregion

        #region GetBook

        public JsonResult GetAllBooks()
        {
            AllBooks _services = new AllBooks();
            var result = _services.GetBooks();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetAudioBooks()
        {
            AudioBooks _services = new AudioBooks();
            var result = _services.GetBooks();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetEBooks()
        {
            EBooks _services = new EBooks();
            var result = _services.GetBooks();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetNews()
        {
            News _services = new News();
            var result = _services.GetBooks();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetPromotions()
        {
            SuperPromotions _services = new SuperPromotions();
            var result = _services.GetBooks();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetUpComming()
        {
            Upcomming _services = new Upcomming();
            var result = _services.GetBooks();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        #endregion
    }
}