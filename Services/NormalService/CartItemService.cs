using CTTSite.DAO;
using CTTSite.MockData;
using CTTSite.Models;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;

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
            Items = IItemService.GetAllItems();
        }

        public async Task AddToCartAsync(CartItem cartItem)
        {
            int IDCount = 0;
            foreach(CartItem listCartItem in CartItems)
            {
                if(IDCount < listCartItem.ID)
                {
                    IDCount = listCartItem.ID;
                }
            }
            cartItem.ID = IDCount + 1;
            CartItems.Add(cartItem);
            JsonFileService.SaveJsonObjects(CartItems);
            //await DBServiceGenericCartItem.AddObjectAsync(cartItem);
        }

        public async Task ConvertBoolPaidByUserIDAsync(int UserID)
        {
            foreach (CartItem cartItem in GetAllCartItemsByUserID(UserID))
            {
                cartItem.Paid = true;
            }
            JsonFileService.SaveJsonObjects(CartItems);
            //await DBServiceGenericCartItem.UpdateObjectsAsync(CartItems);
        }

        public List<CartItem> GetAllCartItems()
        {
            //return MockData.MockDataCartItem.GetMockCartItems();
            return JsonFileService.GetJsonObjects().ToList();
            //return DBServiceGenericCartItem.GetObjectsAsync().Result.ToList();
        }

        public CartItem GetCartItemByID(int ID)
        {
            foreach(CartItem cartItem in CartItems)
            {
                if(cartItem.ID == ID)
                {
                    return cartItem;
                }
            }
            return null;
        }

        public List<CartItem> GetAllCartItemsByUserID(int UserID)
        {
            List<CartItem> cartItemsByUserID = new List<CartItem>();
            foreach(CartItem cartItem in CartItems)
            {
                if(cartItem.UserID == UserID && cartItem.Paid == false)
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

        public async Task RemoveFromCartByIDAsync(int ID)
        {
            CartItem cartItemToBeDeleted = null;
            if(GetCartItemByID(ID) != null)
            {
                CartItems.Remove(GetCartItemByID(ID));
                JsonFileService.SaveJsonObjects(CartItems);
                //cartItemToBeDeleted = GetCartItemByID(ID);
                //await DBServiceGenericCartItem.DeleteObjectAsync(cartItemToBeDeleted);
            }
        }

        // TODO

        //public async Task AddCartItem_OrderToJunctionTable(int ID)
        //{
        //    List<CartItem> TempList = GetAllCartItemsByUserID(ID);
        //    Order order = new Order();
        //    foreach(CartItem cartItem in TempList)
        //    {
        //        new CartItem_Order(cartItem.ID, );
        //    }
        //    await DBServiceGenericCartItem_Order.SaveObjectsAsync(TempList);
        //}


        public decimal GetTotalPriceOfCartByUserID(int UserID)
        {
            decimal TotalPrice = 0;

            foreach(CartItem cartItem in GetAllCartItemsByUserID(UserID))
            {
                foreach (Item item in Items)
                {
                    if (item.ID == cartItem.ItemID)
                    {
                        TotalPrice += item.Price * cartItem.Amount;
                    }
                }
            }
            return TotalPrice;
        }

    }
}
