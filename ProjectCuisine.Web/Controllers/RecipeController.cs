using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectCuisine.Application.DTOs.Recipe;
using ProjectCuisine.Application.Interfaces.Services;

namespace ProjectCuisine.Web.Controllers
{
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

        public async Task<IActionResult> Index(int id, int? categoryId) //id is the countryId
        {
            var country = await _countryService.GetByIdAsync(id);
            if (country == null) return NotFound();

            var recipes = categoryId.HasValue && categoryId.Value > 0
                ? await _recipeService.GetByCategoryAndCountryAsync(categoryId.Value, id)
                : await _recipeService.GetByCountryIdAsync(id);

            var categories = await _categoryService.GetAllAsync();

            ViewBag.Categories = new SelectList(categories, "Id", "Name", categoryId);
            ViewBag.CountryId = id;
            ViewBag.CountryName = country.Name;
            ViewBag.RegionId = country.RegionId;
            return View(recipes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var recipe = await _recipeService.GetByIdAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        /*[HttpPost(RecipeCreateDto)]
        public async Task<IActionResult> Create(RecipeCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _recipeService.CreateAsync(dto);
            return RedirectToAction("Index", "Home");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await _recipeService.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            await _recipeService.DeleteAsync(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var recipe = await _recipeService.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recipes = await _recipeService.GetAllAsync();
            return View(recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var recipe = await _recipeService.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }*/
    }
}
