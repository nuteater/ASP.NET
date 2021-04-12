using Microsoft.AspNetCore.Mvc;
using NewName.NewAbpZeroTemplate.Web.Controllers;

namespace NewName.NewAbpZeroTemplate.Web.Public.Controllers
{
    public class HomeController : NewAbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}