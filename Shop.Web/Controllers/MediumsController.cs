using Shop.Web.BLL.Service.Mediums.Implementation;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class MediumsController : Controller
    {
        private IMedium mediumService = null;
        // GET: Mediums
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMediums()
        {
            mediumService = new Mediums();
            var result = mediumService.GetData();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}