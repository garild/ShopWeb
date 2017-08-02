using Shop.Web.BLL.Service.Mediums.Implementation;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class MediumsController : Controller
    {
        private MediumService mediumService = null;
        // GET: Mediums
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMediums()
        {
            mediumService = new MediumService(new Mediums());
            var result = mediumService.repository.GetDataDupa();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}