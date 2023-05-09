using CTTSite.Models;
using CTTSite.Models.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTTSite.DAO
{
    // Made by Christian

    public class FormUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public User User { get; set; }

        [Required]
        [ForeignKey("Form")]
        public Form Form { get; set; }

        public FormUser()
        {
        }

        public FormUser(User user, Form form)
        {
            User = user;
            Form = form;
        }
    }
}
