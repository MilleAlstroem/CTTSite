using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CTTSite.Pages.Staff.Admin
{   
    [Authorize(Roles = "admin")]
    public class GetAllUsersModel : PageModel
    {
        private IUserService _userService;
        public List<Models.User> _users {  get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public GetAllUsersModel(IUserService userService)
        {
            _userService = userService;
            _users = _userService.GetUsers();
        }
        public void OnGet()
        {
           
        }
    }
}
