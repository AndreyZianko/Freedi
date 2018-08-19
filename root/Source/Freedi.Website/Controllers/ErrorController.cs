using System.Web.Mvc;

namespace Freedi.Website.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }


        public ActionResult InternalServerError()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}