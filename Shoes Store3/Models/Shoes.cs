using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shoes_Store3.Models
{
    public class Shoes
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        [Display(Name = "Модель обуви")]
        public string Model_Name { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Range(1, 50, ErrorMessage = "Недопустимый размер")]
        [Display(Name = "Размер")]
        public int Size { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"[0-9]", ErrorMessage = "Значением поля Цена должно быть число")]
        [Display(Name = "Цена")]
        public int Price { get; set; }
        [Display(Name = "Фирма Id")]
        public int? FirmaId { get; set; } 
        public Firmas Firma { get; set; }
    }
}