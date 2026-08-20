using Microsoft.AspNetCore.Mvc;
using ProjectCuisine.Application.Interfaces.Services;

namespace ProjectCuisine.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
