using CTTSite.DAO;
using CTTSite.EFDbContext;
using CTTSite.MockData;
using CTTSite.Models;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;
using Microsoft.EntityFrameworkCore;

namespace CTTSite.Services.NormalService
{
    public class CartItemService : ICartItemService
    {
        public DBServiceGeneric<CartItem> DBServiceGenericCartItem;
        public DBServiceGeneric<CartItem_Order> DBServiceGenericCartItem_Order;
        public JsonFileService<CartItem> JsonFileService;
        public IItemService IItemService;
        public List<CartItem> CartItems;
        public List<Item> Items;

        public CartItemService(DBServiceGeneric<CartItem> dBServiceGenericCartItem, JsonFileService<CartItem> jsonFileService, DBServiceGeneric<CartItem_Order> dBServiceGenericCartItem_Order, IItemService iItemService)
        {
            DBServiceGenericCartItem = dBServiceGenericCartItem;
            DBServiceGenericCartItem_Order = dBServiceGenericCartItem_Order;
            JsonFileService = jsonFileService;
            IItemService = iItemService;
            CartItems = GetAllCartItems();
            Items = IItemService.GetAllItemsAsync().Result;
        }

        public async Task AddToCartAsync(CartItem cartItem)
        {
            //int IDCount = 0;
            //foreach(CartItem listCartItem in CartItems)
            //{
            //    if(IDCount < listCartItem.ID)
            //    {
            //        IDCount = listCartItem.ID;
            //    }
            //}
            //cartItem.ID = IDCount + 1;
            CartItems.Add(cartItem);
            //JsonFileService.SaveJsonObjects(CartItems);
            await DBServiceGenericCartItem.AddObjectAsync(cartItem);
        }

        public async Task ConvertBoolPaidByUserIDAsync(int UserID)
        {
            foreach (CartItem cartItem in GetAllCartItemsByUserID(UserID))
            {
                cartItem.Paid = true;
                await DBServiceGenericCartItem.UpdateObjectAsync(cartItem);
            }
            //JsonFileService.SaveJsonObjects(CartItems);
        }

        public List<CartItem> GetAllCartItems()
        {
            //return MockData.MockDataCartItem.GetMockCartItems();
            //return JsonFileService.GetJsonObjects().ToList();
            return DBServiceGenericCartItem.GetObjectsAsync().Result.ToList();
        }

        public CartItem GetCartItemByID(int ID)
        {
            using (var context = new ItemDbContext())
            {
                return context.CartItems
                    .Include(ci => ci.Item)
                    .FirstOrDefault(cartItem => cartItem.ID == ID);
            }
        }

        public List<CartItem> GetAllCartItemsByUserID(int userID)
        {
            List<CartItem> cartItemsByUserID = new List<CartItem>();
            using (var context = new ItemDbContext())
            {
                var cartItems = context.CartItems
                    .Include(ci => ci.Item)
                    .Where(ci => ci.UserID == userID && !ci.Paid)
                    .ToList();

                cartItemsByUserID.AddRange(cartItems);
            }
            return cartItemsByUserID;
        }

        public List<CartItem> GetOldCartItemsByID(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveFromCartByIDAsync(int ID)
        {
            CartItem cartItemToBeDeleted = null;
            if(GetCartItemByID(ID) != null)
            {
                cartItemToBeDeleted = GetCartItemByID(ID);

                CartItems.Remove(GetCartItemByID(ID));
                //JsonFileService.SaveJsonObjects(CartItems);
                await DBServiceGenericCartItem.DeleteObjectAsync(cartItemToBeDeleted);
            }
        }

        public decimal GetTotalPriceOfCartByUserID(int UserID)
        {
            decimal TotalPrice = 0;

            foreach(CartItem cartItem in GetAllCartItemsByUserID(UserID))
            {
                foreach (Item item in Items)
                {
                    if (item.ID == cartItem.ItemID)
                    {
                        TotalPrice += item.Price * cartItem.Quantity;
                    }
                }
            }
            return TotalPrice;
        }

    }
}
