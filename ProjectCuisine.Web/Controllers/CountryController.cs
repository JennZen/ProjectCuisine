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

        public IActionResult Details(int countryId)
        {
            var country = _countryService.GetById(countryId);
            if(country == null) return NotFound();

            var recipes = _recipeService.GetByCountryId(countryId);

            ViewBag.CountryName = country.Name;

            return View(recipes);
        }
    }
}
