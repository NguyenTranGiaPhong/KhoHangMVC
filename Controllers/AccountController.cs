using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using KhoHangMVC.Models;
using System.Linq;

namespace KhoHangMVC.Controllers
{
    public class AccountController : Controller
    {
        // Trang đăng nhập
        public IActionResult Login()
        {
            return View();
        }

        // Xử lý đăng nhập
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra thông tin đăng nhập
                if (model.Username == "admin" && model.Password == "admin123")
                {
                    // Lưu thông tin đăng nhập của Admin vào cookie
                    Response.Cookies.Append("Username", model.Username, new CookieOptions { Expires = DateTimeOffset.Now.AddHours(1) });
                    Response.Cookies.Append("Role", "Admin", new CookieOptions { Expires = DateTimeOffset.Now.AddHours(1) });

                    // Chuyển hướng đến trang admin
                    return RedirectToAction("Index", "Admin");
                }
                else if (model.Username == "user" && model.Password == "user123")
                {
                    // Lưu thông tin đăng nhập của User vào cookie
                    Response.Cookies.Append("Username", model.Username, new CookieOptions { Expires = DateTimeOffset.Now.AddHours(1) });
                    Response.Cookies.Append("Role", "User", new CookieOptions { Expires = DateTimeOffset.Now.AddHours(1) });

                    // Chuyển hướng đến trang người dùng
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            return View(model);
        }

        // Trang đăng ký
        public IActionResult Register()
        {
            return View();
        }

        // Xử lý đăng ký
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Mặc định là người dùng đăng ký với vai trò User
                // Thực tế bạn có thể thêm chức năng để xác định người dùng là admin hay user khi đăng ký
                Response.Cookies.Append("Username", model.Username, new CookieOptions { Expires = DateTimeOffset.Now.AddHours(1) });
                Response.Cookies.Append("Role", "User", new CookieOptions { Expires = DateTimeOffset.Now.AddHours(1) });

                // Chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // Đăng xuất
        public IActionResult Logout()
        {
            // Xóa cookies khi đăng xuất
            Response.Cookies.Delete("Username");
            Response.Cookies.Delete("Role");

            return RedirectToAction("Login");
        }
    }
}
