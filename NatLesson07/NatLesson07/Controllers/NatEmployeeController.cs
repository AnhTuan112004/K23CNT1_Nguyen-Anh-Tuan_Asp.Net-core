using Microsoft.AspNetCore.Mvc;
using NatLesson07.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NatLesson07.Controllers
{
    public class NatEmployeeController : Controller
    {
        private static List<NatEmployee> natListEmployees = new List<NatEmployee>
        {
            new NatEmployee { NatId = 2310900113, NatName = "Anh Tuan", NatBirthDay = new DateTime(2004, 1, 1), NatEmail = "nguyenanhtuant647@gmail.com", NatPhone = "0397568858", NatSalary = 12000000, NatStatus = true },
            new NatEmployee { NatId = 2, NatName = "Trần Thị B", NatBirthDay = new DateTime(1992, 5, 15), NatEmail = "b@example.com", NatPhone = "0912233445", NatSalary = 15000000, NatStatus = true },
            new NatEmployee { NatId = 3, NatName = "Lê Văn C", NatBirthDay = new DateTime(1988, 9, 20), NatEmail = "c@example.com", NatPhone = "0922123456", NatSalary = 11000000, NatStatus = false },
            new NatEmployee { NatId = 4, NatName = "Phạm Thị D", NatBirthDay = new DateTime(1995, 3, 10), NatEmail = "d@example.com", NatPhone = "0933445566", NatSalary = 13000000, NatStatus = true },
            new NatEmployee { NatId = 5, NatName = "Đỗ Văn E", NatBirthDay = new DateTime(1991, 7, 25), NatEmail = "e@example.com", NatPhone = "0944567890", NatSalary = 10000000, NatStatus = false }
        };

        public IActionResult NatIndex()
        {
            return View(natListEmployees);
        }

        // GET: /NatEmployee/NatCreate
        public IActionResult NatCreate()
        {
            var natModel = new NatEmployee();
            return View(natModel);
        }

        // POST: /NatEmployee/NatCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NatCreate(NatEmployee natModel)
        {
            try
            {
                if (natModel.NatId == 0)
                {
                    natModel.NatId = natListEmployees.Max(e => e.NatId) + 1;
                }
                natListEmployees.Add(natModel);
                return RedirectToAction(nameof(NatIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: /NatEmployee/NatEdit/5
        public IActionResult NatEdit(int id)
        {
            var natModel = natListEmployees.FirstOrDefault(x => x.NatId == id);
            return View(natModel);
        }

        // POST: /NatEmployee/NatEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NatEdit(int id, NatEmployee natModel)
        {
            try
            {
                for (int i = 0; i < natListEmployees.Count; i++)
                {
                    if (natListEmployees[i].NatId == id)
                    {
                        natListEmployees[i] = natModel;
                        break;
                    }
                }
                return RedirectToAction(nameof(NatIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: /NatEmployee/NatDetails/5
        public ActionResult NatDetails(int id)
        {
            var natModel = natListEmployees.FirstOrDefault(x => x.NatId == id);
            return View(natModel);
        }

        // GET: /NatEmployee/NatDelete/5
        public ActionResult NatDelete(int id)
        {
            var natModel = natListEmployees.FirstOrDefault(x => x.NatId == id);
            return View(natModel);
        }

        // POST: /NatEmployee/NatDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NatDelete(int id, NatEmployee natModel)
        {
            try
            {
                for (int i = 0; i < natListEmployees.Count; i++)
                {
                    if (natListEmployees[i].NatId == id)
                    {
                        natListEmployees.RemoveAt(i);
                        break;
                    }
                }
                return RedirectToAction(nameof(NatIndex));
            }
            catch
            {
                return View();
            }
        }
    }
}
