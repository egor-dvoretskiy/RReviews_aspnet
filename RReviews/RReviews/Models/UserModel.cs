using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RReviews.Models
{
    public class UserModel : IdentityUser
    {
        public DateTime BirthDate { get; set; }
    }
}
