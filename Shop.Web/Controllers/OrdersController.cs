using Shop.Web.Products.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class OrdersController : Controller
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
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetOrdersList()
        {
            int Quantity = 0;
            if (Cart != null)
            {
               Cart.ForEach(p => Quantity += p.Quantity);
            }
            return new JsonResult { Data = Quantity, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult OrderBook(ShopCart item)
        {
            
            if (Cart != null)
            {
                var product = item.Product[0];
                var itemExists = false; ;
                Cart.ForEach(p =>
                {
                    p.Product.ForEach(d =>
                     {
                         if (d.CoverId == product.CoverId && d.EditionId == product.EditionId && d.MediumId == product.MediumId && d.PublisherId == product.PublisherId)
                         {
                             itemExists = true;
                             p.Quantity += item.Quantity;
                         }
                     });
                });
                if (!itemExists)
                {
                    Cart.Add(item);
                }
            }
            else
            {
                Cart = new List<ShopCart>();
                Cart.Add(item);
            }

            return new JsonResult { Data = Cart, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}