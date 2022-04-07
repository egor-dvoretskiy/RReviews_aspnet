using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RReviews.Models;
using RReviews.ViewModels;

namespace RReviews.Pages.Register
{
    public class LoginModel : PageModel
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public LoginModel(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            var returnUrl = Request.Headers["Referer"].ToString();
            ReturnUrl = returnUrl;

            return Page();
        }

        [BindProperty]
        public LoginViewModel LoginViewModel { get; set; }

        public static string ReturnUrl { get; set; } = string.Empty;

        public async Task<IActionResult> OnPostAsync()
        {
            this.LoginViewModel.ReturnUrl = ReturnUrl;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(LoginViewModel.Email, LoginViewModel.Password, LoginViewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(LoginViewModel.ReturnUrl) && Url.IsLocalUrl(LoginViewModel.ReturnUrl))
                    {
                        return RedirectToPage("../Index");
                    }
                    else
                    {
                        return Redirect(LoginViewModel.ReturnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }

            return RedirectToPage("../Index");
        }
    }
}
