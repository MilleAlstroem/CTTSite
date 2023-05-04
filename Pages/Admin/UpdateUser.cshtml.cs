using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Admin
{
    public class UpdateUserModel : PageModel
    {
        private IUserService _userService;

        public UpdateUserModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Models.User User { get; set; }

        public void OnGet()
        {
        }
    }
}
