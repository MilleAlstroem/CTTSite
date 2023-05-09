using CTTSite.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTTSite.DAO
{
    public class CartItem_Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public CartItem CartItem { get; set; }
        public Order Order { get; set; }
    }
}
