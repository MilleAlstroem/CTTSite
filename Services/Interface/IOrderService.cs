using CTTSite.DAO;
using CTTSite.Models;

namespace CTTSite.Services.Interface
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);
        Task PaidBoolConvertAsync();
        List<Order> GetAllOrders();
        Task CancelOrderByIDAsync(int ID);
        List<Order> GetOrdersByUserID(int UserID);
        Order GetOrderByID(int ID);
        Task<List<CartItem>> GetOldOrderByOrderID(int ID);
        Task AddCartItemsToOrder(int ID);
    }
}
