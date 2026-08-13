using Microsoft.AspNetCore.Mvc;
using ProjectCuisine.Application.Interfaces.Services;
using ProjectCuisine.Application.Services;

namespace ProjectCuisine.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IRegionService _regionService;

        public CountryController(ICountryService countryService, IRegionService regionService)
        {
            _countryService = countryService;
            _regionService = regionService;
        }

        public async Task<IActionResult> Index(int id)  //id is the regionId
        {
            var region = await _regionService.GetByIdAsync(id);

            if (region == null) return NotFound();

            var countries = await _countryService.GetAllByRegionAsync(id);
            ViewBag.Region = region;
            return View(countries);
        }
    }
}
