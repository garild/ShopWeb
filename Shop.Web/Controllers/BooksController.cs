using System.Collections.Generic;
using System.Web.Mvc;
using Shop.Web.Products.Shop;
using Shop.Web.BLL.Service.Books.Implementation;

namespace Shop.Web.Controllers
{
    public class BooksController : Controller
    {
        public List<ShopCart> Cart
        {
            get
            {
                return Session["ShopCart"] as List<ShopCart>;
            }
            set
            {
                Session["ShopCart"] = value;
            }
        }
        public BooksController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }

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
            Promotions _services = new Promotions();
            var result = _services.GetBooks();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetUpComming()
        {
            Upcomming _services = new Upcomming();
            var result = _services.GetBooks();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetCart()
        {
            return new JsonResult { Data = Cart, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult OrderBook(ShopCart item)
        {
          
            if (Cart != null)
            {
                var idnex = Cart.IndexOf(item);
                if (idnex > 0)
                    Cart[idnex].Quantity += item.Quantity;
                else
                {
                    Cart.Add(item);
                }
                
            }
                
            return new JsonResult { Data = Cart, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}