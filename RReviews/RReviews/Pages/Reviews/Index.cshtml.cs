#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RReviews.Data;
using RReviews.Enum;
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

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public ReviewObject ReviewType { get; set; }

        public IList<Review> Review { get;set; }

        public SelectList Types { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<ReviewObject> typesQuery = from m in _context.Review
                                            orderby m.ReviewTypeObject
                                            select m.ReviewTypeObject;

            var reviews = from m in _context.Review
                          select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                reviews = reviews.Where(x => x.ObjectName.Contains(this.SearchString));
            }

            if (ReviewType != ReviewObject.None)
            {
                reviews = reviews.Where(x => x.ReviewTypeObject == ReviewType);
            }
           

            Types = new SelectList(await typesQuery.Distinct().ToListAsync());
            Review = await reviews.ToListAsync();
        }
    }
}
