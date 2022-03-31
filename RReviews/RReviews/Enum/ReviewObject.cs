using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RReviews.Enum
{
    public enum ReviewObject
    {
        [Display(Name = "none")]
        None,

        [Display(Name = "etc")]
        Etc,

        [Display(Name = "food")]
        Food,

        [Display(Name = "book")]
        Book,

        [Display(Name = "company")]
        Company,

        [Display(Name = "car")]
        Car,

        [Display(Name = "movie")]
        Movie,

        [Display(Name = "person")]
        Person,

        [Display(Name = "music")]
        Music,
    }
}
