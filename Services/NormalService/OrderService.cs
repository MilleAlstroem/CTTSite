using CTTSite.Models;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;

namespace CTTSite.Services.NormalService
{
    public class OrderService : IOrderService
    {
        public DBServiceGeneric<Order> DBServiceGeneric;
        public JsonFileService<Order> JsonFileService;
        public List<Order> Orders;

        public OrderService(DBServiceGeneric<Order> dBServiceGeneric, JsonFileService<Order> jsonFileService)
        {
            DBServiceGeneric = dBServiceGeneric;
            JsonFileService = jsonFileService;
            Orders = GetAllOrders();
            JsonFileService.SaveJsonObjects(Orders);
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
    }
}
