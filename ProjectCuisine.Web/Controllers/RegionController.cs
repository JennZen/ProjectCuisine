using Microsoft.AspNetCore.Mvc;
using ProjectCuisine.Application.Interfaces.Services;

namespace ProjectCuisine.Web.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionService _regionService;
        private readonly ICountryService _countryService;

        public RegionController(IRegionService regionService, ICountryService countryService)
        {
            _regionService = regionService;
            _countryService = countryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _regionService.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var region = await _regionService.GetByIdAsync(id);

            if (region == null) return NotFound();

            var countries = await _countryService.GetAllByRegionAsync(id);

            return View((Region: region, Countries: countries));
        }
    }
}
