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
        public JsonFileService<Order> JsonFileService;
        public ICartItemService ICartItemService;
        public List<Order> Orders;
        public int lastOrderID = 0;

        public OrderService(DBServiceGeneric<Order> dBServiceGeneric, JsonFileService<Order> jsonFileService, ICartItemService iCartItemService, DBServiceGeneric<CartItem_Order> dBServiceGenericCIO)
        {
            DBServiceGeneric = dBServiceGeneric;
            JsonFileService = jsonFileService;
            Orders = GetAllOrders();
            JsonFileService.SaveJsonObjects(Orders);
            ICartItemService=iCartItemService;
            DBServiceGenericCIO=dBServiceGenericCIO;
        }

        public List<Order> GetAllOrders()
        {
            //return DBServiceGeneric.GetObjectsAsync().Result.ToList();
            return JsonFileService.GetJsonObjects().ToList();
            //return MockData.MockDataOrder.GetMockOrders();
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
            order.ID = IDCount + 1;
            lastOrderID = order.ID;
            Orders.Add(order);
            JsonFileService.SaveJsonObjects(Orders);
            //await DBServiceGeneric.AddObjectAsync(order);
        }

        public async Task CancelOrderByIDAsync(int ID)
        {
            foreach(Order order in Orders)
            {
                if(order.ID == ID)
                {
                    order.Cancelled = true;
                    JsonFileService.SaveJsonObjects(Orders);
                    //await DBServiceGeneric.UpdateObjectAsync(order);
                }
            }

        }

        public Task PaidBoolConvertAsync()
        {
            throw new NotImplementedException();
        }

        public void AddCartItemsToOrder()
        {
            Order order = GetOrderByID(lastOrderID);
            List<CartItem_Order> cartItem_Orders = new List<CartItem_Order>();
            foreach(CartItem cartItem in ICartItemService.GetAllCartItemsByUserID(order.UserID))
            {
                cartItem_Orders.Add(new CartItem_Order(cartItem.ID, order.ID));
                DBServiceGenericCIO.AddObjectAsync(new CartItem_Order(cartItem.ID, order.ID));
            }   
            
            //DBServiceGenericCIO.SaveObjectsAsync(cartItem_Orders);
        }

        public async Task GetOldOrderByOrderID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
