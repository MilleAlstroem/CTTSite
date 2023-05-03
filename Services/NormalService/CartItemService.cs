using CTTSite.Models;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;

namespace CTTSite.Services.NormalService
{
    public class CartItemService : ICartItemService
    {
        public DBServiceGeneric<CartItem> DBServiceGeneric;

        public async Task AddToCartAsync(CartItem cartItem)
        {
            await DBServiceGeneric.AddObjectAsync(cartItem);
        }

        public Task ConvertBoolPaidByUserIDAsync(int userID)
        {
            throw new NotImplementedException();
        }

        public List<CartItem> GetAllCartItems()
        {
            throw new NotImplementedException();
        }

        public List<CartItem> GetAllCartItemsByUserID(int userID)
        {
            throw new NotImplementedException();
        }

        public List<CartItem> GetOldCartItemsByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromCartByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
