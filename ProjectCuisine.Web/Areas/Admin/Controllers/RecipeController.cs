using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCuisine.Application.DTOs.Recipe;
using ProjectCuisine.Application.Interfaces.Services;

namespace ProjectCuisine.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;

        private readonly ICountryService _countryService;

        private readonly ICategoryService _categoryService;

        public RecipeController(IRecipeService recipeService, ICountryService countryService, ICategoryService categoryService)
        {
            _recipeService = recipeService;
            _countryService = countryService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var recipes = await _recipeService.GetAllDetailedAsync();

            return View(recipes);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await _recipeService.GetByIdAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            await _recipeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeCreateDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _recipeService.CreateAsync(model);
            if (!result)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var recipe = await _recipeService.GetForUpdateByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecipeUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _recipeService.UpdateAsync(model);
            if (!result)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
