using System.ComponentModel.DataAnnotations;

namespace RegisterApp.Models;

public class LoginModel
{
    [Required(ErrorMessage = "ایمیل الزامی است.")]
    [ValidEmail(ErrorMessage = "فرمت ایمیل معتبر نیست.")]    

    public string? Email { get; set; }

    [Required(ErrorMessage = "رمز عبور الزامی است.")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    public bool RememberMe { get; set; }
}