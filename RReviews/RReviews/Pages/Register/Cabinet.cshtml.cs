using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RReviews.Models;

namespace RReviews.Pages.Register
{
    public class CabinetModel : PageModel
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public CabinetModel(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public UserModel CurrentUser { get; set; }

        public async void OnGetAsync()
        {
            /*this.UserModel = await this._userManager.GetUserAsync(HttpContext.User);*/
            var name = HttpContext.User.Identity.Name;
            this.CurrentUser = this._userManager.Users.Where(x => x.UserName.Equals(name)).SingleOrDefault();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToPage("../Index");
        }
    }
}
