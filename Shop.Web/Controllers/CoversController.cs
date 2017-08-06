using Shop.Web.BLL.Service.Covers.Implementation;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class CoversController : Controller
    {
        private static ICover coverService = null;
        // GET: Covers
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCovers()
        {
            coverService = new Covers();
            var result = coverService.GetData();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}