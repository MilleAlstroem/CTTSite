using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CTTSite.Models;
using CTTSite.Services.NormalService;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace CTTSite.Pages.User.LogIn
{
    public class LogInPageModel : PageModel
    {
        // Made by Christian

        //public static Models.User LoggedInUser { get; set; } = null;
        private IUserService _userService;

        

        [BindProperty]
        public string Email { get; set; }
        
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }

        public LogInPageModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            List<Models.User> users = _userService.GetAllUsers();
            foreach (Models.User user in users)
            {

                if (Email == user.Email)
                {
                    
                    var passwordHasher = new PasswordHasher<string>();

                    if (passwordHasher.VerifyHashedPassword(null, user.Password, Password) == PasswordVerificationResult.Success)
                    {
                        //LoggedInUser = user;
                        //Models.User _user = _userService.GetUserByEmail(Email);

                        var claims = new List<Claim> { new Claim(ClaimTypes.Name, Email) };

                        //if (_user.Admin == true) claims.Add(new Claim(ClaimTypes.Role, "admin"));
                        //if (_user.Staff == true) claims.Add(new Claim(ClaimTypes.Role, "staff"));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Index");
                    }
                        
                }

            }

            Message = "There is something wrong with your email or password!!!";
            return Page();
        }
    }
}
