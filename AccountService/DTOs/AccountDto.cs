using System.ComponentModel.DataAnnotations;

namespace AccountService.DTOs;

public class AccountDto
{
    [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống")]
    public string? Username { get; set; }
    [StringLength(20, MinimumLength = 8, ErrorMessage = "Mật khẩu ít nhất 8 kí tự")]
    public string? Password { get; set; }
}