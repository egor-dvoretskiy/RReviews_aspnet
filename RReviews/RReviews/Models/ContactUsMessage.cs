using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RReviews.Models
{
    public class ContactUsMessage
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        public string? AdditionalInformation { get; set; }
    }
}
