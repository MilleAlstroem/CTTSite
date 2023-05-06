using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.User.LogIn
{
    public class ForgottenPasswordPageModel : PageModel
    {

        [BindProperty]
        public string Email { get; set; }

        public string Message { get; set; }
        private PasswordHasher<string> passwordHasher;

        private IUserService _userService;

        public ForgottenPasswordPageModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Email == null)
            {
                Message = "Please enter an email address!!!";
                return Page();
            }
            List<Models.User> users = _userService.GetAllUsers();
            foreach (Models.User user in users)
            {
                if (Email == user.Email)
                {
                    passwordHasher = new PasswordHasher<string>();                   
                    user.Id = user.Id;
                    user.Email = user.Email;
                    user.Password = passwordHasher.HashPassword(null, "H876ts78F!7k");
                    user.Admin = user.Admin;
                    user.Staff = user.Staff;
                    
                    _userService.UpdateUserAsync(user);
                    _userService.ForgottenPassword(user.Email);
                    Message = "An email has been sent to you with your password!!!";
                    return Page();
                }
            }
            Message = "There is no user with that email address!!!";
            return Page();
        }
    }
}
