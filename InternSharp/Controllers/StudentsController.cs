using InternSharp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InternSharp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IInternshipRepository _internshipRepository;

        public StudentsController(IInternshipRepository internshipRepository)
        {
            _internshipRepository = internshipRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Internship(int id)
        {
            var internship = await _internshipRepository.GetInternshipByIdAsync(id);
            if (internship == null)
            {
                return NotFound();
            }

            return View(internship); 
        }

        public IActionResult Jobs()
        {
            return View();
        }

        public async Task <IActionResult> ApplicationSubmission(int id)
        {
            var userIdString = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userIdString))
            {
                return RedirectToAction("SignIn", "Accounts");
            }
            if (!int.TryParse(userIdString, out int userId) || userId <= 0)
            {
                return RedirectToAction("SignIn", "Accounts");
            }
            var internship = await _internshipRepository.GetInternshipByIdAsync(id);
            if (internship == null)
            {
                return NotFound();
            }

            return View(internship);
        }

        public IActionResult ResumeUpload()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }

    }
}
