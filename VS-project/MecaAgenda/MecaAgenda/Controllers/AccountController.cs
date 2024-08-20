using MecaAgenda.Models;
using MecaAgenda.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MecaAgenda.Application.DTOs;

namespace MecaAgenda.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IServiceLogin _serviceLogin;

        public AccountController(IServiceLogin serviceLogin)
        {
            _serviceLogin = serviceLogin;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                TempData["Message"] = "User is already logged in.";
                return RedirectToAction("Index", "Home");
            } else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                TempData["Message"] = "User couldn't be logged in.";
                return View();
            }

            var user = await _serviceLogin.LoginUser(model.Email, model.Password);

            if (user != null)
            {
                var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, user.Name),
                        new(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new(ClaimTypes.Role, user.Role),
                        new(ClaimTypes.Email, user.Email)
                    };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                TempData["Message"] = "Welcome " + user.Name + ".";

                return RedirectToAction("Index", "Home");
            }

            await Task.Delay(TimeSpan.FromSeconds(15));

            TempData["Message"] = "User could not be found.";

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                TempData["Message"] = "User couldn't be registered.";
                return View();
            }

            var user = await _serviceLogin.RegisterUser(userDTO);

            TempData["Message"] = "User has been created, please login.";

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            TempData["Message"] = "Logged out successfully.";

            return RedirectToAction("Login", "Account");
        }
    }
}
