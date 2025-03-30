using System.ComponentModel.DataAnnotations;

namespace KhoHangMVC.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc.")]
        public string? Username { get; set; }  // Thêm '?' để cho phép giá trị null

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        public string? Password { get; set; }  // Thêm '?' để cho phép giá trị null
    }
}
