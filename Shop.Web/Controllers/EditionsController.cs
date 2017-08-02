using Shop.Web.BLL.Service.Editions.Implementation;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class EditionsController : Controller
    {
        private EditionService editionService = null;
        // GET: Editions
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetEdition()
        {
            editionService = new EditionService(new Editions());
            var result = editionService.repository.GetData();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}