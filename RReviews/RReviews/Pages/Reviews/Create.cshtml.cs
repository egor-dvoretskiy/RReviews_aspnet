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
            var filename = this.Image.formFile.FileName;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Review.Add(Review);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }

        private async void AddImage(IFormFile image)
        {

            if (image != null)
            {
                Guid guid = Guid.NewGuid();

                string path = @"\img\reviews\";
                string imagePath = this._webHostEnvironment.WebRootPath + path;
                string imageExtension = Path.GetExtension(image.Name);
                string imageName = string.Concat(guid, imageExtension);

                string fullPathToImage = Path.Combine(imagePath, imageName);

                using (FileStream fileStream = new FileStream(fullPathToImage, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                ImageModel imageModel = new ImageModel { Name = guid, Path = fullPathToImage };
                this.Review.ImageKey = guid;

                _context.Image.Add(imageModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
