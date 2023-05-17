using CTTSite.DAO;
using CTTSite.Models;

namespace CTTSite.Services.Interface
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task CreateOrderAsync(Order order);
        Task CancelOrderByIDAsync(int ID);
        List<Order> GetOrdersByUserID(int UserID);
        Order GetOrderByID(int ID);
        Task<List<CartItem>> GetOldOrderByOrderIDAsync(int ID);
        Task AddCartItemsToOrderAsync(int ID);
        Task<int> GetLatestOrderFromUserAsync(string userName);
    }
}
