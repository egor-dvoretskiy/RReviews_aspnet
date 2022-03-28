using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RReviews.Models
{
    public class Review
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime TestingDate { get; set; }

        public string Content { get; set; } = string.Empty;

        [Range(1, 10)]
        public int Rating;

        [DataType(DataType.ImageUrl)]
        public object? Img { get; set; } = null;

        [Range(0, double.MaxValue, ErrorMessage = "Only positive number allowed")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }
    }
}
