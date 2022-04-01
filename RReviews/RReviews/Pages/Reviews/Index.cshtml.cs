#nullable disable
using System;
using System.Collections.Concurrent;
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
        private readonly IConfiguration _configuration;
        public readonly string PathToDefaultImage = string.Empty;
        

        public IndexModel(RReviews.Data.RReviewsContext context, IConfiguration configuration)
        {
            _context = context;
            this._configuration = configuration;
            this.PathToDefaultImage = this._configuration.GetValue<string>("StaticFiles:Images:RelativePath");
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public ReviewObject ReviewType { get; set; }

        public IList<ReviewModel> Review { get;set; }

        public IList<ImageModel> Image { get; set; }

        public SelectList Types { get; set; }

        private ConcurrentDictionary<ReviewModel, ImageModel> _models = new ConcurrentDictionary<ReviewModel, ImageModel>();

        public async Task OnGetAsync()
        {
            IQueryable<ReviewObject> typesQuery = from m in _context.Review
                                            orderby m.ReviewTypeObject
                                            select m.ReviewTypeObject;

            this.Image = await _context.Image.ToListAsync();

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

            this.AssignModels();
        }

        public string GetPathByItem(ReviewModel review)
        {
            string path = string.Empty;

            bool isValid = this._models.TryGetValue(review, out ImageModel image);

            if (!isValid)
            {
                path = this._configuration.GetValue<string>("StaticFiles:Images:PathToDefaultImage");
            }
            else
            {
                path = image.RelativePath;
            }

            return path;
        }

        private void AssignModels()
        {
            foreach (var item in this.Review)
            {
                var image = Image.Where(x => x.Name == item.ImageKey).SingleOrDefault();
                if (image != null)
                {
                    _ = this._models.TryAdd(item, image);
                }
            }
        }
    }
}
