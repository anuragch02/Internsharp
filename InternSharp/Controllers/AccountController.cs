using Microsoft.AspNetCore.Mvc;

namespace InternSharp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
