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
            if (ModelState.IsValid)
            {
                if (model.Username == validUsername && model.Password == validPassword)
                {
                    Session["Username"] = model.Username;
                    return RedirectToAction("Dashboard", "Home");
                }
                ModelState.AddModelError("", "Invalid login");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
