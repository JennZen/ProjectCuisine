using Microsoft.AspNetCore.Mvc;
using ProjectCuisine.Application.Interfaces.Services;

namespace ProjectCuisine.Web.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _regionService.GetAllAsync());
        }
    }
}
