using Esercizio_L1_W2_BU2.Models;
using Esercizio_L1_W2_BU2.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Esercizio_L1_W2_BU2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            RoleManager<ApplicationRole> roleManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        private bool verivyAuth()
        {
            return User.Identity.IsAuthenticated;
        } 
        public IActionResult Register()
        {
            if(verivyAuth())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate
                };
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (!result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                var user = await _userManager.FindByEmailAsync(newUser.Email);


                await _userManager.AddToRoleAsync(user, "Studente");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            if (verivyAuth())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return View("Error");
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (!signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            var roles = await _signInManager.UserManager.GetRolesAsync(user);

            var claims = new List<Claim>();

            var nameClaim = new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}");

            var emailClaim = new Claim(ClaimTypes.Email, user.Email);

            foreach(var role in roles)
            {
                var roleClaim = new Claim(ClaimTypes.Role, role);
                claims.Add(roleClaim);
            }

            claims.Add(nameClaim);
            claims.Add(emailClaim);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
