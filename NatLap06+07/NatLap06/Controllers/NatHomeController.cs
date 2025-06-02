using Microsoft.AspNetCore.Mvc;

namespace NatLap06.Controllers
{
    public class NatHomeController : Controller
    {
        public IActionResult NatIndex()
        {
            return View(); // Trang Home
        }

        public IActionResult NatInfo()
        {
            ViewBag.Id = "2310900113";
            ViewBag.Name = "Nguyễn Anh Tuấn";
            ViewBag.Class = "K23CNT1";
            return View(); // Trang Thông tin sinh viên
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
