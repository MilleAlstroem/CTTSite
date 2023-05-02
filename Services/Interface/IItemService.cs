using CTTSite.Models;

namespace CTTSite.Services
{
    public interface IItemService
    {
        List<Item> GetItems();
        Item GetItem(int id);
        void AddItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(int id);
    }
}
