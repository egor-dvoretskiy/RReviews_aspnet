#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RReviews.Data;
using RReviews.Models;

namespace RReviews.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly RReviews.Data.RReviewsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(RReviews.Data.RReviewsContext context, IWebHostEnvironment webHostEnvironment)
        {
            this._context = context;
            this._webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ReviewModel Review { get; set; }

        [BindProperty]
        public ImageModel Image { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (this.Image.formFile != null)
            {
                Guid guid = Guid.NewGuid();

                var filename = this.Image.formFile.FileName;

                string path = @"/img/reviews/";
                string imagePath = this._webHostEnvironment.WebRootPath + path;
                string imageExtension = Path.GetExtension(filename);
                string imageName = string.Concat(guid, imageExtension);

                string relativePathToImage = Path.Combine(path, imageName);
                string fullPathToImage = Path.Combine(imagePath, imageName);

                using (FileStream fileStream = new FileStream(fullPathToImage, FileMode.Create))
                {
                    await this.Image.formFile.CopyToAsync(fileStream);
                }

                this.Image.Name = guid;
                this.Image.RelativePath = relativePathToImage;

                this.Review.ImageKey = guid;

                _context.Image.Add(this.Image);
            }

            _context.Review.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
