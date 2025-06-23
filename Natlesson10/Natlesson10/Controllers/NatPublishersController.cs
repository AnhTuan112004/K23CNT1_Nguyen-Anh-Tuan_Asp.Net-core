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
    public class NatPublishersController : Controller
    {
        private readonly BookStoreContext _context;

        public NatPublishersController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: NatPublishers
        public async Task<IActionResult> Index(string? search, string sortOrder, int page = 1, int pageSize = 5)
        {
            var publishers = from p in _context.Publishers select p;

            // Tìm kiếm theo Tên, Địa chỉ hoặc Số điện thoại
            if (!string.IsNullOrEmpty(search))
            {
                publishers = publishers.Where(p =>
                    p.PublisherName.Contains(search) ||
                    p.Address.Contains(search) ||
                    p.Phone.Contains(search));
            }

            // Sắp xếp
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PhoneSort = sortOrder == "phone_asc" ? "phone_desc" : "phone_asc";

            publishers = sortOrder switch
            {
                "name_desc" => publishers.OrderByDescending(p => p.PublisherName),
                "phone_asc" => publishers.OrderBy(p => p.Phone),
                "phone_desc" => publishers.OrderByDescending(p => p.Phone),
                _ => publishers.OrderBy(p => p.PublisherName),
            };

            // Phân trang
            int totalItems = await publishers.CountAsync();
            var items = await publishers
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Truyền dữ liệu ra View
            ViewBag.Search = search;
            ViewBag.Total = totalItems;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            return View(items);
        }

        // GET: NatPublishers/Details/5
        public async Task<IActionResult> Details(int? natId)
        {
            if (natId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == natId);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: NatPublishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NatPublishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: NatPublishers/Edit/5
        public async Task<IActionResult> Edit(int? natId)
        {
            if (natId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers.FindAsync(natId);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: NatPublishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int natId, [Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (natId != publisher.PublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.PublisherId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: NatPublishers/Delete/5
        public async Task<IActionResult> Delete(int? natId)
        {
            if (natId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == natId);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: NatPublishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int natId)
        {
            var publisher = await _context.Publishers.FindAsync(natId);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublisherExists(int natId)
        {
            return _context.Publishers.Any(e => e.PublisherId == natId);
        }
    }
}
