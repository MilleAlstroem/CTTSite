using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CTTSite.Pages.Staff.Admin
{
    // Made by Christian

    [Authorize(Roles = "admin")]
    public class GetAllUsersModel : PageModel
    {
        private IUserService _userService;
        public List<Models.User> _users {  get; set; }


        [BindProperty]
        public string SearchString { get; set; }

        public GetAllUsersModel(IUserService userService)
        {
            _userService = userService;
            _users = _userService.GetUsers();
        }
        public void OnGet()
        {
           
        }

		public IActionResult OnGetAll()
		{
			_users = _userService.GetUsers();
			return Page();
		}

		public IActionResult OnGetSortById()
        {
            _users = _userService.SortById().ToList();
            return Page();
        }

        public IActionResult OnGetSortByIdDescending()
        {
            _users = _userService.SortByIdDescending().ToList();
            return Page();
        }

        public IActionResult OnGetSortByEmail()
        {
            _users = _userService.SortByEmail().ToList();
            return Page();
        }

        public IActionResult OnGetSortByNameEmail()
        {
            _users = _userService.SortByEmailDescending().ToList();
            return Page();
        }

        public IActionResult OnGetClients()
        {
            _users = _userService.GetClients().ToList();
            return Page();
        }

        public IActionResult OnGetStaff()
        {
            _users = _userService.GetStaff().ToList();
            return Page();
        }
       
        public IActionResult OnPostEmailSearch()
        {
            _users = _userService.SearchUserByEmail(SearchString).ToList();
            return Page();
        }

        
    }
}
