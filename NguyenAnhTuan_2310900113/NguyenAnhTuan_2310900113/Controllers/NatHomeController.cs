using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NguyenAnhTuan_2310900113.Models;

namespace NguyenAnhTuan_2310900113.Controllers
{
    public class NatHomeController : Controller
    {
        private readonly ILogger<NatHomeController> _logger;

        public NatHomeController(ILogger<NatHomeController> logger)
        {
            _logger = logger;
        }

        // Trang chủ (đúng theo route trong Program.cs)
        public IActionResult NatIndex()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        // Trang thông tin sinh viên
        public IActionResult NatAbout()
        {
            return View();
        }

        // Trang lỗi hệ thống
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
