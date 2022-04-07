using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RReviews.Data;
using RReviews.Models;

namespace RReviews.Pages.Shared
{
    public class SidebarPartialModel : PageModel
    {
        private readonly RReviewsContext _context;
        private const int AmountOfBestReviews = 3;

        public SidebarPartialModel(RReviewsContext context)
        {
            _context = context;
        }

        public IList<ReviewModel> Review { get; set; }
        public IList<ImageModel> Images { get; set; }

        public async Task OnGetAsync()
        {
            var reviews = _context.Review;
            this.Review = reviews
                .OrderBy(item => item.ReviewRating)
                .Take(AmountOfBestReviews)
                .ToList();

            this.Images = _context.Image.Where(x => this.Review.Any(y => y.ImageKey == x.Name)).ToList();
        }

        public string GetPathByItem(ReviewModel model)
        {
            return this.Images.Where(x => x.Name == model.ImageKey).SingleOrDefault().RelativePath;
        }
    }
}
