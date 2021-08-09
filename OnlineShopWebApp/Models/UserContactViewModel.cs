using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserContactViewModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(44, MinimumLength = 2, ErrorMessage = "Имя должно быть не менее 2 и не более 44 символов")]
        public string ContactsName { get; set; }


        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(44, MinimumLength = 2, ErrorMessage = "Фамилия должна быть не менее 2 и не более 44 символов")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Не указан адрес")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Неккоректный адрес. Он должен быть не менее 2 и не более 100 символов")]
        public string Adress { get; set; }


        [Required(ErrorMessage = "Не указан телефон")]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Телефон должен быть не менее 3 и не более 16 символов")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "Укажите верный email")]
        public string Email { get; set; }

        public List<string> IsValid()
        {
            var errors = new List<string>();
            if (ContactsName== Surname)
            {
                errors.Add("Имя и Фамилия не должны совпадать");
            }
            if (ContactsName == Adress)
            {
                errors.Add("Имя и адрес не должны совпадать");
            }
            if (ContactsName == Email)
            {
                errors.Add("Имя и емейл не должны совпадать");
            }
            if (!IsLetter(ContactsName))
            {
                errors.Add("Имя должно состоять только из букв");
            }
            if (!IsLetter(Surname))
            {
                errors.Add("Фамилия должна состоять только из букв");
            }
            for (int i = 0; i < PhoneNumber.Length; i++)
            {
                if(!char.IsDigit(PhoneNumber[i]))
                {
                    errors.Add("Номер телефона должен быть числом");
                    break;
                }
            }
            return errors;
        }
        private bool IsLetter(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (!char.IsLetter(name[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}