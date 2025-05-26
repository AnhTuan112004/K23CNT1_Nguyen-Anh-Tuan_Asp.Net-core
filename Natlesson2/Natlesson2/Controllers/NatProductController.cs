using Microsoft.AspNetCore.Mvc;
using Natlesson2.Models;

namespace Natlesson2.Controllers
{
    public class NatProductController : Controller
    {
        public IActionResult NatIndex()
        {
            ViewData["messageData"] = "Du lieu tu viewData";
            ViewBag.messageData = "Du lieu tu viewBag";
            TempData["messageData"] = "Du lieu trong TempData";
            return View();
        }
        public IActionResult GetNatProduct()
        {
            NatProduct p = new NatProduct
            {
                NatProductId = 1,
                NatProductName = "Trek280 - 2016",
                NatYearRelease = 2016,
                NatPrice = 379.99
            };
            ViewBag.NatProduct = p;
            ViewData["NatProductVD"] = p;
            return View();
        }
        public IActionResult GetAllNatProducts()
        {
            List<NatProduct> Natproducts = new List<NatProduct>()
            {
                new NatProduct() { NatProductId = 1, NatProductName = "Trek 820 - 2016", NatYearRelease = 2016, NatPrice = 379.99 },
                new NatProduct() { NatProductId = 2, NatProductName = "Ritchay Timberwolf Frameset - 2016", NatYearRelease = 2016, NatPrice = 749.99 },
                new NatProduct() { NatProductId = 3, NatProductName = "Ritchay Wednesday Frameset - 2016", NatYearRelease = 2016, NatPrice = 999.99 },
                new NatProduct() { NatProductId = 4, NatProductName = "Trek Fuel EX 8 29 - 2016", NatYearRelease = 2016, NatPrice = 2899.99 },
                new NatProduct() { NatProductId = 5, NatProductName = "Heller Shagamaw - 2016", NatYearRelease = 2016, NatPrice = 1329.99 },
                new NatProduct() { NatProductId = 6, NatProductName = "Surly Ice Cream Truck Frameset - 2016", NatYearRelease = 2016, NatPrice = 469.99 },
                new NatProduct() { NatProductId = 7, NatProductName = "Trek Slash 8 27.5 - 2016", NatYearRelease = 2016, NatPrice = 3999.99 },
                new NatProduct() { NatProductId = 8, NatProductName = "Trek Remedy 29 Carbon Frameset - 2016", NatYearRelease = 2016, NatPrice = 1799.99 },
                new NatProduct() { NatProductId = 9, NatProductName = "Trek Conley 8 29 - 2016", NatYearRelease = 2016, NatPrice = 2999.99 },
                new NatProduct() { NatProductId = 10, NatProductName = "Surly Straggler 650b - 2016", NatYearRelease = 2016, NatPrice = 1680.99 },
                new NatProduct() { NatProductId = 11, NatProductName = "Surly Straggler 700c - 2016", NatYearRelease = 2016, NatPrice = 549.99 },
                new NatProduct() { NatProductId = 12, NatProductName = "Trek 820 Women's (24-Inch) - 2016", NatYearRelease = 2016, NatPrice = 269.99 },
                new NatProduct() { NatProductId = 13, NatProductName = "Electra Cruiser 1 (24-Inch) - 2016", NatYearRelease = 2016, NatPrice = 269.99 },
                new NatProduct() { NatProductId = 14, NatProductName = "Electra Girl's Hawaii 1 (16-inch) - 2015/2016", NatYearRelease = 2016, NatPrice = 269.99 }
            };

            ViewBag.Natproducts = Natproducts;
            // Trả về view tên là Products trong thư mục /Views/Product/
            return View("NatProducts");
        }
    }
}
