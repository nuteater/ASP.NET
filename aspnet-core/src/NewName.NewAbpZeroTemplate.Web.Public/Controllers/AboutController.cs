using Microsoft.AspNetCore.Mvc;
using NewName.NewAbpZeroTemplate.Web.Controllers;

namespace NewName.NewAbpZeroTemplate.Web.Public.Controllers
{
    public class AboutController : NewAbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}