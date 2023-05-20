using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CTTSite.Pages.Staff
{
    // Made by Christian

    [Authorize(Roles = "staff")]
    public class CreateClientUserModel : PageModel
    {
        private IUserService _iUserService;
        
        [BindProperty]
        public string Email { get; set; }

        //[BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public Task<bool> SuccessfulCreation { get; set; }

        public string Message { get; set; }

        public Models.User newUser { get; set; }

        private PasswordHasher<string> passwordHasher;

        public CreateClientUserModel(IUserService userService)
        {
            _iUserService = userService;
            passwordHasher = new PasswordHasher<string>();
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {

            //if ((Email == null) && (Password == null))
            //{
            //    Message = "Please enter an email address and a password!!!";
            //    return Page();
            //}

            if (Email == null)
            {
                Message = "Please enter an email address";
                return Page();
            }

            //if (Password == null)
            //{
            //    Message = "Please enter password";
            //    return Page();
            //}

            //bool containsUppercase = false;

            //foreach (char c in Password)
            //{
            //    if (char.IsUpper(c))
            //    {
            //        containsUppercase = true;
            //        break;
            //    }
            //}

            //if ((Password.Length < 6) && (!Email.Contains("@")) && (!containsUppercase))
            //{
            //    Message = "The details you have entered are invalid. Please use a valid email address and a password which is at least 6 characters long and contains at least one capital letter and at least one number!!!";
            //    return Page();
            //}

            //if ((Password.Length < 6) && (!containsUppercase))
            //{
            //    Message = "Please use a password which is at least 6 characters long and contains at least one capital letter and at least one number!!!";
            //    return Page();
            //}

            if (!Email.Contains("@"))
            {
                Message = "Please use a valid email address!!!";
                return Page();
            }

            //if (!containsUppercase)
            //{
            //    Message = "Password must contain at least one uppercase letter!!!";
            //    return Page();
            //}

            //if (Password.Length < 6)
            //{
            //    Message = "Password must be at least 6 characters long!!!";
            //    return Page();
            //}


            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            Password = new String(stringChars);
            _iUserService.SaveNewPassword(Password);

            newUser = new Models.User(Email, passwordHasher.HashPassword(null, Password), false, true);
            SuccessfulCreation = _iUserService.AddUser(newUser);
            if (SuccessfulCreation.Result == true)
            {
                await _iUserService.AddUser(newUser);
                _iUserService.ForgottenPassword(newUser.Email);

                return RedirectToPage("UserCreatedConfirmation");
            }
            else
            {
                Message = "Email already exists!!!";
                return Page();
            }

        }
    }
}
