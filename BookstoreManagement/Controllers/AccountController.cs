using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreManagement.Models;
using OnlineBookstoreManagement.Services;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace OnlineBookstoreManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IApiService apiService, ILogger<AccountController> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var token = await _apiService.LoginAsync(model.Email, model.Password);
                    if (!string.IsNullOrEmpty(token))
                    {
                        _apiService.SetToken(token);

                        await SignInUser(token);

                        TempData["SuccessMessage"] = "Login successful!";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid email or password.");
                    }
                }
                catch (System.Exception ex)
                {
                    _logger.LogError(ex, "Error during login for email {Email}", model.Email);
                    ModelState.AddModelError("", "An error occurred during login. Please try again.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var (success, errorMessage) = await _apiService.RegisterAsync(model.FirstName, model.LastName, model.Email, model.Password);
                if (success)
                {
                    TempData["SuccessMessage"] = "Registration successful! Please log in.";
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            _apiService.ClearToken();

            await HttpContext.SignOutAsync("CookieAuth");

            TempData["SuccessMessage"] = "You have been logged out successfully.";
            return RedirectToAction("Index", "Home");
        }

        private async Task SignInUser(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var claims = new List<Claim>(jwtToken.Claims);

            if (!claims.Any(c => c.Type == ClaimTypes.Name))
            {
                var nameClaim = claims.FirstOrDefault(c => c.Type == "unique_name");
                if (nameClaim != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, nameClaim.Value));
                }
            }
            if (!claims.Any(c => c.Type == ClaimTypes.Role))
            {
                var roleClaim = claims.FirstOrDefault(c => c.Type == "role");
                if (roleClaim != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, roleClaim.Value));
                }
            }

            var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = jwtToken.ValidTo
            };

            await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}