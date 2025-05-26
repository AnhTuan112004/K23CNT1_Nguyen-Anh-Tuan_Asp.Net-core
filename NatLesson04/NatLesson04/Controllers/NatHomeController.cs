using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NatLesson04.Models;

namespace NatLesson04.Controllers
{
    public class NatHomeController : Controller
    {
        private readonly ILogger<NatHomeController> _logger;

        public NatHomeController(ILogger<NatHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NatIndex()
        {
            return View();
        }

        public IActionResult NatAbout()
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
