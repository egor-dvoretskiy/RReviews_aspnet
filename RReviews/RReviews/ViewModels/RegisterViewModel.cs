using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RReviews.ViewModels
{
    public class RegisterViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Год рождения")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; } = string.Empty;
    }
}
