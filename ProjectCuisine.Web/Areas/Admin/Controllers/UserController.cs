using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectCuisine.Domain.Entities;
using ProjectCuisine.Web.Models.Admin;

namespace ProjectCuisine.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();

            var userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = _userManager.GetRolesAsync(user).Result;

                userViewModels.Add(new UserViewModel
                {
                    Id = user.Id,
                    Email = user.UserName,
                    Role = roles.FirstOrDefault() ?? "User"
                });
            }

            var userRoles = _roleManager.Roles.
                                         Select(r => r.Name).
                                         Where(r => !string.IsNullOrEmpty(r)).
                                         ToList();

            ViewBag.UserRoles = userRoles;

            return View(userViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
