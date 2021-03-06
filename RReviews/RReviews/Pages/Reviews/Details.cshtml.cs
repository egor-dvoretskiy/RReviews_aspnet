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
    public class DetailsModel : PageModel
    {
        private readonly RReviews.Data.RReviewsContext _context;

        public DetailsModel(RReviews.Data.RReviewsContext context)
        {
            _context = context;
        }

        public ReviewModel Review { get; set; }
        public ImageModel Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Review = await _context.Review.FirstOrDefaultAsync(m => m.Id == id);
            Image = await _context.Image.FirstOrDefaultAsync(m => Review.ImageKey == m.Name);

            if (Review == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
