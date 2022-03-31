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

namespace RReviews.Pages.Contacts
{
    public class CreateModel : PageModel
    {
        private readonly RReviews.Data.RReviewsContext _context;

        public CreateModel(RReviews.Data.RReviewsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ContactUsMessageModel ContactUsMessage { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ContactUsMessage.Add(ContactUsMessage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
