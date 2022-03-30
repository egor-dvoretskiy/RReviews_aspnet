using RReviews.Enum;
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
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime TestingDate { get; set; }

        public string ObjectName { get; set; } = string.Empty;

        [DataType(DataType.MultilineText)]
        public string Content { get; set; } = string.Empty;

        [Range(0, 10, ErrorMessage = "Allowed rating in 0..10")]
        public int ReviewRating { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Value should be positive.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }

        [EnumDataType(typeof(ReviewObject), ErrorMessage = "Review object doesn't exist within enum")]
        public ReviewObject ReviewTypeObject { get; set; }
    }
}
