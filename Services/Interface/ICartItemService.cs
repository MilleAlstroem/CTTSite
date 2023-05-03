using CTTSite.Models;

namespace CTTSite.Services.Interface
{
    public interface ICartItemService
    {
        List<CartItem> GetAllCartItems();
        List<CartItem> GetAllCartItemsByUserID(int userID);
        Task AddToCartAsync(CartItem cartItem);
        Task RemoveFromCartByIDAsync(int ID);
        Task ConvertBoolPaidByUserIDAsync(int userID);
        List<CartItem> GetOldCartItemsByID(int ID);
    }
}
