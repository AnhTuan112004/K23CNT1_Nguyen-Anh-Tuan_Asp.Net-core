using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenAnhTuan_2310900113.Models;

namespace NguyenAnhTuan_2310900113.Controllers
{
    public class NatEmployeesController : Controller
    {
        private readonly NguyenAnhTuan2310900113Context _context;

        public NatEmployeesController(NguyenAnhTuan2310900113Context context)
        {
            _context = context;
        }

        // GET: Danh sách nhân viên
        public async Task<IActionResult> NatIndex(string? searchString, string? levelFilter, string? sortOrder, int page = 1, int pageSize = 5)
        {
            var query = _context.NatEmployees.AsQueryable();

            // Tìm kiếm
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(e => e.NatEmpName.Contains(searchString));
            }

            // Lọc theo trình độ
            if (!string.IsNullOrEmpty(levelFilter))
            {
                query = query.Where(e => e.NatEmpLevel == levelFilter);
            }

            // Sắp xếp
            ViewBag.CurrentSort = sortOrder;
            query = sortOrder switch
            {
                "name_desc" => query.OrderByDescending(e => e.NatEmpName),
                "Date" => query.OrderBy(e => e.NatEmpStartDate),
                "date_desc" => query.OrderByDescending(e => e.NatEmpStartDate),
                _ => query.OrderBy(e => e.NatEmpName),
            };

            // Thống kê
            ViewBag.TotalCount = await _context.NatEmployees.CountAsync();
            ViewBag.ShowCount = await _context.NatEmployees.CountAsync(e => e.NatEmpStatus == true);
            ViewBag.HideCount = await _context.NatEmployees.CountAsync(e => e.NatEmpStatus != true);

            // Tổng số trang
            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            page = Math.Clamp(page, 1, totalPages);

            // Phân trang
            var data = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Gửi lại thông tin lọc
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.SearchString = searchString;
            ViewBag.LevelFilter = levelFilter;

            return View(data);
        }

        // GET: Tạo mới nhân viên
        public IActionResult NatCreate()
        {
            return View(new NatEmployee()); // ✅ Truyền model rỗng để tránh lỗi null
        }


        // POST: Tạo mới nhân viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NatCreate([Bind("NatEmpId,NatEmpName,NatEmpLevel,NatEmpStartDate,NatEmpStatus")] NatEmployee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Thêm nhân viên thành công!";
                return RedirectToAction(nameof(NatIndex));
            }
            return View(emp);
        }

        // GET: Sửa nhân viên
        public async Task<IActionResult> NatEdit(int? natid)
        {
            if (natid == null) return NotFound();

            var emp = await _context.NatEmployees.FindAsync(natid);
            if (emp == null) return NotFound();

            return View(emp);
        }
        // GET: Chi tiết nhân viên
        public async Task<IActionResult> NatDetails(int? id)
        {
            if (id == null)
                return NotFound();

            var emp = await _context.NatEmployees
                .FirstOrDefaultAsync(e => e.NatEmpId == id);

            if (emp == null)
                return NotFound();

            return View(emp);
        }

        // POST: Sửa nhân viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NatEdit(int natid, [Bind("NatEmpId,NatEmpName,NatEmpLevel,NatEmpStartDate,NatEmpStatus")] NatEmployee emp)
        {
            if (natid != emp.NatEmpId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Cập nhật nhân viên thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NatEmployeeExists(emp.NatEmpId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(NatIndex));
            }
            return View(emp);
        }


        // GET: Xóa nhân viên
        public async Task<IActionResult> NatDelete(int? natid)
        {
            if (natid == null) return NotFound();

            var emp = await _context.NatEmployees
                .FirstOrDefaultAsync(m => m.NatEmpId == natid);

            if (emp == null) return NotFound();

            return View(emp);
        }

        // POST: Xác nhận xóa
        [HttpPost, ActionName("NatDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NatDeleteConfirmed(int natid)
        {
            var emp = await _context.NatEmployees.FindAsync(natid);
            if (emp != null)
            {
                _context.NatEmployees.Remove(emp);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Xóa nhân viên thành công!";
            }
            return RedirectToAction(nameof(NatIndex));
        }

        // Kiểm tra tồn tại
        private bool NatEmployeeExists(int natid)
        {
            return _context.NatEmployees.Any(e => e.NatEmpId == natid);
        }
    }
}
