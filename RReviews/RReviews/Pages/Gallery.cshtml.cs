#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using RReviews.Data;
using RReviews.Models;

namespace RReviews.Pages
{
    public class GalleryModel : PageModel
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public GalleryModel(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public List<string> ImageList { get; set; }

        public IActionResult OnGetAsync()
        {
            string pathToStaticFiles = this.webHostEnvironment.WebRootPath;
            string relativePathToImages = @"\img\reviews\";

            var provider = new PhysicalFileProvider(pathToStaticFiles);
            var contents = provider.GetDirectoryContents(relativePathToImages);
            var objFiles = contents.OrderBy(f => f.LastModified);

            ImageList = new List<string>();
            foreach (var file in objFiles.ToList())
            {
                ImageList.Add(Path.Join(relativePathToImages, file.Name));
            }

            return Page();
            //return new JsonResult(objFiles);
        }
    }
}
