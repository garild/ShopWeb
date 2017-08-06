using Shop.Web.BLL.Service.Editions.Implementation;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class EditionsController : Controller
    {
        
        // GET: Editions
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetEdition()
        {
            Editions _service = new Editions();
            var result = _service.GetData();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}