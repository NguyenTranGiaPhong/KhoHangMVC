using System.ComponentModel.DataAnnotations;  // Thêm thư viện này
using System;

namespace KhoHangMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
        public string? Name { get; set; }  // Thay đổi thành nullable

        [Required(ErrorMessage = "Mô tả sản phẩm là bắt buộc.")]
        public string? Description { get; set; }  // Thay đổi thành nullable

        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Constructor không cần thiết nữa vì các thuộc tính có thể nhận giá trị null
    }
}
