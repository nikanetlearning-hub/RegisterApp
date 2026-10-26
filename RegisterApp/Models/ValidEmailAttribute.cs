using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RegisterApp.Models;

public class ValidEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return new ValidationResult("ایمیل الزامی است.");
        }

        var email = value.ToString()!;

        // ۱. استفاده از اعتبارسنج پایه دات‌نت برای فیلتر اولیه
        var basicValidator = new EmailAddressAttribute();
        if (!basicValidator.IsValid(email))
        {
            return new ValidationResult("فرمت ایمیل معتبر نیست.");
        }

        // ۲. بررسی Regex برای اطمینان از وجود دامنه و پسوند معتبر (حداقل ۲ حرف)
        // این الگو جلوی چیزهایی مثل "ش@ش" را می‌گیرد.
        var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$");
        if (!regex.IsMatch(email))
        {
            return new ValidationResult("ایمیل باید شامل دامنه و پسوند معتبر باشد (مثلاً user@example.com).");
        }

        return ValidationResult.Success;
    }
}