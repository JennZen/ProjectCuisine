using Microsoft.AspNetCore.Mvc;

namespace ProjectCuisine.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
