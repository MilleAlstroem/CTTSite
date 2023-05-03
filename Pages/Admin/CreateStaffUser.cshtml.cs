using CTTSite.Services.Interface;
using CTTSite.Services.NormalService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;
using CTTSite.Models;
using Microsoft.AspNetCore.Identity;

namespace CTTSite.Pages.Staff.Admin
{
    [Authorize(Roles = "admin")]
    public class CreateStaffUserModel : PageModel
    {
        private IUserService _userService;

        [BindProperty]
        public string Email { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool SuccessfulCreation { get; set; }
        public string Message { get; set; }

        private PasswordHasher<string> passwordHasher;

        public CreateStaffUserModel(IUserService userService)
        {
            _userService = userService;
            passwordHasher = new PasswordHasher<string>();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SuccessfulCreation = _userService.AddUser(new Models.User(Email, passwordHasher.HashPassword(null, Password), false, true));
            if (SuccessfulCreation == true)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                Message = "Email already exists!!!";
                return Page();
            }
        }
    }
}
