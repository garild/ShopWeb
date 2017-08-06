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
            else
            {
                Cart = new List<ShopCart>();
                Cart.Add(item);
            }

            return new JsonResult { Data = Cart, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}