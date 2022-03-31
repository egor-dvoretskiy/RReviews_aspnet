using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RReviews.Models
{
    public class ImageModel
    {
        public int Id { get; set; }

        [Required]
        public Guid Name { get; set; }

        [Required]
        public string Path { get; set; } = string.Empty;

        [NotMapped]
        public IFormFile? formFile { get; set; }
    }
}
