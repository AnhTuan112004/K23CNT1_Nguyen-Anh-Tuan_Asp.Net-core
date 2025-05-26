using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NatLap06.Models;

namespace NatLap06.Controllers
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
            ViewBag.StudentId = "2310900113";
            ViewBag.StudentName = "Nguyễn Anh Tuấn";
            ViewBag.Class = "K23CNT1";
            return View();
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
