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

        public IActionResult ApplicationSubmission()
        {
            return View();
        }

        public IActionResult ResumeUpload()
        {
            return View();
        }
    }
}
