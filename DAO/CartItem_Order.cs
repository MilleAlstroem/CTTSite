using CTTSite.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTTSite.DAO
{
    public class CartItem_Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public CartItem CartItem { get; set; }
        public Order Order { get; set; }

        public CartItem_Order(CartItem cartItem, Order order)
        {
            CartItem = cartItem;
            Order = order;
        }

        public CartItem_Order()
        {
        }
    }
}
