using CTTSite.Models;

namespace CTTSite.Services
{
    public interface IItemService
    {
        List<Item> GetAllItems();
        Task CreateItemAsync(Item item);
        Task UpdateItemByIDAsync(int ID);
        Task DeleteItemByIDAsync(int ID);
        Task UpdateItemStockAsync(int amount);
    }
}
