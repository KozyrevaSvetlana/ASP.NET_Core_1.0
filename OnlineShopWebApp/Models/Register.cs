using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "Укажите верный email")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(35, MinimumLength = 6, ErrorMessage = "Пароль должен быть минимум 6 символов, максимум 35 символов")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Не указано подтверждение пароля")]
        [StringLength(35, MinimumLength = 6, ErrorMessage = "Пароль должен быть минимум 4 символов, максимум 35 символов")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string CheckPassword { get; set; }
        public string ReturnUrl { get; set; }
    }
}
