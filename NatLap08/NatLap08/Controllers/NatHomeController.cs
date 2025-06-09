using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NatLap08.Models;

namespace NatLap08.Controllers
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
            // Danh sách các bài làm (link, tên hiển thị)
            var projects = new[]
            {
        new { Controller = "NatProduct", Action = "NatIndex", Name = "Quản lý sản phẩm" },
        new { Controller = "NatAccount", Action = "NatIndex", Name = "Quản lý tài khoản" }  // Thêm link tài khoản
    };

            ViewBag.Projects = projects;
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
