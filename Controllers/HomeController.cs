using Microsoft.AspNetCore.Mvc;
using KhoHangMVC.Models;
using System;
using System.Linq;

namespace KhoHangMVC.Controllers
{
    public class HomeController : Controller
    {
        // Khởi tạo Random để sử dụng cho việc random giá sản phẩm
        private static Random _random = new Random();

        // Danh sách sản phẩm trong kho (giả lập, không dùng cơ sở dữ liệu)
        private static List<Stock> stocks = new List<Stock>
        {
            new Stock { Id = 1, ProductName = "Laptop Dell", Quantity = 100, Price = GenerateRandomPrice(1500000, 3000000) },
            new Stock { Id = 2, ProductName = "Điện thoại Samsung", Quantity = 150, Price = GenerateRandomPrice(500000, 1500000) },
            new Stock { Id = 3, ProductName = "Tai nghe Sony", Quantity = 200, Price = GenerateRandomPrice(300000, 1000000) },
            new Stock { Id = 4, ProductName = "Máy tính bảng iPad", Quantity = 50, Price = GenerateRandomPrice(800000, 2000000) },
            new Stock { Id = 5, ProductName = "Smartwatch Samsung", Quantity = 120, Price = GenerateRandomPrice(1000000, 2500000) },
            new Stock { Id = 6, ProductName = "Ổ cứng SSD Kingston", Quantity = 80, Price = GenerateRandomPrice(400000, 1000000) },
            new Stock { Id = 7, ProductName = "Chuột máy tính Logitech", Quantity = 200, Price = GenerateRandomPrice(150000, 500000) },
            new Stock { Id = 8, ProductName = "Bàn phím cơ Corsair", Quantity = 90, Price = GenerateRandomPrice(800000, 1500000) },
            new Stock { Id = 9, ProductName = "Loa Bluetooth JBL", Quantity = 60, Price = GenerateRandomPrice(500000, 1500000) },
            new Stock { Id = 10, ProductName = "Máy ảnh Canon", Quantity = 40, Price = GenerateRandomPrice(3000000, 7000000) },
            // Sản phẩm thêm vào
            new Stock { Id = 11, ProductName = "Máy tính xách tay HP", Quantity = 70, Price = GenerateRandomPrice(1500000, 2500000) },
            new Stock { Id = 12, ProductName = "Điện thoại iPhone 13", Quantity = 80, Price = GenerateRandomPrice(20000000, 30000000) },
            new Stock { Id = 13, ProductName = "Tai nghe AirPods Pro", Quantity = 150, Price = GenerateRandomPrice(5000000, 7000000) },
            new Stock { Id = 14, ProductName = "Smartwatch Apple", Quantity = 60, Price = GenerateRandomPrice(10000000, 15000000) },
            new Stock { Id = 15, ProductName = "Máy chiếu BenQ", Quantity = 30, Price = GenerateRandomPrice(7000000, 10000000) }
        };

        // Hàm sinh giá ngẫu nhiên trong một khoảng nhất định
        private static int GenerateRandomPrice(int minPrice, int maxPrice)
        {
            return _random.Next(minPrice, maxPrice);
        }

        // Trang chính: Giới thiệu về ứng dụng
        public IActionResult Index()
        {
            // Kiểm tra cookie Username và Role
            var username = Request.Cookies["Username"];
            var role = Request.Cookies["Role"];

            // Nếu không có cookie Username hoặc Role, chuyển hướng đến trang login
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(role))
            {
                return RedirectToAction("Login", "Account");
            }

            // Kiểm tra vai trò của người dùng (Admin hoặc User)
            if (role == "Admin")
            {
                // Trường hợp admin
                ViewData["Message"] = "Chào mừng Admin!";
            }
            else if (role == "User")
            {
                // Trường hợp người dùng
                ViewData["Message"] = "Chào mừng người dùng!";
            }
            else
            {
                // Nếu vai trò không phải "Admin" hoặc "User", có thể cần xử lý thêm.
                ViewData["Message"] = "Chào mừng khách!";
            }

            // Trả về View
            return View();
        }

        // Trang liên hệ
        public IActionResult Contact()
        {
            return View();
        }

        // Trang tìm kiếm sản phẩm
        public IActionResult Search(string query)
        {
            // Nếu không có từ khóa tìm kiếm, trả về tất cả sản phẩm
            if (string.IsNullOrEmpty(query))
            {
                return View(stocks);
            }

            // Tìm kiếm các sản phẩm chứa từ khóa trong tên sản phẩm (không phân biệt chữ hoa, chữ thường)
            var result = stocks.Where(s => s.ProductName.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();

            // Trả về kết quả tìm kiếm tới View
            return View(result);
        }
    }
}
