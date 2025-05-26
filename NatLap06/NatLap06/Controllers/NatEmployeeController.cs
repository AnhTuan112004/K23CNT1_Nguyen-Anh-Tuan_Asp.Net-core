using Microsoft.AspNetCore.Mvc;
using NatLap06.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NatLap06.Controllers
{
    public class NatEmployeeController : Controller
    {
        public static List<NatEmployee> natListEmployee = new List<NatEmployee>
        {
            new NatEmployee { NatId = 1, NatName = "Nguyễn Văn An", NatBirthDay = new DateTime(2002, 5, 5), NatEmail = "sinhvien@abc.com", NatPhone = "0912345678", NatSalary = 1000, NatStatus = true },
            new NatEmployee { NatId = 2, NatName = "Lê Thị Dung", NatBirthDay = new DateTime(1995, 6, 10), NatEmail = "b@gmail.com", NatPhone = "0987654321", NatSalary = 1200, NatStatus = true },
            new NatEmployee { NatId = 3, NatName = "Trần Văn Hùng", NatBirthDay = new DateTime(1990, 1, 20), NatEmail = "c@gmail.com", NatPhone = "0934567890", NatSalary = 1500, NatStatus = false },
            new NatEmployee { NatId = 4, NatName = "Phạm Thị Dung", NatBirthDay = new DateTime(1988, 8, 8), NatEmail = "d@gmail.com", NatPhone = "0977777777", NatSalary = 1800, NatStatus = true },
            new NatEmployee { NatId = 5, NatName = "Nguyễn Anh Tuấn (Học sinh)", NatBirthDay = new DateTime(2004, 1, 1), NatEmail = "nguyenanhtuant647@gmail.com", NatPhone = "0397568858", NatSalary = 1100, NatStatus = true },
        };

        public IActionResult NatIndex()
        {
            return View(natListEmployee);
        }

        public IActionResult NatCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NatCreateSubmit(NatEmployee emp)
        {
            emp.NatId = natListEmployee.Max(e => e.NatId) + 1;
            natListEmployee.Add(emp);
            return RedirectToAction("NatIndex");
        }

        public IActionResult NatEdit(int id)
        {
            var emp = natListEmployee.FirstOrDefault(e => e.NatId == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        [HttpPost]
        public IActionResult NatEditSubmit(NatEmployee emp)
        {
            var existing = natListEmployee.FirstOrDefault(e => e.NatId == emp.NatId);
            if (existing != null)
            {
                existing.NatName = emp.NatName;
                existing.NatBirthDay = emp.NatBirthDay;
                existing.NatEmail = emp.NatEmail;
                existing.NatPhone = emp.NatPhone;
                existing.NatSalary = emp.NatSalary;
                existing.NatStatus = emp.NatStatus;
            }
            return RedirectToAction("NatIndex");
        }

        public IActionResult NatDelete(int id)
        {
            var emp = natListEmployee.FirstOrDefault(e => e.NatId == id);
            if (emp != null)
            {
                natListEmployee.Remove(emp);
            }
            return RedirectToAction("NatIndex");
        }
    }
}
