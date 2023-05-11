using CTTSite.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTTSite.Models
{
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int ItemID { get; set; }

        [Required]
        public Item Item { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(1, 10)]
        public int Amount { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public bool Paid { get; set; }


        public CartItem(int iD, int itemID, Item item, int amount, int userID, User user, bool paid)
        {
            ID = iD;
            ItemID = itemID;
            Item = item;
            Amount = amount;
            UserID = userID;
            User = user;
            Paid = paid;
        }

        public CartItem(int iD, int itemID, int amount, int userID, bool paid)
        {
            ID = iD;
            ItemID = itemID;
            Amount = amount;
            UserID = userID;
            Paid = paid;
        }

        public CartItem()
        {
            
        }
    }
}
