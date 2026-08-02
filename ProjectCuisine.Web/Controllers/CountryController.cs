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

        public async Task<IActionResult> Details(int countryId)
        {
            var country = await _countryService.GetByIdAsync(countryId);
            if(country == null) return NotFound();

            var recipes = await _recipeService.GetByCountryIdAsync(countryId);

            ViewBag.CountryName = country.Name;

            return View(recipes);
        }
    }
}
