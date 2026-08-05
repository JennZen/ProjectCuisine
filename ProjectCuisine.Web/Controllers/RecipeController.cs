using Microsoft.AspNetCore.Mvc;
using ProjectCuisine.Application.DTOs.Recipe;
using ProjectCuisine.Application.Interfaces.Services;

namespace ProjectCuisine.Web.Controllers
{
    public class RecipeController : Controller
    {

        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
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
