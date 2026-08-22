using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectCuisine.Application.Interfaces.Services;
using ProjectCuisine.Domain.Entities;
using ProjectCuisine.Web.Models.Admin;

namespace ProjectCuisine.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IRecipeService _recipeService;

        private readonly ICountryService _countryService;

        private readonly IRegionService _regionService;

        private readonly UserManager<User> _userManager;

        public HomeController(IRecipeService recipeService, ICountryService countryService, 
                IRegionService regionService, UserManager<User> userManager)
        {
            _recipeService = recipeService;
            _countryService = countryService;
            _regionService = regionService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                TotalRecipes = await _recipeService.GetCountAsync(),
                TotalCountries = await _countryService.GetCountAsync(),
                TotalRegions = await _regionService.GetCountAsync(),
                TotalUsers = await _userManager.Users.CountAsync()
            };

            return View(model);
        }
    }
}
