using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CTTSite.Models;
using CTTSite.Services.NormalService;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using CTTSite.Services.Interface;

namespace CTTSite.Pages.User.LogIn
{
    public class LogInPageModel : PageModel
    {
        public static Models.User LoggedInUser { get; set; } = null;
        private IUserService _userService;

        private List<Models.User> _users { get; set; }

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

            List<Models.User> users = _userService.GetUsers();
            foreach (Models.User user in users)
            {

                if (Email == user.Email && Password == user.Password)
                { 

                    LoggedInUser = user;
                                       
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, Email) };

                    if (LoggedInUser.Admin == true) claims.Add(new Claim(ClaimTypes.Role, "admin"));
                    if (LoggedInUser.Staff == true) claims.Add(new Claim(ClaimTypes.Role, "staff"));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToPage("/Index");

                }

            }

            Message = "Invalid attempt";
            return Page();
        }
    }
}
