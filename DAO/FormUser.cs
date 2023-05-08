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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public User User { get; set; }
        public Form Form { get; set; }
    }
}
