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
        }

        public DbSet<RReviews.Models.Review> Review { get; set; }
    }
}
