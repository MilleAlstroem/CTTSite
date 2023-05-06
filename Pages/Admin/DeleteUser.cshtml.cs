using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CTTSite.Services.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CTTSite.Models;

namespace CTTSite.Pages.Admin
{
	// Made by Christian

	public class DeleteUserModel : PageModel
    {  
        private IUserService _iUserService;

        [BindProperty]
        public Models.User user { get; set; }

		public DeleteUserModel(IUserService iUserService)
		{
			_iUserService = iUserService;

		}

		public IActionResult OnGet(int id)
        {
			user = _iUserService.GetUser(id);
			if (user == null)
				return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			Models.User deletedUser = user;

			_iUserService.DeleteUserByID(deletedUser.Id);
			
			if (deletedUser == null)
				return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

			return RedirectToPage("GetAllUsers");
		}
	}
}
