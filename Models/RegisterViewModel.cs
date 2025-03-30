using System.ComponentModel.DataAnnotations;

namespace KhoHangMVC.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        public string? Password { get; set; } // Thay đổi thành nullable

        [Required(ErrorMessage = "Xác nhận mật khẩu là bắt buộc.")]
        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp.")]
        public string? ConfirmPassword { get; set; } // Thay đổi thành nullable

        // Constructor mặc định
        public RegisterViewModel()
        {
            Username = string.Empty; // Khởi tạo Username với giá trị mặc định
            Password = string.Empty; // Khởi tạo Password với giá trị mặc định
            ConfirmPassword = string.Empty; // Khởi tạo ConfirmPassword với giá trị mặc định
        }
    }
}
