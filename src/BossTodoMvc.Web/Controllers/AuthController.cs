using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BossTodoMvc.Web.ViewModels;
using BossTodoMvc.Application.Services;

namespace BossTodoMvc.Web.Controllers;

    public class AuthController : Controller
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

   [HttpPost]
        // Phua remark on 26/2/2026
        // This codeline ==>var isValid = _authService.ValidateCredentials(model.Username, model.Password);
        //                  Must Match with AuthService.cs similar assignment var isValid = ... 
        //    
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var isValid = _authService.ValidateCredentials(model.Username, model.Password);

            if (!isValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Todos");
        }
        
            [HttpGet]
            public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Login");
    }

}

