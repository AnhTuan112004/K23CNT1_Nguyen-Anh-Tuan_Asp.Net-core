using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Natlesson10.Models;

namespace Natlesson10.Controllers
{
    public class NatCategoriesController : Controller
    {
        private readonly BookStoreContext _context;

        public NatCategoriesController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: NatCategories/NatIndex1
        public async Task<IActionResult> NatIndex1(string searchString, string sortOrder, int page = 1)
        {
            int pageSize = 5;

            // Lưu thông tin filter và sort để hiển thị lại trên view
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSort"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CountSort"] = sortOrder == "count" ? "count_desc" : "count";

            var categories = _context.Categories
                                     .Include(c => c.Books)
                                     .AsQueryable();

            // Tìm kiếm
            if (!string.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(c => c.CategoryName.Contains(searchString));
            }

            // Sắp xếp
            categories = sortOrder switch
            {
                "name_desc" => categories.OrderByDescending(c => c.CategoryName),
                "count" => categories.OrderBy(c => c.Books.Count),
                "count_desc" => categories.OrderByDescending(c => c.Books.Count),
                _ => categories.OrderBy(c => c.CategoryName),
            };

            // Tính tổng số trang
            int totalItems = await categories.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            // Lấy danh sách theo trang
            var pagedCategories = await categories
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;

            return View(pagedCategories);
        }

        // GET: NatCategories/Details/5
        public async Task<IActionResult> Details(int? natId)
        {
            if (natId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == natId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: NatCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NatCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NatIndex1));
            }
            return View(category);
        }

        // GET: NatCategories/Edit/5
        public async Task<IActionResult> Edit(int? natId)
        {
            if (natId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(natId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: NatCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int natId, [Bind("CategoryId,CategoryName")] Category category)
        {
            if (natId != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(NatIndex1));
            }
            return View(category);
        }

        // GET: NatCategories/Delete/5
        public async Task<IActionResult> Delete(int? natId)
        {
            if (natId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == natId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: NatCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int natId)
        {
            var category = await _context.Categories.FindAsync(natId);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NatIndex1));
        }

        private bool CategoryExists(int natId)
        {
            return _context.Categories.Any(e => e.CategoryId == natId);
        }
    }
}
