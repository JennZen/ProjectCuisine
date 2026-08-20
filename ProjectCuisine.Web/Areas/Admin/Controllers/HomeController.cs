using Microsoft.AspNetCore.Mvc;
using ProjectCuisine.Application.Interfaces.Services;
using ProjectCuisine.Web.Models.Admin;

namespace ProjectCuisine.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IRecipeService _recipeService;

        private readonly ICountryService _countryService;

        private readonly IRegionService _regionService;

        //for the user: private readonly IUserService _userService;

        public HomeController(IRecipeService recipeService, ICountryService countryService, IRegionService regionService)
        {
            _recipeService = recipeService;
            _countryService = countryService;
            _regionService = regionService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                TotalRecipes = await _recipeService.GetCountAsync(),
                TotalCountries = await _countryService.GetCountAsync(),
                TotalRegions = await _regionService.GetCountAsync(),
                //TotalUsers = await _userService.GetCountAsync() 
            };

            return View(model);
        }
    }
}
