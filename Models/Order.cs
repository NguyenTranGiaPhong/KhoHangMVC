using System.ComponentModel.DataAnnotations;  // Thêm thư viện này
using System;

namespace KhoHangMVC.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên khách hàng là bắt buộc.")]
        public string CustomerName { get; set; }  // Thêm required để bắt buộc giá trị

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Trạng thái đơn hàng là bắt buộc.")]
        public string Status { get; set; }  // Thêm required để bắt buộc giá trị

        // Constructor mặc định để khởi tạo các thuộc tính non-nullable
        public Order()
        {
            CustomerName = string.Empty; // Giá trị mặc định là chuỗi rỗng
            Status = string.Empty; // Giá trị mặc định là chuỗi rỗng
        }
    }
}


