using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RReviews.ViewModels;

namespace RReviews.Data
{
    public class AuthDbContext : IdentityDbContext<UserModel>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
            _ = Database.EnsureCreated();
        }
        public DbSet<RReviews.ViewModels.RegisterViewModel> RegisterViewModel { get; set; }
    }
}
