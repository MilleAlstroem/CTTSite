using CTTSite.DAO;
using CTTSite.EFDbContext;
using CTTSite.Models;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;
using MailKit.Search;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;

namespace CTTSite.Services.NormalService
{
    public class OrderService : IOrderService
    {
        private readonly DBServiceGeneric<Order> _dBServiceGeneric;
        private readonly DBServiceGeneric<CartItem_Order> _dBServiceGenericCIO;
        private readonly DBServiceGeneric<CartItem> _dBServiceGenericCartItem;
        private readonly JsonFileService<Order> _jsonFileService;
        private readonly IUserService _userService;
        private readonly ICartItemService _cartItemService;
        private readonly IItemService _itemService;
        private List<Order> _orders;
        private List<CartItem> _cartItems;
        private int _lastOrderID = 0;

        public OrderService(
            DBServiceGeneric<Order> dBServiceGeneric,
            JsonFileService<Order> jsonFileService,
            ICartItemService cartItemService,
            DBServiceGeneric<CartItem_Order> dBServiceGenericCIO,
            DBServiceGeneric<CartItem> dBServiceGenericCartItem,
            IUserService userService,
            IItemService itemService)
        {
            _dBServiceGeneric = dBServiceGeneric;
            _jsonFileService = jsonFileService;
            _cartItemService = cartItemService;
            _dBServiceGenericCIO = dBServiceGenericCIO;
            _dBServiceGenericCartItem = dBServiceGenericCartItem;
            _userService = userService;
            _itemService = itemService;
            _orders = GetAllOrdersAsync().Result;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            //return MockData.MockDataOrder.GetMockOrders();
            //return _jsonFileService.GetJsonObjects().ToList();
            return (await _dBServiceGeneric.GetObjectsAsync()).ToList();
        }

        public async  Task<Order> GetOrderByIDAsync(int ID)
        {
            //foreach (Order order in _orders)
            //{
            //    if (order.ID == ID)
            //    {
            //        return order;
            //    }
            //}
            //return null;
            return await _dBServiceGeneric.GetObjectByIdAsync(ID);
        }

        public async Task<List<Order>> GetOrdersByUserIDAsync(int userID)
        {
            return await Task.Run(() => _orders.Where(order => order.UserID == userID).ToList());
        }

        public async Task CreateOrderAsync(Order order)
        {
            int IDCount = 0;
            foreach (Order listOrder in _orders)
            {
                if (IDCount < listOrder.ID)
                {
                    IDCount = listOrder.ID;
                }
            }
            //order.ID = IDCount + 1;
            IDCount = IDCount + 1;
            _lastOrderID = IDCount;
            _orders.Add(order);
            //JsonFileService.SaveJsonObjects(Orders);
            await _dBServiceGeneric.AddObjectAsync(order);
        }

        public async Task CancelOrderByIDAsync(int ID)
        {
            Order orderToBeCancel = await GetOrderByIDAsync(ID);

            foreach (Order order in _orders)
            {
                if (order.ID == ID)
                {
                    order.Cancelled = true;
                    //JsonFileService.SaveJsonObjects(Orders);
                }
            }
            if (orderToBeCancel != null)
            {
                orderToBeCancel.Cancelled = true;
                await _dBServiceGeneric.UpdateObjectAsync(orderToBeCancel);
            }
        }

        public async Task AddCartItemsToOrderAsync(int ID)
        {
            int orderID = _lastOrderID;
            _cartItems = await _cartItemService.GetAllCartItemsByUserIDAsync(ID);

            if (orderID != null)
            {
                foreach (CartItem cartItem in _cartItems)
                {
                    CartItem_Order cartItemOrder = new CartItem_Order(cartItem.ID, orderID);

                    await _dBServiceGenericCIO.AddObjectAsync(cartItemOrder);
                }
            }
        }

        public async Task<List<CartItem>> GetOldOrderByOrderIDAsync(int orderID)
        {
            IEnumerable<CartItem_Order> CIO = await _dBServiceGenericCIO.GetObjectsAsync();
            IEnumerable<CartItem> cartItems = await _dBServiceGenericCartItem.GetObjectsAsync();

            CIO = CIO.Where(cartItem_Order => cartItem_Order.OrderID == orderID).ToList();
            List<CartItem> cartItemList = cartItems.Where(cartItem => CIO.Any(cartItem_Order => cartItem_Order.CartItemID == cartItem.ID)).ToList();

            // Include the associated Item for each CartItem
            foreach (CartItem cartItem in cartItemList)
            {
                cartItem.Item = await _itemService.GetItemByIDAsync(cartItem.ItemID); // Assuming you have a method to retrieve Item by ID asynchronously
            }

            return cartItemList;
        }

        public async Task<int> GetLatestOrderFromUserAsync(string userName)
        {
            Models.User user = _userService.GetUserByEmail(userName);
            List<Order> userOrders = await GetOrdersByUserIDAsync(user.Id);
            Order latestOrder = userOrders.OrderByDescending(order => order.ID).FirstOrDefault();
            return latestOrder?.ID ?? 0;
        }
    }
}