using CTTSite.Models;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;

namespace CTTSite.Services.NormalService
{
    public class CartItemService : ICartItemService
    {
        public DBServiceGeneric<CartItem> DBServiceGeneric;
        public JsonFileService<CartItem> JsonFileService;
        public List<CartItem> CartItems;

        public CartItemService(DBServiceGeneric<CartItem> dBServiceGeneric, JsonFileService<CartItem> jsonFileService)
        {
            DBServiceGeneric = dBServiceGeneric;
            JsonFileService = jsonFileService;
            CartItems = GetAllCartItems();
        }

        public async Task AddToCartAsync(CartItem cartItem)
        {
            CartItems.Add(cartItem);
            JsonFileService.SaveJsonObjects(CartItems);
            //await DBServiceGeneric.AddObjectAsync(cartItem);
        }

        public Task ConvertBoolPaidByUserIDAsync(int userID)
        {
            throw new NotImplementedException();
        }

        public List<CartItem> GetAllCartItems()
        {
            return JsonFileService.GetJsonObjects().ToList();
        }

        public List<CartItem> GetAllCartItemsByUserID(int userID)
        {
            List<CartItem> cartItemsByUserID = new List<CartItem>();
            foreach(CartItem cartItem in CartItems)
            {
                if(cartItem.UserID == userID)
                {
                    cartItemsByUserID.Add(cartItem);
                }
            }
            return cartItemsByUserID;
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
