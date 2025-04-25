using InternSharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternSharp.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "admin123")
            {
                ViewBag.Message = "Login Successful!";
            }
            else
            {
                ViewBag.Message = "Invalid Credentials";
            }
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
