using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTTSite.Models
{
    // Made by Christian
    public class User
    {
        private static int nextId = 0;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Email must be at least 3 characters long")]
        public string Email { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        [Required]
        public bool Admin { get; set; }

        [Required]
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
