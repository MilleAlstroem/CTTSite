using CTTSite.DAO;
using CTTSite.Models;

namespace CTTSite.Services.Interface
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);
        List<Order> GetAllOrders();
        Task CancelOrderByIDAsync(int ID);
        List<Order> GetOrdersByUserID(int UserID);
        Order GetOrderByID(int ID);
        Task<List<CartItem>> GetOldOrderByOrderID(int ID);
        Task AddCartItemsToOrder(int ID);
        Task<int> GetLatestOrderFromUser(string userName);
    }
}
