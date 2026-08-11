using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectCuisine.Application.Interfaces.Services;
using ProjectCuisine.Domain.Entities;

namespace ProjectCuisine.Web.Controllers
{
    public class FavoriteRecipeController : Controller
    {
        private readonly IFavoriteRecipeService _favoriteRecipeService;
        private readonly UserManager<User> _userManager;

        public FavoriteRecipeController(IFavoriteRecipeService favoriteRecipeService, UserManager<User> userManager)
        {
            _favoriteRecipeService = favoriteRecipeService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var favoriteRecipes = await _favoriteRecipeService.GetFavorites(userId!);
            return View(favoriteRecipes);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Toggle(int id, string? returnUrl = null)
        {
            var userId = _userManager.GetUserId(User);

            if (userId != null)
            {
                await _favoriteRecipeService.Toggle(userId, id);
            }

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index");
        }
    }
}
