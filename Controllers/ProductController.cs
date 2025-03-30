using Microsoft.AspNetCore.Mvc;
using KhoHangMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KhoHangMVC.Controllers
{
    public class ProductController : Controller
    {
        // Danh sách tên sản phẩm mẫu
        private static List<string> productNames = new List<string>
        {
            "Laptop", "Điện thoại", "Máy tính bảng", "Tivi", "Tai nghe", "Máy ảnh", "Loa Bluetooth", "Đồng hồ thông minh", "Máy in", "Bàn phím"
        };

        // Hàm tạo sản phẩm ngẫu nhiên
        private static Random _random = new Random();

        // Hàm tạo danh sách sản phẩm ngẫu nhiên
        private static List<Product> GenerateRandomProducts(int count)
        {
            var products = new List<Product>();

            for (int i = 0; i < count; i++)
            {
                var productName = productNames[_random.Next(productNames.Count)];
                var price = _random.Next(5000, 50000); // Giá ngẫu nhiên từ 5000 đến 50000
                var quantity = _random.Next(1, 100); // Số lượng ngẫu nhiên từ 1 đến 100

                var product = new Product
                {
                    Id = i + 1, // Tạo ID sản phẩm tự động tăng dần
                    Name = productName,
                    Description = $"Mô tả {productName}",
                    Price = price,
                    Quantity = quantity
                };

                products.Add(product);
            }

            return products;
        }

        // Hiển thị danh sách sản phẩm ngẫu nhiên
        public IActionResult Index()
        {
            var products = GenerateRandomProducts(10); // Tạo 10 sản phẩm ngẫu nhiên
            return View(products);
        }

        // Thêm sản phẩm mới
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // Giả lập thêm sản phẩm vào danh sách
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Sửa thông tin sản phẩm
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Giả lập việc sửa sản phẩm
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                // Giả lập sửa sản phẩm
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Xóa sản phẩm
        public IActionResult Delete(int id)
        {
            // Giả lập việc xóa sản phẩm
            return RedirectToAction("Index");
        }
    }
}
