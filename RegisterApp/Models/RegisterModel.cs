using System.ComponentModel.DataAnnotations;

namespace RegisterApp.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "نام الزامی است.")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "نام خانوادگی الزامی است.")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "ایمیل الزامی است.")]
    [ValidEmail(ErrorMessage = "فرمت ایمیل معتبر نیست.")] 

    public string? Email { get; set; }

    [Required(ErrorMessage = "رمز عبور الزامی است.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "رمز عبور باید حداقل ۸ کاراکتر باشد.")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required(ErrorMessage = "تکرار رمز عبور الزامی است.")]
    [Compare(nameof(Password), ErrorMessage = "رمز عبور و تکرار آن یکسان نیستند.")]
    [DataType(DataType.Password)]
    public string? ConfirmPassword { get; set; }

    [Range(typeof(bool), "true", "true", ErrorMessage = "پذیرش قوانین الزامی است.")]
    public bool AcceptTerms { get; set; }
}