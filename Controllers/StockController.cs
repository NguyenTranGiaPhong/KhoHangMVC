using Microsoft.AspNetCore.Mvc;
using KhoHangMVC.Models;

namespace KhoHangMVC.Controllers
{
    public class StockController : Controller
    {
        // Danh sách sản phẩm trong kho (giả lập, không dùng cơ sở dữ liệu)
        private static List<Stock> stocks = new List<Stock>();
        private static Random random = new Random();

        // Hàm sinh giá random cho sản phẩm
        private static int GenerateRandomPrice()
        {
            return random.Next(500000, 10000000); // Giá random từ 500,000 đến 10,000,000
        }

        // Hàm sinh số lượng random cho sản phẩm
        private static int GenerateRandomQuantity()
        {
            return random.Next(10, 500); // Số lượng random từ 10 đến 500
        }

        // Hàm tạo danh sách sản phẩm ngẫu nhiên
        private static void GenerateStockData()
        {
            var productNames = new List<string>
            {
                "Laptop Dell", "Điện thoại Samsung", "Tai nghe Sony", "Máy tính bảng iPad",
                "Smartwatch Samsung", "Ổ cứng SSD Kingston", "Chuột máy tính Logitech", "Bàn phím cơ Corsair",
                "Loa Bluetooth JBL", "Máy ảnh Canon", "Tai nghe Apple", "Điện thoại iPhone", "Máy tính xách tay HP",
                "Smartwatch Apple", "Máy chiếu ViewSonic", "Máy lọc không khí Xiaomi", "Máy in Canon", "Nồi chiên không dầu",
                "Loa Sony", "Máy tính để bàn Acer"
            };

            for (int i = 0; i < productNames.Count; i++)
            {
                stocks.Add(new Stock
                {
                    Id = i + 1,
                    ProductName = productNames[i],
                    Quantity = GenerateRandomQuantity(),
                    Price = GenerateRandomPrice()
                });
            }
        }

        // Khởi tạo dữ liệu sản phẩm nếu danh sách trống
        static StockController()
        {
            if (stocks.Count == 0)
            {
                GenerateStockData(); // Sinh danh sách sản phẩm mẫu khi khởi tạo
            }
        }

        // Hiển thị danh sách sản phẩm trong kho
        public IActionResult Index()
        {
            return View(stocks);
        }

        // Thêm sản phẩm mới
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Stock stock)
        {
            if (ModelState.IsValid)
            {
                stock.Id = stocks.Max(s => s.Id) + 1; // Tạo id mới
                stock.Price = GenerateRandomPrice();  // Random giá khi thêm sản phẩm
                stock.Quantity = GenerateRandomQuantity();  // Random số lượng khi thêm sản phẩm
                stocks.Add(stock);
                return RedirectToAction("Index");
            }
            return View(stock);
        }

        // Sửa thông tin sản phẩm
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var stock = stocks.FirstOrDefault(s => s.Id == id);
            if (stock == null)
            {
                return NotFound();
            }
            return View(stock);
        }

        [HttpPost]
        public IActionResult Edit(Stock stock)
        {
            if (ModelState.IsValid)
            {
                var existingStock = stocks.FirstOrDefault(s => s.Id == stock.Id);
                if (existingStock != null)
                {
                    existingStock.ProductName = stock.ProductName;
                    existingStock.Quantity = stock.Quantity;
                    existingStock.Price = stock.Price;
                }
                return RedirectToAction("Index");
            }
            return View(stock);
        }

        // Xóa sản phẩm
        public IActionResult Delete(int id)
        {
            var stock = stocks.FirstOrDefault(s => s.Id == id);
            if (stock != null)
            {
                stocks.Remove(stock);
            }
            return RedirectToAction("Index");
        }
    }
}


