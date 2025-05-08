using Microsoft.AspNetCore.Mvc;

namespace InternSharp.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Internship()
        {
            return View();
        }
        public IActionResult Jobs()
        {
            return View();
        }
        public IActionResult ApplicationSubmission()
        {
            return View();
        }


    }
}
