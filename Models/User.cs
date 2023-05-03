using System.ComponentModel.DataAnnotations;

namespace CTTSite.Models
{
    // Made by Christian
    public class User
    {
        private int nextId = 0;
        public int Id { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(6, MinimumLength = 3, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        public bool Admin { get; set; }

        public bool Staff { get; set; }



        public User()
        {
        }

        public User(string email, string password, bool admin, bool staff)
        {
            Id = nextId++;            
            Email = email;
            Password = password;
            Admin = admin;
            Staff = staff;
        }
    }
}
