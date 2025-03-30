using Microsoft.AspNetCore.Mvc;
using KhoHangMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KhoHangMVC.Controllers
{
    public class OrderController : Controller
    {
        // Danh sách tên khách hàng thực tế phổ biến
        private static List<string> customerNames = new List<string>
        {
            "Nguyễn Văn Anh", "Trần Thị Lan", "Lê Minh Tiến", "Phan Thanh Bình", "Đoàn Ngọc Mai",
            "Nguyễn Thị Thảo", "Bùi Hoàng Sơn", "Võ Minh Tuấn", "Lê Thiên Thanh", "Hoàng Đức Tài",
            "Lâm Hoàng Nam", "Trương Hồng Quân", "Vũ Thị Cẩm", "Đặng Thị Mai", "Phan Thanh Duy",
            "Nguyễn Lệ Hoa", "Dương Minh Quân", "Nguyễn Khánh Duy", "Lê Thị Kim", "Trần Minh Đức",
            "Vũ Anh Tuấn", "Lê Hoàng Long", "Nguyễn Hoài Nam", "Phạm Minh Hoàng", "Trần Minh Hoàng",
            "Nguyễn Thị Kim Chi", "Đỗ Quang Hieu", "Lê Thị Như", "Dương Bích Ngọc", "Lê Hữu Tài",
            "Nguyễn Thanh Tâm", "Võ Thị Mai", "Phan Ngọc Mai", "Trần Thị Thu", "Nguyễn Thị Cẩm Tú"
        };

        // Danh sách trạng thái đơn hàng
        private static List<string> orderStatuses = new List<string>
        {
            "Đã Xử Lý", "Chưa Xử Lý", "Đang Giao Hàng", "Hoàn Thành", "Đã Hủy"
        };

        private static Random _random = new Random();

        // Danh sách đơn hàng
        private static List<Order> orders = new List<Order>();

        // Hàm tạo đơn hàng ngẫu nhiên
        private static List<Order> GenerateRandomOrders(int count)
        {
            var orders = new List<Order>();

            for (int i = 0; i < count; i++)
            {
                var customerName = customerNames[_random.Next(customerNames.Count)];
                var totalAmount = _random.Next(10000, 500000); // Tổng tiền ngẫu nhiên từ 10,000 đến 500,000
                var status = orderStatuses[_random.Next(orderStatuses.Count)];
                var orderDate = DateTime.Now.AddDays(-_random.Next(1, 30)); // Ngày đơn hàng trong 30 ngày qua

                var order = new Order
                {
                    Id = i + 1, // Tạo ID tự động tăng dần
                    CustomerName = customerName,
                    OrderDate = orderDate,
                    TotalAmount = totalAmount,
                    Status = status
                };

                orders.Add(order);
            }

            return orders;
        }

        // Hiển thị danh sách đơn hàng ngẫu nhiên
        public IActionResult Index()
        {
            var orders = GenerateRandomOrders(50); // Tạo 50 đơn hàng ngẫu nhiên
            return View(orders);
        }

        // Thêm đơn hàng mới
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.Id = orders.Max(o => o.Id) + 1; // Tạo id mới
                orders.Add(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // Sửa thông tin đơn hàng
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                var existingOrder = orders.FirstOrDefault(o => o.Id == order.Id);
                if (existingOrder != null)
                {
                    existingOrder.CustomerName = order.CustomerName;
                    existingOrder.OrderDate = order.OrderDate;
                    existingOrder.TotalAmount = order.TotalAmount;
                    existingOrder.Status = order.Status;
                }
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // Xóa đơn hàng
        public IActionResult Delete(int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                orders.Remove(order);
            }
            return RedirectToAction("Index");
        }
    }
}

