using System.ComponentModel.DataAnnotations;

namespace KhoHangMVC.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public string? ProductName { get; set; }  // Đổi thành nullable

        public int Quantity { get; set; } // Số lượng sản phẩm trong kho

        public decimal Price { get; set; } // Giá của sản phẩm
    }
}
