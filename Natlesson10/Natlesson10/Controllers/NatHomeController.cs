using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Natlesson10.Models;

namespace Natlesson10.Controllers
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
        public IActionResult NatPolicy()
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
