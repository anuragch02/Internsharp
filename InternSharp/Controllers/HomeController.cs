using System.Diagnostics;
using InternSharp.Models;
using InternSharp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InternSharp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInternshipRepository _internshipRepo;

        public HomeController(ILogger<HomeController> logger, IInternshipRepository internshipRepo)
        {
            _logger = logger;
            _internshipRepo = internshipRepo;
        }

        public async Task<IActionResult> Index()
        {
            var internships = await _internshipRepo.GetAllInternshipsAsync();
            return View(internships);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
