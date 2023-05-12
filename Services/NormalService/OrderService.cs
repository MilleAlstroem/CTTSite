using CTTSite.DAO;
using CTTSite.Models;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;

namespace CTTSite.Services.NormalService
{
    public class OrderService : IOrderService
    {
        public DBServiceGeneric<Order> DBServiceGeneric;
        public DBServiceGeneric<CartItem_Order> DBServiceGenericCIO;
        public DBServiceGeneric<CartItem> DBServiceGenericCartItem;
        public JsonFileService<Order> JsonFileService;
        public ICartItemService ICartItemService;
        public List<Order> Orders;
        public List<CartItem> CartItems;
        public int lastOrderID = 0;

        public OrderService(DBServiceGeneric<Order> dBServiceGeneric, JsonFileService<Order> jsonFileService, ICartItemService iCartItemService, DBServiceGeneric<CartItem_Order> dBServiceGenericCIO, DBServiceGeneric<CartItem> dBServiceGenericCartItem)
        {
            DBServiceGeneric = dBServiceGeneric;
            JsonFileService = jsonFileService;
            ICartItemService = iCartItemService;
            DBServiceGenericCIO = dBServiceGenericCIO;
            DBServiceGenericCartItem = dBServiceGenericCartItem;
            Orders = GetAllOrders();
            CartItems = ICartItemService.GetAllCartItems();
        }

        public List<Order> GetAllOrders()
        {
            //return MockData.MockDataOrder.GetMockOrders();
            //return JsonFileService.GetJsonObjects().ToList();
            return DBServiceGeneric.GetObjectsAsync().Result.ToList();
        }
        public Order GetOrderByID(int ID)
        {
            foreach(Order order in Orders)
            {
                if(order.ID == ID) 
                { 
                    return order; 
                }
            }
            return null;
        }

        public List<Order> GetOrdersByUserID(int UserID)
        {
            List<Order> userOrders = new List<Order>();
            foreach(Order order in Orders)
            {
                if(order.UserID == UserID)
                {
                     userOrders.Add(order);
                }
            }
            return userOrders;
        }

        public async Task CreateOrderAsync(Order order)
        {
            int IDCount = 0;
            foreach (Order listOrder in Orders)
            {
                if (IDCount < listOrder.ID)
                {
                    IDCount = listOrder.ID;
                }
            }
            //order.ID = IDCount + 1;
            IDCount = IDCount + 1;
            lastOrderID = IDCount;
            Orders.Add(order);
            //JsonFileService.SaveJsonObjects(Orders);
            await DBServiceGeneric.AddObjectAsync(order);
        }

        public async Task CancelOrderByIDAsync(int ID)
        {
            foreach(Order order in Orders)
            {
                if(order.ID == ID)
                {
                    order.Cancelled = true;
                    //JsonFileService.SaveJsonObjects(Orders);
                    await DBServiceGeneric.UpdateObjectAsync(order);
                }
            }

        }

        public Task PaidBoolConvertAsync()
        {
            throw new NotImplementedException();
        }

        //public void AddCartItemsToOrder()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task AddCartItemsToOrder()
        {
            int orderID = lastOrderID;

            if (orderID != null)
            {
                foreach (CartItem cartItem in CartItems)
                {
                    CartItem_Order cartItemOrder = new CartItem_Order(cartItem.ID, orderID);

                    await DBServiceGenericCIO.AddObjectAsync(cartItemOrder);
                }
            }
        }

        //public async Task GetOldOrderByOrderID(int ID)
        //{
        //    Order order = GetOrderByID(ID);
        //    List<CartItem_Order> CIO = new List<CartItem_Order>();
        //    List<CartItem> cartItemList = new List<CartItem>();
        //    foreach(CartItem_Order cartItem_Order in DBServiceGenericCIO.GetObjectsAsync().Result)
        //    {
        //        if(cartItem_Order.OrderID == order.ID)
        //        {
        //            CIO.Add(cartItem_Order);
        //        }
        //    }
        //    foreach(CartItem_Order cartItem_Order in CIO)
        //    {
        //        foreach(CartItem cartItem in DBServiceGenericCartItem.GetObjectsAsync().Result)
        //        {
        //            if(cartItem.ID == cartItem_Order.CartItemID)
        //            {
        //                cartItemList.Add(cartItem);
        //            }
        //        }
        //    }
        //    return cartItemList;
        //}        

        public async Task<List<CartItem>> GetOldOrderByOrderID(int ID)
        {
            Order order = GetOrderByID(ID);
            IEnumerable<CartItem_Order> CIO = await DBServiceGenericCIO.GetObjectsAsync();
            IEnumerable<CartItem> cartItemList = await DBServiceGenericCartItem.GetObjectsAsync();

            CIO = CIO.Where(cartItem_Order => cartItem_Order.OrderID == order.ID).ToList();
            cartItemList = cartItemList.Where(cartItem => CIO.Any(cartItem_Order => cartItem_Order.CartItemID == cartItem.ID)).ToList();
            return cartItemList.ToList();
        }

    }
}
