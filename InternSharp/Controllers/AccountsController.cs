using InternSharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternSharp.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(SignInModel model)
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
        //public ActionResult SignOut()
        //{
        //    Session.Clear();
        //    return RedirectToAction("Index", "Home");
        //}

    }
}
