using CTTSite.Services.Interface;
using CTTSite.Services.NormalService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;
using CTTSite.Models;

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

        public CreateStaffUserModel(IUserService userService)
        {
            _userService = userService;
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
            _userService.AddUser(new Models.User(Email, Password, false, true));
            return RedirectToPage("/Index");
        }
    }
}
