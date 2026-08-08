using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectCuisine.Application.DTOs.User;
using ProjectCuisine.Domain.Entities;

namespace ProjectCuisine.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }

            if (registerDto.Password != registerDto.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match.");
                return View(registerDto);
            }

            var user = new User
            {
                UserName = registerDto.Email,
                Email = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(registerDto);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Region");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }

            var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return View(loginDto);
            }

            return RedirectToAction("Index", "Region");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Region");
        }
    }
}
