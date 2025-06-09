using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NatLap08.Models;
using System.Collections.Generic;
using System.Linq;

namespace NatLap08.Controllers
{
    public class NatProductController : Controller
    {
        private static List<NatCategory> NatCategories = new List<NatCategory>
        {
            new NatCategory { NatId = 1, NatName = "Điện tử" },
            new NatCategory { NatId = 2, NatName = "Thời trang" },
            new NatCategory { NatId = 3, NatName = "Gia dụng" }
        };

        private static List<NatProduct> NatProducts = new List<NatProduct>
        {
            new NatProduct { NatId = 1, NatName = "Điện thoại ABC", NatImage = "phone1.jpg", NatPrice = 5000000, NatSalePrice = 4500000, NatDescription = "Smartphone mới", NatCategoryId = 1 },
            new NatProduct { NatId = 2, NatName = "Áo sơ mi nam", NatImage = "shirt1.jpg", NatPrice = 300000, NatSalePrice = 250000, NatDescription = "Áo sơ mi đẹp", NatCategoryId = 2 }
        };

        private readonly string[] _badWords = new[] { "die", "damn", "f*ck" };

        public IActionResult NatIndex()
        {
            ViewData["NatCategories"] = NatCategories;
            return View(NatProducts);
        }

        public IActionResult NatCreate()
        {
            ViewData["NatCategories"] = NatCategories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NatCreate(NatProduct product)
        {
            if (product.NatSalePrice < 0)
            {
                ModelState.AddModelError(nameof(product.NatSalePrice), "Giá khuyến mãi không được âm.");
            }
            else if (product.NatSalePrice >= product.NatPrice * 0.9)
            {
                ModelState.AddModelError(nameof(product.NatSalePrice), "Giá khuyến mãi phải nhỏ hơn 10% so với giá chuẩn.");
            }

            if (!string.IsNullOrEmpty(product.NatDescription))
            {
                var descLower = product.NatDescription.ToLower();
                foreach (var badWord in _badWords)
                {
                    if (descLower.Contains(badWord))
                    {
                        ModelState.AddModelError(nameof(product.NatDescription), "Mô tả không được chứa từ nhạy cảm.");
                        break;
                    }
                }
            }

            if (ModelState.IsValid)
            {
                product.NatId = NatProducts.Any() ? NatProducts.Max(p => p.NatId) + 1 : 1;
                NatProducts.Add(product);
                return RedirectToAction(nameof(NatIndex));
            }

            ViewData["NatCategories"] = NatCategories;
            return View(product);
        }

        public IActionResult NatEdit(int id)
        {
            var product = NatProducts.FirstOrDefault(p => p.NatId == id);
            if (product == null)
                return NotFound();

            ViewData["NatCategories"] = NatCategories;
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NatEdit(int id, NatProduct product)
        {
            if (id != product.NatId)
                return BadRequest();

            if (product.NatSalePrice < 0)
            {
                ModelState.AddModelError(nameof(product.NatSalePrice), "Giá khuyến mãi không được âm.");
            }
            else if (product.NatSalePrice >= product.NatPrice * 0.9)
            {
                ModelState.AddModelError(nameof(product.NatSalePrice), "Giá khuyến mãi phải nhỏ hơn 10% so với giá chuẩn.");
            }

            if (!string.IsNullOrEmpty(product.NatDescription))
            {
                var descLower = product.NatDescription.ToLower();
                foreach (var badWord in _badWords)
                {
                    if (descLower.Contains(badWord))
                    {
                        ModelState.AddModelError(nameof(product.NatDescription), "Mô tả không được chứa từ nhạy cảm.");
                        break;
                    }
                }
            }

            if (ModelState.IsValid)
            {
                var existing = NatProducts.FirstOrDefault(p => p.NatId == id);
                if (existing == null)
                    return NotFound();

                existing.NatName = product.NatName;
                existing.NatImage = product.NatImage;
                existing.NatPrice = product.NatPrice;
                existing.NatSalePrice = product.NatSalePrice;
                existing.NatDescription = product.NatDescription;
                existing.NatCategoryId = product.NatCategoryId;

                return RedirectToAction(nameof(NatIndex));
            }

            ViewData["NatCategories"] = NatCategories;
            return View(product);
        }

        public IActionResult NatDetails(int id)
        {
            var product = NatProducts.FirstOrDefault(p => p.NatId == id);
            if (product == null)
                return NotFound();

            ViewData["NatCategories"] = NatCategories;
            return View(product);
        }

        public IActionResult NatDelete(int id)
        {
            var product = NatProducts.FirstOrDefault(p => p.NatId == id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("NatDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult NatDeleteConfirmed(int id)
        {
            var product = NatProducts.FirstOrDefault(p => p.NatId == id);
            if (product == null)
                return NotFound();

            NatProducts.Remove(product);
            return RedirectToAction(nameof(NatIndex));
        }
    }
}
