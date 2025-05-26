using Microsoft.AspNetCore.Mvc;
using NatLap06.Models;

namespace NatLap06.Controllers
{
    public class NatEmployeeController : Controller
    { // Dữ liệu giả lập trong bộ nhớ
        public static List<NatEmployee> natListEmployee = new List<NatEmployee>
        {
            new NatEmployee { NatId = 1, NatName = "Nguyễn Văn An", NatBirthDay = new DateTime(1995,1,1), NatEmail = "a@example.com", NatPhone = "0901234567", NatSalary = 1000, NatStatus = true },
            new NatEmployee { NatId = 2, NatName = "Trần Thị Ngân", NatBirthDay = new DateTime(1993,2,2), NatEmail = "b@example.com", NatPhone = "0902345678", NatSalary = 1200, NatStatus = true },
            new NatEmployee { NatId = 3, NatName = "Lê Văn Trung", NatBirthDay = new DateTime(1990,3,3), NatEmail = "c@example.com", NatPhone = "0903456789", NatSalary = 1100, NatStatus = false },
            new NatEmployee { NatId = 4, NatName = "Phạm Thị Dung", NatBirthDay = new DateTime(1988,4,4), NatEmail = "d@example.com", NatPhone = "0904567890", NatSalary = 1300, NatStatus = true },
            new NatEmployee { NatId = 5, NatName = "Nguyễn Anh Tuấn (Sinh viên)", NatBirthDay = new DateTime(2004,01,01), NatEmail = "nguyenanhtuant647@gmail.com", NatPhone = "0397568858", NatSalary = 900, NatStatus = true }
        };

        public IActionResult NatIndex()
        {
            return View(natListEmployee);
        }

        [HttpGet]
        public IActionResult NatCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NatCreateSubmit(NatEmployee emp)
        {
            natListEmployee.Add(emp);
            return RedirectToAction("NatIndex");
        }
    }
}

