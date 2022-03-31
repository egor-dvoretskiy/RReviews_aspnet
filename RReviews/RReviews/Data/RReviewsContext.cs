#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RReviews.Models;

namespace RReviews.Data
{
    public class RReviewsContext : DbContext
    {
        public RReviewsContext (DbContextOptions<RReviewsContext> options)
            : base(options)
        {
            _ = Database.EnsureCreated();
        }

        public DbSet<RReviews.Models.ImageModel> Image { get; set; }

        public DbSet<RReviews.Models.ReviewModel> Review { get; set; }

        public DbSet<RReviews.Models.ContactUsMessageModel> ContactUsMessage { get; set; }
    }
}
