using InternSharp.Models;
using InternSharp.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace InternSharp.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountsController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //[HttpGet]
        //public IActionResult SignIn()
        //{
        //    return View();
        //}
        [HttpGet]
        public async Task<IActionResult> SignIn()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            var model = new SignUpModel();

            var accountTypes = await _userRepository.GetAccountTypesAsync();

            ViewBag.AccountTypes = accountTypes.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.AccountType
            }).ToList();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("SignUp", model);
            }

            var existingUser = await _userRepository.GetUserByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View("SignUp", model); 
            }

            var user = new UserModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                AccountTypeId = model.AccountTypeId
            };

            await _userRepository.CreateUserAsync(user);
            return RedirectToAction("SignIn");
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userRepository.GetUserByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View(model);
            }

            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View(model);
            }

            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserName", $"{user.FirstName} {user.LastName}");

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            TempData.Clear();
            return RedirectToAction("SignIn", "Accounts");
        }


        // External login redirect
        [HttpGet]
        public IActionResult ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Accounts");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, provider);
        }

        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded)
            {
                return RedirectToAction("SignIn");
            }

            var claims = result.Principal.Identities.FirstOrDefault()?.Claims;
            var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (email == null)
                return RedirectToAction("SignIn");

            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user == null)
            {
                var names = name?.Split(' ');
                var newUser = new UserModel
                {
                    FirstName = names?.FirstOrDefault() ?? "First",
                    LastName = names?.Skip(1).FirstOrDefault() ?? "",
                    Email = email,
                    PasswordHash = "" ,// placeholder
                    AccountTypeId = 1 // default account type
                };

                await _userRepository.CreateUserAsync(newUser);
                user = newUser;
            }

            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserName", $"{user.FirstName} {user.LastName}");

            return RedirectToAction("Index", "Home");
        }
    }
}
