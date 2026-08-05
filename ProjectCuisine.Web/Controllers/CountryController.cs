using Microsoft.AspNetCore.Mvc;
using ProjectCuisine.Application.Interfaces.Services;

namespace ProjectCuisine.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IRecipeService _recipeService;

        public CountryController(ICountryService countryService, IRecipeService recipeService)
        {
            _countryService = countryService;
            _recipeService = recipeService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var country = await _countryService.GetByIdAsync(id);
            if(country == null) return NotFound();

            var recipes = await _recipeService.GetByCountryIdAsync(id);

            ViewBag.CountryName = country.Name;
            ViewBag.RegionId = country.RegionId;

            return View(recipes);
        }
    }
}
