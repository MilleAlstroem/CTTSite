using CTTSite.Models;

namespace CTTSite.Services
{
    public interface IItemService
    {
        List<Item> GetAllItems();
        Task CreateItemAsync(Item item);
        Task UpdateItemAsync(Item itemN);
        Task DeleteItemByIDAsync(int ID);
        Task UpdateItemStockAsync(int itemID, int amount);
        Item GetItemByID(int ID);
    }
}
