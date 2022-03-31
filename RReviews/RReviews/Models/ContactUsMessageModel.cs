using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RReviews.Models
{
    public class ContactUsMessageModel
    {
        public int Id { get; set; }

        [Display(Name = "FirstName")]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "LastName")]
        [Required]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Text")]
        public string? AdditionalInformation { get; set; }
    }
}
