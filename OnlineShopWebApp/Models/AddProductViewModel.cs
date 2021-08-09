using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Имя должно быть не менее 2 символов и не более 100 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Цена не указана")]
        [Range(1, 1000000, ErrorMessage = "Цена должна быть в пределах от 1 до 1 000 000 руб.")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Не указано описание")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "Описание должно быть не менее 2 символов и не более 300 символов")]
        public string Description { get; set; }

        public IFormFile[] UploadedFiles { get; set; }
        public List<string> IsValid()
        {
            var errors = new List<string>();
            if (Name == Description)
            {
                errors.Add("Название и описание товара не должны совпадать");
            }
            if (Name == Cost.ToString())
            {
                errors.Add("Название и цена не должны совпадать");
            }
            if (Description == Cost.ToString())
            {
                errors.Add("Описание и цена не должны совпадать");
            }
            return errors;
        }
    }
}
