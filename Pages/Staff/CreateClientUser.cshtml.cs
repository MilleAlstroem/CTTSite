using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CTTSite.Pages.Staff
{
    [Authorize(Roles = "staff")]
    public class CreateClientUserModel : PageModel
    {
        private IUserService _userService;
        
        [BindProperty]
        public string Email { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public CreateClientUserModel(IUserService userService)
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
            _userService.AddUser(new Models.User(Email, Password, false, false));
            return RedirectToPage("/Index");
        }
    }
}