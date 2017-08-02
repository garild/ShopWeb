using Shop.Web.BLL.Service.Publishers.Implementation;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class PublishersController : Controller
    {
        private PublisherService publisherService = null;
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPublishers()
        {
            publisherService = new PublisherService(new Publishers());
            var result = publisherService.repository.GetData();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}