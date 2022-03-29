#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RReviews.Data;
using RReviews.Models;

namespace RReviews.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly RReviews.Data.RReviewsContext _context;

        public IndexModel(RReviews.Data.RReviewsContext context)
        {
            _context = context;
        }

        public IList<Review> Review { get;set; }

        public async Task OnGetAsync()
        {
            Review = await _context.Review.ToListAsync();
        }
    }
}
