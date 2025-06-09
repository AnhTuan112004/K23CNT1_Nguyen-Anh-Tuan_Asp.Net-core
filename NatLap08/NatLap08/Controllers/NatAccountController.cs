using Microsoft.AspNetCore.Mvc;
using NatLap08.Models;

public class NatAccountController : Controller
{
    private static List<NatAccount> accounts = new List<NatAccount>()
    {
        new NatAccount
        {
            NatId = 1,
            NatFullName = "Nguyễn Anh Tuấn",
            NatEmail = "nguyenanhtuant647@gmail.com",
            NatPhone = "0397568858",
            NatAddress = "Hà Nội",
            NatAvatar = "",
            NatBirthday = new System.DateTime(2004, 1, 1),
            NatGender = "Nam",
            NatPassword = "123456",
            NatFacebook = "https://www.facebook.com/anhtuan1124"
        }
    };

    // GET: NatAccount/NatIndex
    public ActionResult NatIndex()
    {
        var sortedAccounts = accounts.OrderBy(a => a.NatFullName).ToList();
        return View(sortedAccounts);
    }

    // GET: NatAccount/NatDetails/5
    public ActionResult NatDetails(int id)
    {
        var account = accounts.FirstOrDefault(a => a.NatId == id);
        if (account == null)
        {
            TempData["Error"] = "Không tìm thấy tài khoản.";
            return NotFound();
        }
        return View(account);
    }

    // GET: NatAccount/NatCreate
    public ActionResult NatCreate()
    {
        return View();
    }

    // POST: NatAccount/NatCreate
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult NatCreate(NatAccount account)
    {
        if (account == null)
        {
            TempData["Error"] = "Dữ liệu không hợp lệ.";
            return View();
        }

        if (string.IsNullOrEmpty(account.NatAvatar))
        {
            account.NatAvatar = "/images/default-avatar.png";
        }

        if (ModelState.IsValid)
        {
            account.NatId = accounts.Count > 0 ? accounts.Max(a => a.NatId) + 1 : 1;
            accounts.Add(account);
            TempData["Success"] = "Tạo tài khoản thành công.";
            return RedirectToAction(nameof(NatIndex));
        }
        return View(account);
    }

    // GET: NatAccount/NatEdit/5
    public ActionResult NatEdit(int id)
    {
        var account = accounts.FirstOrDefault(a => a.NatId == id);
        if (account == null)
        {
            TempData["Error"] = "Không tìm thấy tài khoản để sửa.";
            return NotFound();
        }
        return View(account);
    }

    // POST: NatAccount/NatEdit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult NatEdit(int id, NatAccount updatedAccount)
    {
        if (updatedAccount == null)
        {
            TempData["Error"] = "Dữ liệu gửi lên không hợp lệ.";
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            var account = accounts.FirstOrDefault(a => a.NatId == id);
            if (account == null)
            {
                TempData["Error"] = "Không tìm thấy tài khoản để cập nhật.";
                return NotFound();
            }

            account.NatFullName = updatedAccount.NatFullName;
            account.NatEmail = updatedAccount.NatEmail;
            account.NatPhone = updatedAccount.NatPhone;
            account.NatAddress = updatedAccount.NatAddress;
            account.NatAvatar = string.IsNullOrEmpty(updatedAccount.NatAvatar) ? "/images/default-avatar.png" : updatedAccount.NatAvatar;
            account.NatBirthday = updatedAccount.NatBirthday;
            account.NatGender = updatedAccount.NatGender;
            account.NatPassword = updatedAccount.NatPassword;
            account.NatFacebook = updatedAccount.NatFacebook;

            TempData["Success"] = "Cập nhật tài khoản thành công.";
            return RedirectToAction(nameof(NatIndex));
        }

        return View(updatedAccount);
    }

    // GET: NatAccount/NatDelete/5
    public ActionResult NatDelete(int id)
    {
        var account = accounts.FirstOrDefault(a => a.NatId == id);
        if (account == null)
        {
            TempData["Error"] = "Không tìm thấy tài khoản để xóa.";
            return NotFound();
        }
        return View(account);
    }

    // POST: NatAccount/NatDelete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult NatDelete(int id, IFormCollection collection)
    {
        var account = accounts.FirstOrDefault(a => a.NatId == id);
        if (account == null)
        {
            TempData["Error"] = "Không tìm thấy tài khoản để xóa.";
            return NotFound();
        }

        accounts.Remove(account);
        TempData["Success"] = "Xóa tài khoản thành công.";
        return RedirectToAction(nameof(NatIndex));
    }
}
