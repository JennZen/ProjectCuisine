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

        public IActionResult Index()
        {
            return View(_regionService.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            var region = _regionService.GetById(id);

            if (region == null) return NotFound();

            var countries = await _countryService.GetAllByRegionAsync(id);

            return View((Region: region, Countries: countries));
        }
    }
}
